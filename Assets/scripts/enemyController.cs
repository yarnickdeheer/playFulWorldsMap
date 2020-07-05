using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{
     private Transform player;
    public GameObject enemy;
    private NavMeshAgent NavEnemy;
    private Transform speler;
    void Awake()
    {
        // set variables
        speler = GameObject.Find("Player").transform;
        NavEnemy = enemy.GetComponent<NavMeshAgent>();
        NavEnemy.SetDestination(GetDestination());
       
    }
    
    void Update()
    {
        // set direction of the enemy to player position
        Vector3 direction = enemy.transform.position - speler.position;
        direction.Normalize();
        NavEnemy.SetDestination(speler.position + (direction * 1)); 
    }

    public Vector3 GetDestination()
    { 
        // return player position
        return speler.position;
    }
   
} 
   