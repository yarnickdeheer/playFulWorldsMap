    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject BulletSpawnPoint;
    public GameObject Bulletpre;


    public float speed;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    { 

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject Projectile = Instantiate(Bulletpre, BulletSpawnPoint.transform.position + new Vector3(0f, 0f, 0f), BulletSpawnPoint.transform.rotation) as GameObject;
 
            Projectile.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.up * speed);

        }
    }
}