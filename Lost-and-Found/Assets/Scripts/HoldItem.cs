using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldItem : Interactable
{
    

    private Transform originalParent;
    protected Rigidbody rgbody = null;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        keyToPress = Settings.STR_KEYCODE_HOLD_OVRRDE;
        keyToDo = Settings.STR_KEYCODE_HOLD_ACTION_OVRRDE;

        SetKeyCode(Settings.KEYCODE_HOLD);

        icon = Resources.Load<Sprite>(Settings.PATH_CROSSHAIR_CIRCLE);

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
        character.SetCurrentInteractable(this);
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
        character.ClearCurrentInteractable(this);
    }


    
}
