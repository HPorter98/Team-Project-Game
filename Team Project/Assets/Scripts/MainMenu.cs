using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Player;
    public GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }
    public void PlayGame(string characterName)
    {
        gameManager.GetComponent<CharacterSelect>().SetCharacterName(characterName);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Click()
    {
        Debug.Log("Click");
    }

    public void SkipScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartScene()
    {
        Player.GetComponent<PlayerManager>().Respawn();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
