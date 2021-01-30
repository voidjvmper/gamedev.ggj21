using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    protected Character character = null;
    protected InteractableDataPackage dataPackage = null;
    protected KeyCode keycode = KeyCode.None;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SendDataPackage(InteractableDataPackage pDataPackage)
    {
        dataPackage = pDataPackage;
    }

    public void PassCharacter(Character pCharacter)
    {
        character = pCharacter;
    }

    protected void SetKeyCode(KeyCode pCode)
    {
        keycode = pCode;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnKeyDown()
    {
        return;
    }

    public virtual void OnKeyHold()
    {
        return;
    }

    public virtual void OnKeyUp()
    {
        return;
    }

    public virtual void BeginInteraction()
    {
        return;
    }

    public virtual void ContinueInteraction()
    {
        return;
    }

    public virtual void EndInteraction()
    {
        return;
    }

    public KeyCode KeyCode
    {
        get { return keycode; }
    }

}
