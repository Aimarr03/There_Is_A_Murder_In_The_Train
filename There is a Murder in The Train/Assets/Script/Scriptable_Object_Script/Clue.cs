using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_Character", menuName = "ScriptableObject/New Clue")]
[System.Serializable]
public class Clue : ScriptableObject
{
    public int index;
    public string clueHighlight;
    [TextArea(3, 10)]
    public List<string> clueParagraphs = new List<string>();
    public Sprite clueImage;
}
