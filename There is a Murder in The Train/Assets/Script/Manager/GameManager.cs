using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public StorySegment currentStorySegment;
    public Dictionary<string, GameObject> currentGameObjectHeld = new Dictionary<string, GameObject>();
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
        foreach(var currentGameObject in currentGameObjectHeld)
        {
            string key = currentGameObject.Key;
            GameObject value = currentGameObject.Value;
            ObjectPoolManager.instance.ReturnToPool(key, value);
        }
        currentGameObjectHeld.Clear();
        if (currentStorySegment.nextGameScene == null) return;
        currentStorySegment = currentStorySegment.nextGameScene;
        currentNecessaryDialogueDone = 0;
        currentStorySegment.SetNecessaryDialoguesNumber();
        List<StorySegment.DialogueEntryPair> dialoguesData = currentStorySegment.dialogueList;
        foreach(StorySegment.DialogueEntryPair currentDialogueData in dialoguesData)
        {
            GameObject gameObject = ObjectPoolManager.instance.GetFromPool(currentDialogueData.key);
            if(gameObject.TryGetComponent<NPCInteract>(out NPCInteract npcInterraction))
            {
                npcInterraction.SetDialogue(currentDialogueData.value);
            }
        }
    }
}
