using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newgun : MonoBehaviour
{
 
    public GameObject bullet;
    public Camera playerC;
    void Start()
    {

    }
    void Update()
    {
        // when the player hits the fire button(space) instantiate bullet
        if (Input.GetButtonUp("Fire1"))
        {
            GameObject bulletobject = Instantiate(bullet); // instantiate prefab
            bulletobject.transform.position = playerC.transform.position + playerC.transform.right; // set position of this prefab to the camera position and a bit to the right
            bulletobject.transform.forward = playerC.transform.forward; //set the bullet dirrection to the direction of the camera
        }
    }
       

    }

  