using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenActivate : TriggerVolume
{
    [SerializeField] private ScreenFlicker screen;
    [SerializeField] private Transform anchorPoint;
    
    protected override void Start()
    {
        base.Start();
       
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public override void EnterTriggerVolume(Interactable pInteractable)
    {
        Debug.Log("Entereing Trigger Volume");
        base.EnterTriggerVolume(pInteractable);
        Plug plug = ((Plug)pInteractable);
        if (!plug.IsPlugged)
        {
            pInteractable.EndInteraction();
            plug.SnapHoldPlug(anchorPoint, true);
            screen.ToggleScreen(true);
        }
       



       
    }
    public override void StayTriggerVolume(Interactable pInteractable)
    {

        base.StayTriggerVolume(pInteractable);
       
        return;
    }
    public override void ExitTriggerVolume(Interactable pInteractable)
    {
        Debug.Log("Exiting Trigger Volume");
        base.ExitTriggerVolume(pInteractable);
        
        Plug plug = ((Plug)pInteractable);
        if (plug.IsPlugged)
        {
            plug.SnapHoldPlug(anchorPoint, false);

            screen.ToggleScreen(false);
        }

        

    }
}
