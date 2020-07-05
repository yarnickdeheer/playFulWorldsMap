using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private GameObject bull;
   
    public GameObject parrent;
    public float speed;
    private void Start()

    {
        bull = this.gameObject;
        bull.transform.rotation = parrent.transform.rotation;
      

    }
    private void Update()
    {
         
       
     
       // bull.transform.localPosition = new Vector3(bull.transform.localPosition.x + speed, bull.transform.localPosition.y , bull.transform.localPosition.z);

    }
   // IEnumerator des()
   // {
    //    WaitForSeconds
    ///}
}
 