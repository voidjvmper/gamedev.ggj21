using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Transform holdAnchor;
    [SerializeField] private Camera playerCamera;
    private Interactable nearestInteractable = null;
    private Interactable currentInteractable = null;
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
           // Debug.Log("Hit an object!");
            nearestInteractable = hit.transform.gameObject.GetComponent<Interactable>();
            if (nearestInteractable != null)
            {
                Debug.Log(string.Format("Found Interactable, named {0}", hit.transform.gameObject.name));
                nearestInteractable.PassCharacter(this);
            }
        }
    }

    private void HandleInteractable(Interactable pInteractable)
    {
        if (Input.GetKeyDown(pInteractable.KeyCode))
        {
            pInteractable.OnKeyDown();
        }

        if (Input.GetKey(pInteractable.KeyCode))
        {
            pInteractable.OnKeyHold();
        }

        if (Input.GetKeyUp(pInteractable.KeyCode))
        {
            pInteractable.OnKeyUp();
        }
    }

    private void HandleInput()
    {
        if (nearestInteractable != null && currentInteractable == null)
        {
            HandleInteractable(nearestInteractable);
        }

        else if (currentInteractable != null)
        {
            HandleInteractable(currentInteractable);
        }
     
    }

    public Transform HoldAnchor
    {
        get { return holdAnchor; }
    }

    public void SetCurrentInteractable(Interactable pInteractable)
    {
        if (currentInteractable == null)
        {
            currentInteractable = pInteractable;

        }
       
    }

    public void ClearCurrentInteractable(Interactable pInteractable)
    {
        if (pInteractable == currentInteractable)
        {
            currentInteractable = null;
        }
    }

}
