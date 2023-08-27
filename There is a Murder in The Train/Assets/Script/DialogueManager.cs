using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> dialogueChat;
    [SerializeField] private TextMeshProUGUI characterName;
    [SerializeField] private TextMeshProUGUI characterChat;
    private AudioSource audioManager;
    public static DialogueManager Instance { get; private set; }
    // Start is called before the first frame update
    private void Awake()
    {
        audioManager = GetComponent<AudioSource>();
        Instance = this;
        dialogueChat = new Queue<string>();
    }
    void Start()
    {
        
        
    }

    // Update is called once per frame
    public void StartDialogue(Dialogue dialogue)
    {
        characterName.text = dialogue.name;
        dialogueChat.Clear();
        foreach(string sentence in dialogue.sentences)
        {
            dialogueChat.Enqueue(sentence);
        }
        DisplayDialogue();
    }
    public void DisplayDialogue()
    {
        characterChat.text = "";
        if(dialogueChat.Count == 0)
        {

            return;
        }
        audioManager.Play();
        string currentDialogue = dialogueChat.Dequeue();
        StartCoroutine(DisplaySentence(currentDialogue));
    }
    IEnumerator DisplaySentence(string currentSentence)
    {
        
        foreach(char character in currentSentence.ToCharArray())
        {
            characterChat.text += character;
            yield return new WaitForFixedUpdate();
        }
        audioManager.Stop();
    }
}
