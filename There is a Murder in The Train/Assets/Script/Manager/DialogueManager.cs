using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.InteropServices.WindowsRuntime;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private Dialogue currentDialogueScene;
    [SerializeField] private TextMeshProUGUI currentCharacterName;
    [SerializeField] private TextMeshProUGUI currentDialogue;
    [SerializeField] private RectTransform characterPanel;
    [SerializeField] private Image characterRenderer;
    [SerializeField] private Transform UIPanel;
    [SerializeField] private Button ContinueButton;

    private Dialogue.DialogueEntry currentDialogueEntry;
    public int indexConversation = -1;
    public int indexLine = -1;
    private bool done;

    public static DialogueManager instance;
    public void Awake()
    {
        ContinueButton.gameObject.SetActive(false);
        HideUI();
        // Singleton pattern to ensure only one instance exists
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

    public void ChangeDialog(Dialogue dialogue)
    {
        ShowUI();
        ContinueButton.gameObject.SetActive(true);
        ClueManager.instance.SetClueButtonVisibility(false);
        done = false;
        indexConversation = -1;
        currentDialogueScene = dialogue;
        currentDialogueScene.dialogueDone = false;
        Debug.Log(currentDialogueScene.ClueProvided());
        foreach(Character characterInvolved in currentDialogueScene.characterInvolved)
        {
            CharacterManager.instance.AddCharacter(characterInvolved);
        }
        PlayNextDialogue();
    }
    public void PlayNextDialogue()
    {
        if (!LastConversation())
        {
            indexLine = -1;
            currentDialogueEntry = currentDialogueScene.entries[indexConversation+1];
            Character currentCharacter = CharacterManager.instance.GetCharacter(currentDialogueEntry.speakerName);
            currentCharacterName.text = currentCharacter.characterName;
            Character.ExpressionData expressionData = currentCharacter.GetExpressionData(currentDialogueEntry.speakerExpression);
            characterRenderer.sprite = expressionData.expressionImage;
            PlayNextLine();
        }
    }
    public void IncremenetConversation()
    {
        ++indexConversation;
    }
    public bool LastLine()
    {
        bool lastLine = indexLine + 1 == currentDialogueEntry.speakerLines.Count;
        return lastLine;
    }
    public bool LastConversation()
    {
        bool lastConversation = indexConversation + 1 == currentDialogueScene.entries.Count;
        if (lastConversation) 
        {
            ContinueButton.gameObject.SetActive(false);
            done = lastConversation;
            currentDialogueScene.dialogueDone = lastConversation;
            HideUI();
            if (currentDialogueScene.necessaryDialogue)
            {
                GameManager.instance.currentNecessaryDialogueDone++;
            }
            if (currentDialogueScene.ClueProvided())
            {
                ClueManager.instance.AddClue(currentDialogueScene.clue);
            }
            if (GameManager.instance.CheckAllNecessaryDialogueDone())
            {
                GameManager.instance.LoadNextStorySegment();
            }
        }
        return lastConversation;
    }
    public void HideUI()
    {
        UIPanel.gameObject.SetActive(false);
    }
    public void ShowUI()
    {
        UIPanel.gameObject.SetActive(true);
    }
    public void PlayNextLine()
    {
        StartCoroutine(TypeSentence(currentDialogueEntry.speakerLines[++indexLine]));
    }
    IEnumerator TypeSentence(string sentence)
    {
        currentDialogue.text = "";
        int wordIndex = 0;
        while(wordIndex < sentence.Length)
        {
            currentDialogue.text += sentence[wordIndex];
            yield return new WaitForFixedUpdate();
            wordIndex++;
        }
    }
    public bool GetDoneCondition()
    {
        return done;
    }
    public void LeftMouseClicked()
    {
        //there's more dialog
        if (!LastConversation())
        {
            //not the end of the line
            if (!LastLine())
            {
                PlayNextLine();
            }
            else
            {
                IncremenetConversation();
                PlayNextDialogue();
            }
        }
        else
        {

        }
    }
}
