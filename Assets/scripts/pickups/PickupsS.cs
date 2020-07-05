using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PickupsS : MonoBehaviour
{
    // this is my manager fsm manager for the pickups
    //health variables
    protected int maxhealth;
    protected int currenthealth;
    protected int currenthealthE = 200;
    protected int health = 20;
    public RectTransform healthbar;
    //damage variable
    protected int damage =20;
    //escape element objects
    public GameObject EscapeT;
    public GameObject escc;
    //bool for when you get the key
    public bool gotKey;
  
    public void Start()
    {
        //set variables
        gotKey = false;
        health = 20;
        damage = 20;
        EscapeT = GameObject.Find("escape");
        EscapeT.gameObject.GetComponent<Text>().text = "";
        currenthealthE = PlayerPrefs.GetInt("health", currenthealthE);
        currenthealth = currenthealth + currenthealthE;
      
    }

    // when the pickup is the key object
    public virtual void keyObject()
    {
        // activate UI ellements , et gotkey to true
        EscapeT.SetActive(true);
        gotKey = true;
        currenthealthE = PlayerPrefs.GetInt("health", currenthealthE);
        //Debug.Log("dit is een key my boy");
        
        
        Debug.Log(currenthealthE);
    }
    // when the pickup is the trap ellement
    public virtual void trapObject()
    {
        // get the health value and subtract the damage value after that set the health to current health
        currenthealthE = PlayerPrefs.GetInt("health", currenthealthE);
        currenthealth = currenthealthE - damage;
        currenthealthE = currenthealth;
        
        PlayerPrefs.SetInt("health", currenthealthE);


        Debug.Log("dit is een trap my boy");
        Debug.Log(currenthealthE);
    }
    //when the upgrade is the upgrade ellement 
    public virtual void upgradeObject()
    {
        // get the health value and add the health value after that set the health to current health
        currenthealthE = PlayerPrefs.GetInt("health", currenthealthE);
        
        currenthealthE = currenthealthE + health;
        if (currenthealthE > 190)
        {
            currenthealthE = 190;
        }
        PlayerPrefs.SetInt("health", currenthealthE);


        Debug.Log("dit is een upgrade my boy");
        Debug.Log(currenthealthE);
    }
    // Update is called once per frame
    public virtual void Update()
    {
        // update healthbar to the health value
        currenthealthE = PlayerPrefs.GetInt("health", currenthealthE);
        healthbar.sizeDelta = new Vector2(currenthealthE,healthbar.sizeDelta.y);

    }
 
}
