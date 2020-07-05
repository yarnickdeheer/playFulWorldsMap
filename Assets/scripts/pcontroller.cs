using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pcontroller : MonoBehaviour
{
    //variable for movement
    public float moveSpeed = 3.5f; 
    public float vert, hor;
    public Rigidbody rb;

    //Variable for ground
    private bool isGrounded;
    // variables for camera rotation
    public Transform cameraHolder;
    public float mouseSensitivity = 2f;
    public float upLimit = -50;
    public float downLimit = 50;


    private void Awake()
    {
        
        rb = GetComponent<Rigidbody>(); // set rb

        Cursor.visible = false; // this wil make your cursor invisible
        Cursor.lockState = CursorLockMode.Locked; // this will lock your mouse to the middle of the screen
    }
    
    private void Update()
    {
        rotate(); // start rotate function
        vert = Input.GetAxis("Vertical"); // set vert to verticle axis value
        hor = Input.GetAxis("Horizontal");// set hor to horizontal axis value

        //set move direction
        Vector3 moveDir = vert * transform.forward + hor * transform.right;
        // move the player
        rb.MovePosition(transform.position + moveDir * Time.deltaTime * moveSpeed);
        
        // check if the player hits the ground for possible jump 
        if (isGrounded == true)
        {
            moveSpeed = 21;
        }

    }
    private void rotate()
    {

        float horizontalRotation = Input.GetAxis("Mouse X");// set horizontalRotation to X axis value
        float verticalRotation = Input.GetAxis("Mouse Y");// set verticalRotation to Y axis value

        transform.Rotate(0, horizontalRotation * mouseSensitivity, 0);
        cameraHolder.Rotate(-verticalRotation * mouseSensitivity, 0, 0);

        Vector3 currentRotation = cameraHolder.localEulerAngles;
        if (currentRotation.x > 180) currentRotation.x -= 360;
        currentRotation.x = Mathf.Clamp(currentRotation.x, upLimit, downLimit);
        cameraHolder.localRotation = Quaternion.Euler(currentRotation);
    }


    private void OnCollisionEnter(Collision collision)
    {
        // when colliding with groubd set grounded true
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = true;
        }
    }
    
 
    private void OnCollisionExit(Collision collision)
    {
        // when not colliding with groubd set grounded false
        if (collision.gameObject.tag == "ground")
        {
            isGrounded = false;
        }
    }




}