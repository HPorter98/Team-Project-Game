using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    // Start is called before the first frame update
    public string characterName;
    void Start()
    {
        //This game object stays alive while going between levels
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(characterName);
    }

    public void SetCharacterName(string character)
    {
        characterName = character;
    }

    public string GetCharacterName()
    {
        return characterName;
    }
}
