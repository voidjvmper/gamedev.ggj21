using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItem : Interactable
{
    private Transform originalParent;
    private Rigidbody rgbody = null;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        SetKeyCode(Settings.KEYCODE_HOLD);
        originalParent = gameObject.transform.parent;
        rgbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void OnKeyDown()
    {
        BeginInteraction();
    }

    public override void OnKeyUp()
    {
        EndInteraction();
    }

    public override void BeginInteraction()
    {
        base.BeginInteraction();
        gameObject.transform.parent = character.HoldAnchor;
        if (rgbody != null)
        {
            rgbody.useGravity = false;
            rgbody.isKinematic = true;
        }
    }

    public override void EndInteraction()
    {
        base.BeginInteraction();
        gameObject.transform.parent = originalParent;
        if (rgbody != null)
        {
            rgbody.useGravity = true;
            rgbody.isKinematic = false;
        }
    }


    
}
