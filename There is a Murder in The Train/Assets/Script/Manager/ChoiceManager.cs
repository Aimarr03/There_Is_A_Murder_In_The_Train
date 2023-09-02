using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceManager : MonoBehaviour
{
    [SerializeField] private Transform ChoicePanel;
    public static ChoiceManager instance;
    [SerializeField] private StorySegment confirmStorySegment;
    public void Awake()
    {
        instance = this;
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
            GameManager.instance.currentStorySegment.nextGameScene = confirmStorySegment;
            GameManager.instance.LoadNextStorySegment();
        }
    }
    public void SetStorySegment(StorySegment storySegment)
    {
        this.confirmStorySegment = storySegment;
    }
}
