using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    
    protected Sprite icon;
    public enum QuestProgressorPoint { BEGIN, CONTINUE, END };

    protected string keyToPress = Settings.STR_INTERACT_KEYBIND;
    protected string keyToDo = Settings.STR_INTERACT_TODO;

    protected Character character = null;
   
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
        icon = Resources.Load<Sprite>(Settings.PATH_CROSSHAIR_DEFAULT);
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
       /*for (int i = 0; i < questProgression.Length; i++)
        {
            if (questProgression[i].questStep == QuestChain.QuestStep)
            {
                if (questProgression[i].progressorPoint == pPoint)
                {
                    QuestChain.ProgressChain();
                }
            }
        }*/
    }


    public KeyCode KeyCode
    {
        get { return keycode; }
    }

    public string KeyCodeOverrideString
    {
        get { return keyToPress; }
    }

    public string KeyActionOverrideString
    {
        get { return keyToDo; }
    }

    public Sprite SpriteIcon
    {
        get { return icon; }
    }
}
