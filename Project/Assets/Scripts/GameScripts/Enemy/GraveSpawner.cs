using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveSpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] zombies;


    void Start()
    {
        
    }

   
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            int randEnemy = Random.Range(0, zombies.Length);
            int randspawnPoint = Random.Range(0, spawnPoints.Length);

            Instantiate(zombies[randEnemy], spawnPoints[randspawnPoint].position, transform.rotation);  
        }
    }
}
