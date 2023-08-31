using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_Character", menuName = "ScriptableObject/New Dialogue Scene")]
[System.Serializable]
public class Dialogue : ScriptableObject
{
    [System.Serializable]
    public class DialogueEntry
    {
        public string speakerName;
        public string speakerExpression;
        [TextArea(3, 10)]
        public List<string> speakerLines;
    }
    public List<DialogueEntry> entries = new List<DialogueEntry>();
    public List<Character> characterInvolved = new List<Character>();
    public List<Clue> clue;
    public bool dialogueDone = false;
    public bool ClueProvided()
    {
        return clue != null;
    }
}
