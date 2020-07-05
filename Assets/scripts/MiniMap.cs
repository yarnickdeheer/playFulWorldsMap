using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    
    public GameObject player;
    private GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        //set cam variable
        cam = GameObject.FindGameObjectWithTag("minimap");
    }

    // Update is called once per frame
    void Update()
    {
        // transform the X and Y position to it stays above the player
        cam.transform.position = new Vector3(player.transform.position.x,cam.transform.position.y ,player.transform.position.z);
    }
}
    