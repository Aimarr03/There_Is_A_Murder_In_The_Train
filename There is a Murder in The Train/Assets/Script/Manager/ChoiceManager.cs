using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceManager : MonoBehaviour
{
    [SerializeField] private Transform ChoicePanel;
    public static ChoiceManager instance;
    [SerializeField] private Dialogue confirmStorySegment;
    public void Awake()
    {
        instance = this;
    }
    public void Start()
    {
        ChoicePanel.gameObject.SetActive(false);
    }
    public void DisplayUI()
    {
        ChoicePanel.gameObject.SetActive(true);
    }
    public void ConfirmChoice()
    {
        if(confirmStorySegment != null)
        {
            ChoicePanel.gameObject.SetActive(false);
            DialogueManager.instance.ChangeDialog(confirmStorySegment);
        }
    }
    public void SetStorySegment(Dialogue DialogueChoice)
    {
        this.confirmStorySegment = DialogueChoice;
    }
}
