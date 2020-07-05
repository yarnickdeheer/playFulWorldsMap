using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapObjectScript : PickupsS
{
    // Start is called before the first frame update
    private bool pickedup = false;
  //  public Health currenthealth;
   // private int damage;
    void Start()
    {
        // set damage value in base script 
        damage = 10;
    }

    // Update is called once per frame
    void Update()
    {
        // check if this object is picked up
        if (pickedup == true)
        {
            //when true we wil start the trap in the basescript
            base.trapObject();
            pickedup = false;
            this.gameObject.SetActive(false);

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        // check if the object collide with the player
        if (other.gameObject.tag == "Player")
        {
    
            pickedup = true;
        }
    }
}
