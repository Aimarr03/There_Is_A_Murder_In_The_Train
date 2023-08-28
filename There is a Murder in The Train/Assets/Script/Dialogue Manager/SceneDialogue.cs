using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogueScene", menuName ="Data/New Dialogue Scene")]
[System.Serializable]
public class SceneDialogue : ScriptableObject
{
    public List<Sentence> sentences;

    [System.Serializable]
    public struct Sentence
    {
        public string text;
        public Speaker speaker;
    }
}