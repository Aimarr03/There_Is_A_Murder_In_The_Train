using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private Dialogue testDialogue;
    public void Start()
    {
        DialogueManager.Instance.StartDialogue(testDialogue);
    }
}
