using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneManagerS : MonoBehaviour
{
    void Start()
    {
        //reset all player prefrences
        PlayerPrefs.DeleteAll();
    }
    void Update()
    {
        
    }
    //go to the first scene
    public void StartScene()
    {
        SceneManager.LoadScene("START");
    }
    // stop the game
    public void stopGame()
    {
        Application.Quit();
    }
}
