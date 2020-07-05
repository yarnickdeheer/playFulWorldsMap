using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeObjectScript : PickupsS
{
    // Start is called before the first frame update
    private bool pickedup = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // check if this object is picked up
        if (pickedup == true)
        {
            //when true we wil start the upgrade in the basescript
            base.upgradeObject();
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
