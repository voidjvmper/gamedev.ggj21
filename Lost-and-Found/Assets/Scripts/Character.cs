using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Character : MonoBehaviour
{
    [SerializeField] private Transform holdAnchor;
    [SerializeField] private Camera playerCamera;
    [SerializeField] private TextMeshProUGUI keybindPromptField;
    [SerializeField] private TextMeshProUGUI keybindActionField;
    [SerializeField] private Image crosshair;
    private Sprite defaultCrosshair;

    private Interactable nearestInteractable = null;
    private Interactable currentInteractable = null;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Assert(holdAnchor != null, "HoldAnchor transform on Character '" + gameObject.name + "' is not assigned.");
        Debug.Assert(playerCamera != null, "PlayerCamera transform on Character '" + gameObject.name + "' is not assigned.");
        Debug.Assert(keybindPromptField != null, "Keybind Prompt Field transform on Character '" + gameObject.name + "' is not assigned.");
        Debug.Assert(keybindActionField != null, "Keybind Actin Field transform on Character '" + gameObject.name + "' is not assigned.");

        defaultCrosshair = Resources.Load<Sprite>(Settings.PATH_CROSSHAIR_DEFAULT);
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

                string keyPrompt = string.Format(Settings.STR_INTERACT_KEYBIND_BRACKETS, nearestInteractable.KeyCodeOverrideString);
                string keyAction = string.Format(Settings.STR_INTERACT_TODO, nearestInteractable.KeyActionOverrideString);
                Sprite icon = nearestInteractable.SpriteIcon;

                keybindPromptField.text = keyPrompt;
                keybindActionField.text = keyAction;
                if (icon != null)
                {
                    crosshair.sprite = icon;
                }
            }
        }
        else
        {
            ClearUI();
        }

       
    }

    private void ClearUI()
    {
        crosshair.sprite = defaultCrosshair;
        keybindPromptField.text = string.Empty;
        keybindActionField.text = string.Empty;
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
