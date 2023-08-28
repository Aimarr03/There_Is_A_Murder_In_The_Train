using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewDialogue", menuName = "Data/New Dialogue Initiator")]
[System.Serializable]
public class DialogueInitiator : ScriptableObject 
{
    public SceneDialogue heldDialogue;
    public GameObject textBox;    
    // public void Initiated(){
    //     var newText = Instantiate(textBox);
    //     newText.transform.SetParent(gameObject);
    // }   
} 

    

