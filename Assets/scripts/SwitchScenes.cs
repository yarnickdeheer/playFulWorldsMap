using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private bool trig;
    public GameObject doorUI;
    private string next;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DisplayUI();
        if (trig ==true && Input.GetKeyUp(KeyCode.E))
        {
            SceneManager.LoadScene(next);
        }
        
    }
    void DisplayUI()
    {
        if (trig == true)
        {
            doorUI.SetActive(true);
        }else if (trig == false)
        {
            doorUI.SetActive(false);
        }
    }
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "voidelement")
        {
            Debug.Log("void");
            trig = true;
            next ="void";
        }
        if (other.gameObject.tag == "Respawn")
        {
            Debug.Log("START");
            trig = true;
            next = "START";
        }
        if (other.gameObject.tag == "fireelement")
        {
            Debug.Log("fire");
            trig = true;
            next = "fire";
        }
        if (other.gameObject.tag == "waterelement")
        {
            Debug.Log("water");
            trig = true;
            next= "water";
        }
        if (other.gameObject.tag == "groundelement")
        {
            Debug.Log("ground");
            trig = true;
            next= "ground";
        }
    }
    private void OnTriggerExit(Collider other)
    {
        trig = false;
    }

}
