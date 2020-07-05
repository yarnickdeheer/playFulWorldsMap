using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyS : MonoBehaviour
{
    protected int maxhealth;
    protected int currenthealth;
    protected int currenthealthE = 200;
    protected int health = 20;
    protected int damage = 20;
  //  public RectTransform healthbar;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public virtual void enemy1()
    {
        damage = 1;
        currenthealthE = PlayerPrefs.GetInt("health", currenthealthE);
        currenthealth = currenthealthE - damage;
        currenthealthE = currenthealth;
        PlayerPrefs.SetInt("health", currenthealthE);
    }
}
