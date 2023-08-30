using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ClueUIManager : MonoBehaviour
{
    [SerializeField] GameObject ClueManagerUI;
    [SerializeField] ClueHighlightUIManager clueHighlightUI;
    public bool isClueManagerUIOpen = false;
    public void Start()
    {
        CloseUI();
    }
    public void ToggleUI()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if(isClueManagerUIOpen)
            {
                CloseUI();
            }
            else
            {
                OpenUI();
            }
        }
    }
    public void OpenUI()
    {
        Debug.Log("Testing");
        isClueManagerUIOpen=true;
        clueHighlightUI.UpdateVisual();
        ClueManagerUI.SetActive(true);
    }
    public void CloseUI()
    {
        isClueManagerUIOpen=false;
        ClueManagerUI.SetActive(false);
    }
}
