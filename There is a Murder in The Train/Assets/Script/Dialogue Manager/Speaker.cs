using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewSpeaker", menuName = "Data/New Speaker Name")]
[System.Serializable]
public class Speaker : ScriptableObject
{
    public string speakerName;
    public Image body;
    public List<Image> expression;
}
