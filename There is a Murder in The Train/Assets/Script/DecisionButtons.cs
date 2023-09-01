using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionButtons : MonoBehaviour 
{
    [SerializeField] private Dialogue outcomes;
    public void DecisionClick()
    {
        DialogueManager.instance.ChangeDialog(outcomes);
    } 
}
