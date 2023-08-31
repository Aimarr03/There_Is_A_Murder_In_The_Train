using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public StorySegment currentStorySegment;
    public int currentNecessaryDialogueDone;
    public void Awake()
    {
        instance = this;
    }
    public bool CheckAllNecessaryDialogueDone()
    {
        return currentNecessaryDialogueDone == currentStorySegment.recordDialogueNecessaryDone;
    }
    public void LoadNextStorySegment()
    {
        currentStorySegment = currentStorySegment.nextGameScene;
        currentNecessaryDialogueDone = 0;
        currentStorySegment.SetNecessaryDialoguesNumber();
        
    }
}
