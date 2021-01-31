using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PromptDialogue : Interactable
{
    [SerializeField] private string dialogueString;
    private string outputString = "";
    [SerializeField]
    private TextMeshProUGUI textMesh;
    private float textCountdown = float.MaxValue;
    private float timer = 0.0f;
    private bool isTextUp = false;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        SetKeyCode(Settings.KEYCODE_INTERACT);
        textCountdown = Settings.VAL_TIME_TO_FADE_DIALOGUE;
        textMesh.text = string.Empty;
    }

    // Update is called once per frame
    protected override void Update()
    {
        /*if (isTextUp)
        {
            do
            {
               timer += Settings.VAL_TIME_FADE_TIMESTEP;
            } 
            while (timer <= textCountdown);

            if (timer >= textCountdown)
            {
                StartCoroutine(FuzzOutText());
            }
            
        }*/
    }
    public override void OnKeyDown()
    {
        if (!isTextUp)
        {
            BeginInteraction();
        }
    }

    public override void BeginInteraction()
    {
        base.BeginInteraction();
        StartCoroutine(TypeText(dialogueString));
    }

    private IEnumerator TypeText(string pSentence)
    {
        textMesh.text = "";
        foreach (char letter in pSentence.ToCharArray())
        {
            textMesh.text += letter;
            yield return new WaitForSeconds(0.1f);
        }
        isTextUp = true;
        StartCoroutine(WaitForText());
    }

    private IEnumerator WaitForText()
    {
        float timer = 0.0f;
        do
        {
            timer += Settings.VAL_TIME_FADE_TIMESTEP;
            yield return new WaitForSeconds(Settings.VAL_TIME_FADE_TIMESTEP);
        } while (timer <= textCountdown);
        StartCoroutine(FuzzOutText());
        
    }

    private IEnumerator FuzzOutText()
    {
        string postedDialogue = textMesh.text;
        //int remaining = 0;
        string fuzzed = "";
        for (int i = 0; i < postedDialogue.Length; i++)
        {
            //string fuzzed = GetRepeatedText(Settings.STR_TEXT_FUZZ_CHARACTER, remaining);
            fuzzed += Settings.STR_TEXT_FUZZ_CHARACTER;
            textMesh.text = dialogueString.Substring(0, postedDialogue.Length - (i + 1)) + fuzzed;
            yield return new WaitForSeconds(0.1f);
        }
        ResetDialogue();
    }

    private void ResetDialogue()
    {
        textMesh.text = string.Empty;
        isTextUp = false;
        timer = 0.0f;
    }

    private string GetRepeatedText(string pString, int pIterations)
    {
        string output = "";
        for (int i = 0; i < pIterations; i++)
        {
            output += pString;
        }
        return output;
    }

  
  }
