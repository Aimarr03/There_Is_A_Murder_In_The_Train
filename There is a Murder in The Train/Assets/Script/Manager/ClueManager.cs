using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ClueManager : MonoBehaviour
{
    public Transform ClueButton;
    //[SerializeField] Transform ClueManagerUI;
    private List<Clue> ClueObtained = new List<Clue>();

    public static ClueManager instance;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void AddClue(List<Clue> clue)
    {
        foreach(Clue currentClue in clue) 
        {
            ClueObtained.Add(currentClue);
        }
    }
    public void checkClue()
    {
        foreach (Clue c in ClueObtained)
        {
            Debug.Log(c.clueHighlight);
            foreach(string line in c.clueParagraphs)
            {
                Debug.Log(line);
            }
        }
    }
    public List<Clue> GetClueList()
    {
        return ClueObtained;
    }
}
