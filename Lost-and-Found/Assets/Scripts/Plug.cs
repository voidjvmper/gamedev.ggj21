using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plug : HoldItem
{
    [SerializeField] private TriggerVolume[] triggerVolumes;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected void OnTriggerEnter(Collider other)
    {
        int pVolumeID = int.MaxValue;
        bool isLinkedVolume = CheckTriggerVolumes(other.gameObject, out pVolumeID);
        if (isLinkedVolume && pVolumeID != int.MaxValue)
        {
            triggerVolumes[pVolumeID].EnterTriggerVolume();
        }
    }

    protected void OnTriggerStay(Collider other)
    {
        int pVolumeID = int.MaxValue;
        bool isLinkedVolume = CheckTriggerVolumes(other.gameObject, out pVolumeID);
        if (isLinkedVolume && pVolumeID != int.MaxValue)
        {
            triggerVolumes[pVolumeID].StayTriggerVolume();
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        int pVolumeID = int.MaxValue;
        bool isLinkedVolume = CheckTriggerVolumes(other.gameObject, out pVolumeID);
        if (isLinkedVolume && pVolumeID != int.MaxValue)
        {
            triggerVolumes[pVolumeID].ExitTriggerVolume();
        }
    }

    private bool CheckTriggerVolumes(GameObject pGO, out int pID)
    {
        bool output = false;
        pID = int.MaxValue;
        for (int i = 0; i < triggerVolumes.Length; i++)
        {
            TriggerVolume volume = pGO.gameObject.GetComponent<TriggerVolume>();
            if (volume == triggerVolumes[i])
            {
                output = true;
                pID = i;
            }
        }
        return output;
    }
}
