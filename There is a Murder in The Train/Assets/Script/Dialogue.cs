using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    public string name;
    [TextArea(3,7)]
    public string[] sentences;
    public void setSentences(string[] sentences)
    {
        this.sentences = null;
        int position = 0;
        foreach (string sentence in sentences)
        {
            this.sentences[position] = sentence;
            position++;
        }
    }
    public void setName(string name)
    {
        this.name = name;
    }
}
