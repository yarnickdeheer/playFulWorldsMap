using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class enemy : enemyS
{
    [SerializeField] Vector3 Enemypos;
    [SerializeField] Vector3 EnemyRot; 
    private int enemyHealth = 10;
    private enemySpawn spawn;
    public bool col;
    public GameObject bar;
    public float Dbar;
    public TextMesh text;
    public GameObject[] drops;
    int state;
    public bool Key;
    // Start is called before the first frame update
    void Start()
    {
        //set variables
        state = PlayerPrefs.GetInt("raadsel", state);
        spawn = GameObject.Find("manager").GetComponent<enemySpawn>();
        Dbar = bar.transform.localScale.x / enemyHealth;
    }

    // Update is called once per frame
    void Update()
    {
     // check if coll is true
        if (col == true)
        {
            // when it is true start enemy function from base script
            base.enemy1();
            col = false;
        }

        //set text to the enemy health value
        text.text = enemyHealth.ToString();
        //when enemy health is 0 check if we drop anything
        if (enemyHealth == 0)
        {
            //set a random value from 1 to 10
            int r = Random.Range(0, 10);
            // when Key is true and the state is in key based mode drop a key object after destroy the enemy
              if (Key == true && state ==1)
            {
                // instantiate the drop on current enemy position
                GameObject drop = Instantiate(drops[2], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity) as GameObject;
                ///Key = true;
                Debug.Log("level complete");
                //destroy enemy
                Destroy(gameObject);
            }
             
            else if (r ==0 && r < 2)
            {
                //drop a trap object
                GameObject drop = Instantiate(drops[0], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity) as GameObject;

                Destroy(gameObject);
            }
            else if (r > 3 && r < 5)
            {
                // drop an upograde object
                GameObject drop = Instantiate(drops[1], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity) as GameObject;

                Destroy(gameObject);
            }
          
           
            else
            {
                // dont drop anything and just destroy the enemy
                Destroy(gameObject);
            }

        }
    }
    //this is so the enemy'w wont pust the player
    private void OnTriggerStay(Collider collision)
    {
        // when they are colliding with the player set col true and speed to 0
        if (collision.gameObject.tag == "Player")
        {
            col = true;
            this.gameObject.GetComponent<NavMeshAgent>().speed = 0f;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        // if they are no longer colliding set speed to 10
        if (collision.gameObject.tag == "Player")
        {
            
            this.gameObject.GetComponent<NavMeshAgent>().speed = 10f;
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        // if the enemy collids with bullets decrease health and translate that to there healthbar
      if(  collision.gameObject.tag == "bullet"){
            //Debug.Log("auw");
            enemyHealth--;
            bar.transform.localScale = new Vector3 (bar.transform.localScale.x - Dbar, bar.transform.localScale.y, bar.transform.localScale.z);
            // detroy bullet
            Destroy(collision.gameObject);
        }
     
    }
}
