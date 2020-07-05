using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneVersionSelect : MonoBehaviour
{
    
    float time = 100;
    Text Ttext;
    int GameState;
    GameObject EscapeT;
    GameObject esc;
    public PickupsS manager;

    void Start()
    {
        //set variables
        esc = GameObject.Find("esc"); 
        esc.SetActive(false);
        Ttext = GameObject.Find("timer").GetComponent<Text>();
        GameState = PlayerPrefs.GetInt("raadsel", GameState);

        EscapeT = GameObject.Find("escape");
        if (GameState == 0) // we will get the game state what we saved while we selected a door when its 0 it was incorrect and the survival mode starts
        {
            Ttext.gameObject.SetActive(true);
            //survival
        }
        else{// we will get the game state what we saved while we selected a door when its 1 so its correct and the key based mode starts
            //keybased
            Ttext.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // when the state = 0  we wil set a timer that wil count down after that you can go back to the door room
        if (GameState == 0)
        {
            if (time <= 0)
            {

                esc.SetActive(true);
                time = 0;
                manager.gotKey = true;
                Ttext.gameObject.SetActive(false);
                EscapeT.gameObject.GetComponent<Text>().text = "JE HEBT HET OVERLEEFT GA TERUG NAAR JE SCHIP!";
            }
            else
            {
                time -= Time.deltaTime;
            }
            Ttext.text = time.ToString("0");
            //survival
        }
      
    }
}
