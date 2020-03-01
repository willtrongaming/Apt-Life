using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NewPlayer))]
public class PlayerInput : Controller2D
{
    NewPlayer newPlayer;
    Controller2D controller;

    float jumpPressedMemory;
    float jumpBufferTime = 0.15f;

    float groundedMemory;
    //Old Value
    /*float groundedBufferTime = 0.155f;*/
    float groundedBufferTime = 0.132f;

    void Start()
    {
        newPlayer = GetComponent<NewPlayer>();
        controller = GetComponent<Controller2D>();
    }

    void Update()
    {
        Vector2 directionalInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        newPlayer.SetDirectionalInput(directionalInput);

        groundedMemory -= Time.deltaTime;
        if (controller.collisions.below)
        {
            groundedMemory = groundedBufferTime;
        }
        
        jumpPressedMemory -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressedMemory = jumpBufferTime;
            
            // bufferCounter = 0;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            newPlayer.OnJumpInputUp();
        }

        if ((jumpPressedMemory > 0) && (groundedMemory > 0))
        {
            jumpPressedMemory = 0;
            groundedMemory = 0;
            newPlayer.OnJumpInputDown();
        }
    }
}
