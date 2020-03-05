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
        if (pickedup == true)
        {
            base.upgradeObject();
            pickedup = false;
            this.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            pickedup = true;
        }
    }
}
