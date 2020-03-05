using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapObjectScript : PickupsS
{
    // Start is called before the first frame update
    private bool pickedup = false;
  //  public Health currenthealth;
    private int damage;
    void Start()
    {
        damage = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedup == true)
        {
            base.trapObject();
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
