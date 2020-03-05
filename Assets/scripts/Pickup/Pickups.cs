using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
    public ScoreTracker scoretrack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "pickup")
        {
            Debug.Log("miep");
            coll.gameObject.SetActive(false);
            scoretrack.score++;
            
        }
    }
}
