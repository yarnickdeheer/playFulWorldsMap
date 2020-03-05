using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PickupsS : MonoBehaviour
{
    // Start is called before the first frame update
    protected int maxhealth;
    protected int currenthealth;
    protected int currenthealthE = 200;
    protected int health = 20;
    protected int damage =20;
    public RectTransform healthbar;

    public void Start()
    {
        health = 20;
        damage = 20;


         
        currenthealthE = PlayerPrefs.GetInt("health", currenthealthE);
        currenthealth = currenthealth + currenthealthE;
        Debug.Log(currenthealthE);
    }
    public virtual void keyObject()
    {
        currenthealthE = PlayerPrefs.GetInt("health", currenthealthE);
        Debug.Log("dit is een key my boy");
        Debug.Log(currenthealthE);
    }
    public virtual void trapObject()
    {
        currenthealthE = PlayerPrefs.GetInt("health", currenthealthE);
        currenthealth = currenthealthE - damage;
        currenthealthE = currenthealth;
        
        PlayerPrefs.SetInt("health", currenthealthE);


        Debug.Log("dit is een trap my boy");
        Debug.Log(currenthealthE);
    }
    public virtual void upgradeObject()
    {
        currenthealthE = PlayerPrefs.GetInt("health", currenthealthE);
        currenthealthE = currenthealthE + health;
     
        PlayerPrefs.SetInt("health", currenthealthE);


        Debug.Log("dit is een upgrade my boy");
        Debug.Log(currenthealthE);
    }
    // Update is called once per frame
    public virtual void Update()
    {
        currenthealthE = PlayerPrefs.GetInt("health", currenthealthE);
        healthbar.sizeDelta = new Vector2(currenthealthE,7.2f);

    }
 
}
