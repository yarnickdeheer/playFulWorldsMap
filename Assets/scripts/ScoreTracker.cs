using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    // Start is called before the first frame update
    public int score;
    public Text VisScore;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VisScore.text = score.ToString();
    }
}
