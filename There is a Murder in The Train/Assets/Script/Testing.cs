using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    public Dialogue dialogue;
    public void Start()
    {
        DialogueManager.instance.ChangeDialog(dialogue);
    }
    // Update is called once per frame
    void Update()
    {
        if(DialogueManager.instance.GetDoneCondition())
        {
            ClueManager.instance.ClueButton.gameObject.SetActive(true);
        }
        else
        {
            ClueManager.instance.ClueButton.gameObject.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!DialogueManager.instance.LastConversation())
            {
                if (!DialogueManager.instance.LastLine())
                {
                    DialogueManager.instance.PlayNextLine();
                }
                else
                {
                    DialogueManager.instance.IncremenetConversation();
                    DialogueManager.instance.PlayNextDialogue();
                }
            }
            else
            {
                DialogueManager.instance.HideUI();
            }
            Debug.Log(DialogueManager.instance.indexConversation);
            Debug.Log(DialogueManager.instance.indexLine);
        }
        if(Input.GetMouseButtonUp(1)) 
        {
            ClueManager.instance.checkClue();
        }
    }

}
