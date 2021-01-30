using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Transform holdAnchor;
    [SerializeField] private Camera playerCamera;
    Interactable nearestInteractable = null;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(holdAnchor != null, "HoldAnchor transform on Character '" + gameObject.name + "' is not assigned.");
        Debug.Assert(playerCamera != null, "PlayerCamera transform on Character '" + gameObject.name + "' is not assigned.");
    }

    private void Update()
    {
        HandleInput();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FireRaycast();

    }

    private void FireRaycast()
    {
        RaycastHit hit;        
        
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, Settings.VAL_CHAR_INTERACT_MAX_DISTANCE))
        {
            Debug.Log("Hit an object!");
            nearestInteractable = hit.transform.gameObject.GetComponent<Interactable>();
            if (nearestInteractable != null)
            {
                Debug.Log(string.Format("Found Interactable, named {0}", hit.transform.gameObject.name));
                nearestInteractable.PassCharacter(this);
            }
        }
    }

    private void HandleInput()
    {
        if (nearestInteractable != null)
        {
            if (Input.GetKeyDown(nearestInteractable.KeyCode))
            {
                nearestInteractable.OnKeyDown();
            }

            if (Input.GetKey(nearestInteractable.KeyCode))
            {
                nearestInteractable.OnKeyHold();
            }

            if (Input.GetKeyUp(nearestInteractable.KeyCode))
            {
                nearestInteractable.OnKeyUp();
            }

        }
     
    }

    public Transform HoldAnchor
    {
        get { return holdAnchor; }
    }
}
