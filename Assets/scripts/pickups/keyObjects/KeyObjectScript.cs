using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KeyObjectScript : PickupsS
{
    // Start is called before the first frame update
    private bool pickedup = false;

    private GameObject manager;
    void Start()
    {
        // set variables
        escc = GameObject.Find("esc");
        EscapeT = GameObject.Find("escape");
        manager = GameObject.Find("manager");
        // EscapeT.SetActive(false);
        // escc.SetActive(false);
    }

    // Update is called once per frame
    void Update() 
    {
        // check if this object is picked up
        if (pickedup == true)
        {
            //when true we wil start the keyfunction in the basescript
            base.keyObject();
            
            pickedup = false;
        //and set this object inactive
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // check if the object collide with the player
        if (other.gameObject.tag == "Player")
        {
            manager.GetComponent<PickupsS>().gotKey = true;
            pickedup = true;
            EscapeT.gameObject.GetComponent<Text>().text = "JE HEBT DE SLEUTEL GA TERUG NAAR JE SCHIP!";
        }
    }
}
 