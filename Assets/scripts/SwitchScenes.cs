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
    public GameObject manager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // run displayUI function
        DisplayUI();

        // if trigger is true and the player presses E load next scene
        if (trig ==true && Input.GetKeyUp(KeyCode.E))
        {
            SceneManager.LoadScene(next);
        }
        
    }
    void DisplayUI()
    {
        // check if trig is true if so set ui element active
        if (trig == true)
        {
            doorUI.SetActive(true);

        } // if not deactivate UI ellement
        else if (trig == false)
        {
            doorUI.SetActive(false);
        }
    }
  
    private void OnTriggerEnter(Collider other)
    {

        // when the player is in the trigger of the object with tag respawn  go to this scene
        if (other.gameObject.tag == "Respawn" && manager.GetComponent<PickupsS>().gotKey == true)
        {
            Debug.Log("START");
            trig = true;
            next = "START";
        }
        // when the player is in the trigger of the object with tag voidelement  go to this scene
        if (other.gameObject.tag == "voidelement")
        {
            Debug.Log("void");
            trig = true;
            next ="void";
        }
        // when the player is in the trigger of the object with tag fireelement  go to this scene
        else if (other.gameObject.tag == "fireelement")
        {
            Debug.Log("fire");
            trig = true;
            next = "fire";
        }
        // when the player is in the trigger of the object with tag waterelement  go to this scene
        else if (other.gameObject.tag == "waterelement")
        {
            Debug.Log("water");
            trig = true;
            next= "water";
        }
        // when the player is in the trigger of the object with tag groundelement  go to this scene
        else if (other.gameObject.tag == "groundelement")
        {
            Debug.Log("ground");
            trig = true;
            next= "ground";
        }
    }
    // when you exit the triggers set trig false
    private void OnTriggerExit(Collider other)
    {
        trig = false;
    }

}
