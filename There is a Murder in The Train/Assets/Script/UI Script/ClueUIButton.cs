using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueUIButton : MonoBehaviour
{
    [SerializeField] private Clue dataClue;
    [SerializeField] ClueInfoManager infoManager;
    public void SetClue(Clue clue)
    {
        dataClue = clue;
    }
    public Clue GetClue()
    {
        return dataClue;
    }
    public void OnClicked()
    {
        infoManager.DisplayVisual(dataClue);
    }
}
