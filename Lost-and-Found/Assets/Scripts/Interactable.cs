using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Interactable : MonoBehaviour
{
    public enum QuestProgressorPoint { BEGIN, CONTINUE, END };

    protected Character character = null;
    protected InteractableDataPackage dataPackage = null;
    protected KeyCode keycode = KeyCode.None;
    public QuestProgression[] questProgression;

    [Serializable]
    public struct QuestProgression
    {
        //[SerializeField]
        public QuestProgressorPoint progressorPoint;

        //[SerializeField]
        public int questStep;
    }


    // Start is called before the first frame update
    protected virtual void Start()
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
    protected virtual void Update()
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
        CheckQuest(QuestProgressorPoint.BEGIN);
        return;        
    }



    public virtual void ContinueInteraction()
    {
        CheckQuest(QuestProgressorPoint.CONTINUE);
        return;
    }

    public virtual void EndInteraction()
    {
        CheckQuest(QuestProgressorPoint.END);
        return;
    }

    protected void CheckQuest(QuestProgressorPoint pPoint)
    {
        for (int i = 0; i < questProgression.Length; i++)
        {
            if (questProgression[i].questStep == QuestChain.QuestStep)
            {
                if (questProgression[i].progressorPoint == pPoint)
                {
                    QuestChain.ProgressChain();
                }
            }
        }
    }


    public KeyCode KeyCode
    {
        get { return keycode; }
    }

}
