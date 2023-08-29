using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManagerDialogue : MonoBehaviour
{
    public TextMeshProUGUI mainText;
    public TextMeshProUGUI NameText;

    private int sentenceIndex = -1;
    private SceneDialogue currentScene;
    private State state = State.COMPLETED;

    private enum State
    {
        PLAYING, COMPLETED
    }

    
    public void PlayScene(SceneDialogue scene)
    {
        currentScene = scene;
        sentenceIndex = -1;
        PlayNextSentence();
    }

    public void PlayNextSentence()
    {
        StartCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));
        NameText.text = currentScene.sentences[sentenceIndex].speaker.speakerName;
    }

    public bool IsCompleted()
    {
        return state == State.COMPLETED;
    }

    public bool IsLastSentence()
    {
        return sentenceIndex + 1 == currentScene.sentences.Count;
    }

    private IEnumerator TypeText(string text)
    {
        mainText.text = "";
        state = State.PLAYING;
        int wordIndex = 0;

        while (state != State.COMPLETED)
        {
            mainText.text += text[wordIndex];
            yield return new WaitForSeconds(0.02f);
            if(++wordIndex == text.Length)
            {
                state = State.COMPLETED;
                break;
            }
        }
    }
    public void FastForwardTypeText()
    {
        StopCoroutine(TypeText(currentScene.sentences[++sentenceIndex].text));
        mainText.text = currentScene.sentences[sentenceIndex].text;
    }
}
