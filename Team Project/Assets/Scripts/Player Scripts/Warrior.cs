using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : PlayerMovement
{
    void Start()
    {
        
    }

    void Update()
    {
        CheckInput(); //Method from base class to check for user input

        if (Input.GetKeyDown("f"))
        {
            KeyPush();
        }
    }

    private void FixedUpdate()
    {
        Move(); //Method from base class to move
    }

    private void KeyPush()
    {//Testing method to develop ablities
        Debug.Log("F was pushed");
    }
}
