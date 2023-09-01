using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionScreen : MonoBehaviour
{
    [SerializeField] private Dialogue preDecision;
    [SerializeField] private List<GameObject> decisionButtons;
    [SerializeField] private GameObject backButton;
    void Start()
    {
            for (var i = 0; i < decisionButtons.Count; i++)
            {
                decisionButtons[i].SetActive(false);
            }
    }
    public void ShowButtons()
    {
        if(preDecision.dialogueDone)
        {
            for (var i = 0; i < decisionButtons.Count; i++)
            {
                decisionButtons[i].SetActive(true);
            }
        }
    }
    public void BackAway()
    {
        preDecision.dialogueDone = false;
    }
}
