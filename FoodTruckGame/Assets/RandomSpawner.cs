using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    // public GameObject[] customerPrefabs;
    public GameObject customerPrefab;
    private Transform spawnPoint;

    public float spawnRangeStart = 3f;
    public float spawnRangeEnd = 6f;
    private float timeToSpawn;
    private float spawnTimer = 0f;

    void Start()
    {
        
    }

    //timer for spawning
    void FixedUpdate(){
        timeToSpawn = Random.Range(spawnRangeStart, spawnRangeEnd);
        spawnTimer += 0.0125f;
        if (spawnTimer >= timeToSpawn){
            spawnTree();
            spawnTimer = 0f;
        }
    }

    //tree spawner
    void spawnTree(){
        int SPnum = Random.Range(0, spawnPoints.Length - 1);
        spawnPoint = spawnPoints[SPnum];
        Instantiate(customerPrefab, spawnPoint.position, Quaternion.identity);
    }



    // void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         // int randCustomer = Random.Range(0, customerPrefab.Length);
    //         int randSpawnPoint = Random.Range(0, spawnPoints.Length);

    //         Instantiate(customerPrefab, spawnPoints[randSpawnPoint].position, transform.rotation);
    //     }
    // }
}
