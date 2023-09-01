using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionDialogue : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] LayerMask playerLayer;
    [SerializeField] private Dialogue preDecision;
    [SerializeField] private List<Dialogue> postDecision;
    [SerializeField] private DecisionScreen decisionScreen;
    
    private bool Touched()
    {
        return Physics2D.OverlapBox(transform.position, transform.localScale * 2, 0f, playerLayer);
    }
    void OnMouseDown()
    {
        Debug.Log(Touched());
        Debug.Log(preDecision.dialogueDone);
        if (Touched() && !preDecision.dialogueDone)
        {
            DialogueManager.instance.ChangeDialog(preDecision);
        }
    }
    void FixedUpdate()
    {
        if (Touched() && preDecision.dialogueDone)
        {
            decisionScreen.ShowButtons();
        }
    }
    // public Dialogue GetDialogue()
    // {
    //     return dialogue;
    // }
    // public void SetDialogue(Dialogue dialogue)
    // {
    //     this.dialogue = dialogue;
    // }
}
