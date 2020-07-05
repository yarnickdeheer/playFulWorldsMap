using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;


public class raadsels : MonoBehaviour
{
    public puzzles[] trickery; // 2 dimentional array for the "raadsels"
    public  Text Rtext; // text object were we will display the "raadsels"
    private int correction; //this is the value that we wil change if its the correct or false anwser
    private int Quest; //this is the number of "raadsel" we are one
    public GameObject[] doors; // array of possible doors
    private bool clicked; // extra security to only click ones for the quest increase
    // Start is called before the first frame update
    void Start()
    {
        
        clicked = false;
        correction = PlayerPrefs.GetInt("raadsel", correction); // creating the playerpref for correction
        Quest = PlayerPrefs.GetInt("PPQuest", Quest); // creating the playerpref for quest
        // when we are out of quest we will go back to he start menu
        if (Quest == trickery.Length)
        {
            Quest = 0; //put the quest number back to 0
            PlayerPrefs.SetInt("PPQuest", Quest); // setting the player pref to quest value
            SceneManager.LoadScene("startmenu"); // go back to startmenu scene
           
        }
        // setting the text to the string value of "raadsel"
        Rtext.text = trickery[Quest].texts;
       
    } 

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerStay(Collider colliders)
    {
        // loop to go trough the doors
        for (int i = 0; i < doors.Length; i++)
        { 
            //we check if we are colliding with the door and press E while we havent clicked yet
            if (doors[i].gameObject == colliders.gameObject && Input.GetKeyDown(KeyCode.E) && clicked == false)
            {

                clicked = true; // set clicked true
                // check if we have the correct anwser
                if (i == trickery[Quest].env) 
                {
                    // if so we will update the quest number en set correction to 1 we will also start the scene that is linked with this door
                    Quest++;
                    PlayerPrefs.SetInt("PPQuest", Quest);
                    Debug.Log("correcte deur");
                    correction = 1;
                    PlayerPrefs.SetInt("raadsel", correction);
                    SceneManager.LoadScene(doors[i].gameObject.name.ToString());
                }
                //if not we will go to the scene that is linked with the door but correction will be 0
                else {
                    Debug.Log("incorrecte deur");
                    correction = 0;
                    PlayerPrefs.SetInt("raadsel", correction);
                    SceneManager.LoadScene(doors[i].gameObject.name.ToString());
                }
               
            }

          
          
        }
    }
}
// a class with an array and an interger
// for the "raadsel" text and the correct door number
[Serializable]
public class puzzles
{
    public string texts;
    public int env;
}