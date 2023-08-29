using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(fileName = "NewDialogue", menuName = "Data/New Dialogue Initiator")]
[System.Serializable]
public class DialogueInitiator : MonoBehaviour 
{
    public List<SceneDialogue> heldDialogue;
    protected SceneDialogue currentHold;
    private int number = 0;
    public GameObject textBox;    
    public DialogueController textCon;
    public void Initiated(){
        if(number >= heldDialogue.Count) 
        {
            number--;
        }
        else{
        currentHold = heldDialogue[number];
        var newText = Instantiate(textBox);
        textCon.ChangeDialogue(currentHold);
        number++;
        }
    }   
} 

    

