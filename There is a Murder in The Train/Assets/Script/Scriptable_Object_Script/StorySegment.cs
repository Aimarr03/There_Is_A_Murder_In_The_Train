using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New_Character", menuName = "ScriptableObject/New Game Scene")]
[System.Serializable]
public class StorySegment : ScriptableObject
{
    [System.Serializable]
    public class DialogueEntryPair
    {
        public string key;
        public Dialogue value;
    }
    public List<DialogueEntryPair> dialogueList = new List<DialogueEntryPair>();
    public int recordDialogueNecessaryDone;
    public StorySegment nextGameScene;
    public void SetNecessaryDialoguesNumber()
    {
        recordDialogueNecessaryDone = 0;
        foreach(DialogueEntryPair dialogue in dialogueList)
        {
            if (dialogue.value.necessaryDialogue)
            {
                recordDialogueNecessaryDone++;
            }
        }
    }
}
