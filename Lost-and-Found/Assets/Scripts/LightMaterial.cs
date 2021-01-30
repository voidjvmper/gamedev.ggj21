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
    void Start()
    {
        litState = shouldStartOn;
        meshRenderer = objectToLightUp.GetComponent<MeshRenderer>();
        FlipMaterial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FlipMaterial()
    {
        meshRenderer.material = activatingMaterial[Convert.ToInt32(litState)];

    }

    public override void EnterTriggerVolume()
    {
        base.EnterTriggerVolume();
        litState = !litState;
        FlipMaterial();
    }
    public override void StayTriggerVolume()
    {
        base.StayTriggerVolume();
        return;
    }
    public override void ExitTriggerVolume()
    {
        base.ExitTriggerVolume();
        litState = !litState;
        FlipMaterial();
    }
}
