using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New_Character", menuName = "ScriptableObject/New Choice")]
public class Choice : ScriptableObject
{
    [TextArea(3, 10)]
    public string textChoice;
    public StorySegment nextStorySegment;
}
