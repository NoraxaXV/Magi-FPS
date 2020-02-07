﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMover : MonoBehaviour
{
    public float speed = 10;
    public float rotationSpeed = 180;
    public float gravityMult = 5;
    public float jumpForce = 20;

    public Transform head;
    CharacterController controller;
   

    float jumpVelocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        //Moves the player based on the input
        var fowardInput = Input.GetAxis("Vertical");
        var strafeInput = Input.GetAxis("Horizontal");
        var rotateMovement = Input.GetAxis("Mouse X");
        var lookUpInput = -Input.GetAxis("Mouse Y");
        
        transform.Rotate(0,rotateMovement*Time.deltaTime*rotationSpeed, 0);
        head.Rotate(lookUpInput * rotationSpeed * Time.deltaTime,0,0);
        controller.Move(transform.forward * fowardInput * speed * Time.deltaTime);
        controller.Move(transform.right * strafeInput * speed * Time.deltaTime);

        //Jumping is handled by keeping track of a velocity that represents whether the player is falling or jumping
        controller.Move(transform.up * jumpVelocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && controller.isGrounded)
        {
            jumpVelocity = jumpForce;
        }
        else
        {
            jumpVelocity -= gravityMult;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}