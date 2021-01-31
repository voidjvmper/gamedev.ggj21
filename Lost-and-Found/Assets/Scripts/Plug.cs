using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plug : HoldItem
{
    [SerializeField] private TriggerVolume[] triggerVolumes;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform endWirePoint;

    private Vector3[] points;

    [SerializeField]
    private bool isPlugged;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        points = new Vector3[] { gameObject.transform.position, endWirePoint.position };
        lineRenderer.positionCount = points.Length;

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        points = new Vector3[] { gameObject.transform.position, endWirePoint.position };
        lineRenderer.SetPositions(points);
    }

    protected void OnTriggerEnter(Collider other)
    {
        int pVolumeID = int.MaxValue;
        bool isLinkedVolume = CheckTriggerVolumes(other.gameObject, out pVolumeID);
        if (isLinkedVolume && pVolumeID != int.MaxValue)
        {
            triggerVolumes[pVolumeID].EnterTriggerVolume(this);
        }
    }

    protected void OnTriggerStay(Collider other)
    {
        int pVolumeID = int.MaxValue;
        bool isLinkedVolume = CheckTriggerVolumes(other.gameObject, out pVolumeID);
        if (isLinkedVolume && pVolumeID != int.MaxValue)
        {
            triggerVolumes[pVolumeID].StayTriggerVolume(this);
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        int pVolumeID = int.MaxValue;
        bool isLinkedVolume = CheckTriggerVolumes(other.gameObject, out pVolumeID);
        if (isLinkedVolume && pVolumeID != int.MaxValue)
        {
            triggerVolumes[pVolumeID].ExitTriggerVolume(this);
        }
    }

    public void SnapHoldPlug(Transform pTransform, bool pShouldStick)
    {
        if (rgbody != null)
        {
            isPlugged = pShouldStick;
            if (pShouldStick)
            {
                rgbody.useGravity = false;
                rgbody.isKinematic = true;

                transform.position = pTransform.position;
                transform.rotation = pTransform.rotation;
 
            }
            else
            {
                rgbody.useGravity = true;
                rgbody.isKinematic = false;
            }
            
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

    public bool IsPlugged
    {
        get { return isPlugged; }
    }
}
