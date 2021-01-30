using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuestChain
{
    private static int currentQuestStep = 0;
    // Start is called before the first frame update
   
    public static void ProgressChain()
    {

    }
    public static int QuestStep
    {
        get { return currentQuestStep; }
    }

}
