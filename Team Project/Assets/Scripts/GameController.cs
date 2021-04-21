using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameController : MonoBehaviour
{
    string playerName;
    public GameObject playerPrefab;
    public CinemachineVirtualCamera camera;
    public void Awake()
    {
        Application.targetFrameRate = 60;
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        //spawn position of player
        Vector2 startPos = new Vector2(0, 0);


        //find game manager
        GameObject gameManager = GameObject.Find("GameManager");

        //get character type from character select script
        playerName = gameManager.GetComponent<CharacterSelect>().GetCharacterName();
        if (playerName == "Warrior")
        {
            Instantiate(playerPrefab, this.transform);
            camera.Follow = GetComponentInChildren<Warrior>().transform;

        }
    }
}
