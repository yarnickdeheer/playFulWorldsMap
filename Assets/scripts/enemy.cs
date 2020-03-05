using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class enemy : MonoBehaviour

   
{
    private int health = 10;
    public TextMesh text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = health.ToString();
        if (health ==0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
      if(  collision.gameObject.tag == "bullet"){
            Debug.Log("auw");
            health--;
            Destroy(collision.gameObject);
        }
    }
}
