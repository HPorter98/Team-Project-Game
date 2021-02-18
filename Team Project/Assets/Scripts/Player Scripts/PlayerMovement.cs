using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] protected float movementSpeed = 2.0f;
    [SerializeField] private float speedMulitplier;

    [Header("Ability Settings")]
    [SerializeField] protected float cooldownTime;
    private float nextUseTime = 0.0f;
    public Rigidbody2D rd2d;

    Vector2 movement;

    // Update is called once per frame
    void Update()
    {//check for user input
        CheckInput();
    }
    void FixedUpdate()
    {//move the character
        Move();
    }

    protected void CheckInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown("left shift"))
        {//Increase speed for a Sprint
            movementSpeed *= 1.5f;
        }
        else if (Input.GetKeyUp("left shift"))
        {//Decrease speed back to a walk
            movementSpeed /= 1.5f;
        }
        else if (Input.GetKeyDown("space"))
        {//Press space for a dash
            if (Time.time > nextUseTime)
            {//If it is not on cooldown
                if (movement.x == 1)
                {
                    rd2d.position = new Vector3(transform.position.x + 5.0f, transform.position.y + 0);
                    nextUseTime = Time.time + cooldownTime;
                }
                else if (movement.x == -1)
                {
                    rd2d.position = new Vector3(transform.position.x + -5.0f, transform.position.y + 0);
                    nextUseTime = Time.time + cooldownTime;
                }
                Debug.Log("Cooldown started");
            }
            else if (Time.time < nextUseTime)
            {//If it is on cooldown
                Debug.Log("Cooldown active");
            }
        }
    }

    protected void Move()
    {
        rd2d.MovePosition(rd2d.position + movement.normalized * movementSpeed * Time.deltaTime);
    }
}
