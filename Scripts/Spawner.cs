using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;

    [Range(0f, 359f)]
    public float spawnDir;
    [Range(0f, 20f)]
    public float spawnRate;
    private float nextSpawn;

    private void Start()
    {
        transform.rotation = Quaternion.Euler(0f, spawnDir, 0f); // Set new dir
    }

    private void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            spawnRate = Random.Range(2f, spawnRate + 1f);
            SpawnEnemy();
        }   
    }

    private void SpawnEnemy()
    {
        //!!! Just in case you might want to check if ur child has something in front of it, so pause spawn
        Transform location = transform.GetChild(0); // Find the offset
        GameObject newEnemy = Instantiate(enemy, location.transform.position, transform.rotation);
        newEnemy.transform.parent = transform; // Set children under parent hierchy
        GameObject.FindGameObjectWithTag("Master").GetComponent<GameMaster>().IncEnemyGS++; // Increase enemy count

    }
}
