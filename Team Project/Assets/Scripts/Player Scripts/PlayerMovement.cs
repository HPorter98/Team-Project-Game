using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] public float movementSpeed = 2.0f;
    [SerializeField] public float speedMulitplier;

    [Header("Ability Settings")]
    [SerializeField] protected float cooldownTime;
    //private float nextUseTime = 0.0f;

    public Rigidbody2D rd2d;
    public bool isSprinting = false;

    Vector2 movement;
    public NewInputManager inputManager;

    private void Awake()
    {
        inputManager = new NewInputManager();
        inputManager.Player.Movement.performed += ctx => movement = ctx.ReadValue<Vector2>();
        //inputManager.Player.Skip_Scene.performed += _ => SkipScene();
        inputManager.Player.Attack.performed += _ => gameObject.GetComponent<PlayerManager>().Attack();
    }

    void OnEnable()
    {
        inputManager.Enable();
    }

    void OnDisable()
    {
        inputManager.Disable();
    }

    void FixedUpdate()
    {
        Move(movement);
        CalculateSpriteDirection(movement.x, movement.y);
        Debug.Log("X = " + movement.x + "," + "Y = " + movement.y);
    }

    void CalculateSpriteDirection(float x, float y)
    {
        if (x == 0 && y == 1)
        {//set sprite to face forward (default)
            transform.localEulerAngles = new Vector3(1, 1, 1);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(x == 0 && y == -1)
        {//set sprite to face backwards
            transform.localEulerAngles = new Vector3(1, 1, 1);
            transform.localScale = new Vector3(1, -1, 1);
        }
        else if(x == 1 && y == 0)
        {//Set sprite to face right
            transform.localEulerAngles = new Vector3(1, 1, -90);
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (x == -1 && y == 0)
        {//set sprite to face left
            transform.localEulerAngles = new Vector3(1, 1, 90);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    public void Move(Vector2 movement)
    {//move the character
        rd2d.MovePosition(rd2d.position + movement * movementSpeed * Time.deltaTime);
    }
}
