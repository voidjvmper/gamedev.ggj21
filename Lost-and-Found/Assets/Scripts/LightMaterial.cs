using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LightMaterial : TriggerVolume
{
    [SerializeField] private GameObject objectToLightUp;
    //[Range(1,2)]
    [SerializeField] private Material[] activatingMaterial;
    [SerializeField] private bool shouldStartOn;
    private bool litState = false;
    private MeshRenderer meshRenderer;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        litState = shouldStartOn;
        meshRenderer = objectToLightUp.GetComponent<MeshRenderer>();
        FlipMaterial();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    private void FlipMaterial()
    {
        meshRenderer.material = activatingMaterial[Convert.ToInt32(litState)];

    }

    public override void EnterTriggerVolume(Interactable pInteractable)
    {
        base.EnterTriggerVolume(pInteractable);
        litState = !litState;
        FlipMaterial();
    }
    public override void StayTriggerVolume(Interactable pInteractable)
    {
        base.StayTriggerVolume(pInteractable);
        return;
    }
    public override void ExitTriggerVolume(Interactable pInteractable)
    {
        base.ExitTriggerVolume(pInteractable);
        litState = !litState;
        FlipMaterial();
    }
}
