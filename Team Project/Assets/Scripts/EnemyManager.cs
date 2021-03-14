using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] float attackDamage = 25f;

    public GameObject player;
    public GameObject startPos;

    Vector3 enemyPos;

    Vector3 triggerDistance = new Vector3(10, 10, 0);
    // Start is called before the first frame update
    CharacterController controller;
    void Start()
    {
        enemyPos = transform.position;
        gameObject.GetComponent<AIDestinationSetter>().target = null;

    }

    // Update is called once per frame
    void Update()
    {
        PlayerDetection();   
    }

    public float Attack()
    {
        Debug.Log("Attack!");

        return attackDamage;
    }

    public void PlayerDetection()
    {
        //if (Vector2.Distance(transform.position, player.transform.position) < 5f)
        //{
        //    gameObject.GetComponent<MeshRenderer>().enabled = true;
        //}
        if (Vector2.Distance(transform.position, player.transform.position) < 5f)
        {
            Debug.Log("Player Detected");
            gameObject.GetComponent<AIPath>().enabled = true;
            gameObject.GetComponent<AIDestinationSetter>().target = player.transform;
        }
        if (Vector2.Distance(transform.position, player.transform.position) > 5f && transform.position != enemyPos)
        {
            gameObject.GetComponent<AIDestinationSetter>().target = startPos.transform;
            if (Vector2.Distance(transform.position, startPos.transform.position) < 2f)
            {
                gameObject.GetComponent<AIPath>().enabled = false;
            }
        }
    }
}
