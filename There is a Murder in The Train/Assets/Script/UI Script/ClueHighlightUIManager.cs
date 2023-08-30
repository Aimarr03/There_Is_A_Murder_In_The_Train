using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ClueHighlightUIManager : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Transform ClueUITemplate;
    [SerializeField] private ClueInfoManager clueInfoManager;
    public void Start()
    {
        ClueUITemplate.gameObject.SetActive(false);
    }
    public void UpdateVisual()
    {
        List<Clue> currentClueList = ClueManager.instance.GetClueList();
        foreach (Transform child in container)
        {
            if (child == ClueUITemplate) continue;
            Destroy(child.gameObject);

        }
        foreach(Clue currentClue in currentClueList)
        {
            Transform ClueHighlight = Instantiate(ClueUITemplate, container);
            ClueHighlight.gameObject.SetActive(true);
            TextMeshProUGUI Clue_Highlight_text = ClueHighlight.Find("info").GetComponent<TextMeshProUGUI>();
            Clue_Highlight_text.text = currentClue.clueHighlight;
            ClueUIButton clueButton = ClueHighlight.GetComponent<ClueUIButton>();
            clueButton.enabled = true;
            clueButton.SetClue(currentClue);
        }
    }
    public void OnClueHighlightedClicked()
    {
        Debug.Log("Testing");
    }
}
