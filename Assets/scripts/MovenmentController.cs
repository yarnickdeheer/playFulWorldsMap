using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovenmentController : MonoBehaviour
{
    public float speed = 10.0f;
    private float FB;
    private float LR;
    public bool grounded;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        FB = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        LR = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(LR, 0, FB);
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            jump();
            grounded = false;
        }
    }
    void jump()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            grounded = true;
        }
    }
}
