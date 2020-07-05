using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemySpawn : MonoBehaviour
{
    public GameObject enemy;
    public List<GameObject> enemys = new List<GameObject>(); // list of enemy's
    bool finishedSpawning; // check is we are done spawning
    bool newWave = true; // when we need to spawn a new wave
    public GameObject[] spawnpoints; // array of spawnpoints
    private int pos;
    private int waves; // value of waves
    public int Score; // value of score
    private int ScoreE; // global score value
    public Text ScoreText; // text ellement for score
    public int rand; // this is the value of the keydrop
    public int currentSpawnAmount; // value of spawn ammount
    int state; // state of game survival or keysearch
    void Start()
    {
        //set variables
        state = PlayerPrefs.GetInt("raadsel", state);
        ScoreE = PlayerPrefs.GetInt("score", ScoreE);
        waves = Random.Range(1,3);
        //start spawning routine
        StartCoroutine(SpawnCoroutine());
        rand = Random.Range(0,6*waves);

    }
    private IEnumerator SpawnCoroutine()
    {
        finishedSpawning = false;
    // spawn 2 cicles of 5 monsters (we have 5 spawnpoints we wil cicle trough them twice) 
            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    pos++;
                // spawn enemy's on spawnpoints with 1 sec delay in between
                    GameObject g = Instantiate(enemy, new Vector3(spawnpoints[x].transform.position.x, spawnpoints[x].transform.position.y, spawnpoints[x].transform.position.z), Quaternion.identity) as GameObject;
                    enemys.Add(g);
                    //Wait for a second before continuing the for-loop
                    yield return new WaitForSeconds(1f);
                }
            }
        currentSpawnAmount = 9;

        // when the rand is inside the value of spawns we can get the component key from the enemy with that rand number
        if (rand <= currentSpawnAmount)
        {
            enemys[rand].GetComponent<enemy>().Key = true;
        }
      
        
            finishedSpawning = true; 
        }
       
    
    void Update()
    {
       //keep score updated
        Score = ScoreE;
        
        PlayerPrefs.SetInt("score", ScoreE);

        ScoreText.text = Score.ToString();
        // when all the enemy's are dead in this wave spawn new wave 
        if (enemys.Count == 0 && finishedSpawning == true && waves !=0)
        {
            Debug.Log("spawn new wave");
            if (state == 1)
            {
                waves--;
            }
            // when there are 10 dead rand - 10 
            rand = rand - 10;

            //restart spawn coroutine
            StartCoroutine(SpawnCoroutine()); 
            return;
        } 
        // when we kill an enemy up the score en set it again
        for (int i = 0; i< enemys.Count;i++)
        {
            if (enemys[i] == null)
            {
              
                enemys.Remove(enemys[i]);
                Score = ScoreE + 100;
                ScoreE = Score; 
                PlayerPrefs.SetInt("score", ScoreE);
                //Debug.Log("spawn new dead");
            }
           
        } 
    }
}
