using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    void FixedUpdate()
    {//Change camera position to follow the player
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }
}
