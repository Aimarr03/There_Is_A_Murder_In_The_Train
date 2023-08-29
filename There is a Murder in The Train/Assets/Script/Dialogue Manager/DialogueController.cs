using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public SceneDialogue currentScene;
    public ManagerDialogue dialogueBox;

    CanvasGroup canvasGroup;
    void ShowHide(bool visible) 
    {
        canvasGroup.alpha = visible ? 1f : 0f; 
        canvasGroup.blocksRaycasts = visible ? true : false; 
        canvasGroup.interactable = visible ? true : false; 
    }
    public void ChangeDialogue(SceneDialogue scene){
        currentScene = scene;
    }

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        this.ShowHide(true);
        dialogueBox.PlayScene(currentScene);
        // backgroundController.SetImage(currentScene.background);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (dialogueBox.IsCompleted())
            {
                if (dialogueBox.IsLastSentence())
                {
                    currentScene = null;
                    Destroy(gameObject);
                }
                else
                {
                    dialogueBox.PlayNextSentence();
                }
            }
            else
            {

            }
        }
    }
}
