using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance; // Singleton instance

    private Dictionary<string, Character> characterDictionary = new Dictionary<string, Character>();

    private void Awake()
    {
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
    public bool CheckCharacterInvolved(Character character)
    {
        return characterDictionary.ContainsKey(character.name);
    }
    public void AddCharacter(Character character)
    {
        if (!CheckCharacterInvolved(character))
        {
            characterDictionary.Add(character.characterName, character);
        }
    }

    public Character GetCharacter(string characterName)
    {
        if (characterDictionary.TryGetValue(characterName, out Character character))
        {
            return character;
        }
        return null; // Character not found
    }
}
