using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ClueInfoManager : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Transform clueInfoTemplate;
    [SerializeField] private Transform clueImage;
    [SerializeField] private TextMeshProUGUI clueHighlight;

    // Start is called before the first frame update
    public void Start()
    {
        clueInfoTemplate.gameObject.SetActive(false);
    }
    public void DisplayVisual(Clue clue)
    {
        clueImage.gameObject.GetComponent<Image>().sprite = clue.clueImage;
        clueHighlight.text = clue.clueHighlight;
        List<string> clueInfo = clue.clueParagraphs;
        foreach(Transform child in container)
        {
            if (child == clueInfoTemplate) continue;
            Destroy(child.gameObject);
        }
        foreach(string currentLine in clueInfo)
        {
            Transform currentInfo = Instantiate(clueInfoTemplate, container);
            currentInfo.gameObject.SetActive(true);
            TextMeshProUGUI theInfo = currentInfo.GetComponent<TextMeshProUGUI>();
            theInfo.text = currentLine;
        }
    }
    public void ClearVisual()
    {
        clueImage.gameObject.GetComponent<Image>().sprite = null;
        clueHighlight.text = null;
        List<string> clueInfo = null;
        foreach (Transform child in container)
        {
            if (child == clueInfoTemplate) continue;
            Destroy(child.gameObject);
        }
    }
}
