using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    // life variables
    private int Chealth;
    private int ScoreE;
    private int lifes;
    private int currenthealthE = 190;
    public Text lifeT;
    
    void Start()
    {
        // set the player with 5 lifes
        lifes = 5;
    }
    
    void Update()
    {
        // set ui text to ammount of lives
        lifeT.text = lifes.ToString();
        // check the health value and score
        Chealth = PlayerPrefs.GetInt("health", Chealth);
        ScoreE = PlayerPrefs.GetInt("score", ScoreE);
        //when health is 0
        if (Chealth <= 0)
        {
            // when you are out of lives decrease score and reset level
            if (lifes == 0)
            {
                PlayerPrefs.SetInt("health", currenthealthE);
                ScoreE = ScoreE - 250;
                PlayerPrefs.SetInt("score", ScoreE);
                Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
            }
            // remove 1 life
            else{
                lifes--;
                PlayerPrefs.SetInt("health", currenthealthE);
            }
            
        }
      
    }
}
