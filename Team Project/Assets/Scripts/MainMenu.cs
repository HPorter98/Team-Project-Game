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
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    public void PlayGame(string characterName)
    {
        //Select the character and load it into the Game Manager
        gameManager.GetComponent<CharacterSelect>().SetCharacterName(characterName);

        //Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        //Quit the game
        Application.Quit();
    }

    public void SkipScene()
    {
        //Skip the current level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartScene()
    {
        //Respawn the player
        Player.GetComponent<PlayerManager>().Respawn();

        //Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartMenu()
    {
        //Find the active game manager and player within the scene
        GameObject gManager = GameObject.Find("GameManager");
        PlayerManager player = FindObjectOfType<PlayerManager>();

        //Reset Player stats
        player.ResetStats();

        //Destroy current Game Manager
        Destroy(gManager);

        //Load main menu
        SceneManager.LoadScene(0);
    }
}
