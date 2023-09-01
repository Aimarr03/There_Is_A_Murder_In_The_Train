using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteract : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    [SerializeField] private Dialogue dialogue;
    
    private bool Touched()
    {
        return Physics2D.OverlapBox(transform.position, transform.localScale * 2, 0f, playerLayer);
    }
    void OnMouseDown()
    {
        //Debug.Log(Touched());
        //Debug.Log(dialogue.dialogueDone);
        if(dialogue != null)
        {
            if (Touched() && !dialogue.dialogueDone)
            {
                DialogueManager.instance.ChangeDialog(dialogue);
            }
        }
    }
    public Dialogue GetDialogue()
    {
        return dialogue;
    }
    public void SetDialogue(Dialogue dialogue)
    {
        this.dialogue = dialogue;
    }

}
