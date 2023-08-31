using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New_Character", menuName = "ScriptableObject/New Game Scene")]
[System.Serializable]
public class StorySegment : ScriptableObject
{
    public Dictionary<string, Dialogue> dialogueList = new Dictionary<string, Dialogue>();
    public int recordDialogueNecessaryDone;
    public StorySegment nextGameScene;
    public void SetNecessaryDialoguesNumber()
    {
        recordDialogueNecessaryDone = 0;
        foreach(Dialogue dialogue in dialogueList.Values)
        {
            if (dialogue.necessaryDialogue)
            {
                recordDialogueNecessaryDone++;
            }
        }
    }
}
