using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerVolume : MonoBehaviour
{
    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public virtual void EnterTriggerVolume(Interactable pInteractable)
    {
        return;
    }
    public virtual void StayTriggerVolume(Interactable pInteractable)
    {
        return;
    }
    public virtual void ExitTriggerVolume(Interactable pInteractable)
    {
        return;
    }
}
