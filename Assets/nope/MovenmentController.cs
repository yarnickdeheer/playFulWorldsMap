using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovenmentController : MonoBehaviour
{
    public float speed = 10.0f;
    public CharacterController ChController;
    private float FB;
    private float LR;
    public bool grounded;
    private float gravity = 9.87f;
    private float verticalSpeed = 0;


    public Transform cameraHolder;
    public float mouseSensitivity = 2f;
    public float upLimit = -50;
    public float downLimit = 50;
   

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        grounded = ChController.isGrounded;
        move();
        rotate();
        Debug.Log("is grounded "+ChController.isGrounded);
        //transform.Translate(LR, 0, FB);
        if (Input.GetKeyDown("escape")) 
        {
            Cursor.lockState = CursorLockMode.None;
        }
      
    }
    private void rotate()
    {
        float horizontalRotation = Input.GetAxis("Mouse X");
        float verticalRotation = Input.GetAxis("Mouse Y");

        transform.Rotate(0, horizontalRotation * mouseSensitivity, 0);
        cameraHolder.Rotate(-verticalRotation * mouseSensitivity, 0, 0);

        Vector3 currentRotation = cameraHolder.localEulerAngles;
        if (currentRotation.x > 180) currentRotation.x -= 360;
        currentRotation.x = Mathf.Clamp(currentRotation.x, upLimit, downLimit);
        cameraHolder.localRotation = Quaternion.Euler(currentRotation);
    }
    private void move()
    {
        FB = Input.GetAxis("Vertical");
        LR = Input.GetAxis("Horizontal");

       // if (ChController.isGrounded) verticalSpeed = 0; 
        //else verticalSpeed -= gravity * Time.deltaTime;
        Vector3 gravityMove = new Vector3(0, verticalSpeed, 0);



        Vector3 move = transform.forward * FB + transform.right * LR;


        ChController.Move(speed * Time.deltaTime * move + gravityMove * Time.deltaTime);
    } 
}
