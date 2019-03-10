using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    GameObject[] spawners;
    
    [Range(0f, 20f)]
    public int maxEnemiesInGame;
    private int minEnemiesInGame;
    [Range(0f, 19f)]
    public int spawnGap;

    public int IncEnemyGS { get; set; }

    void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        minEnemiesInGame = maxEnemiesInGame - spawnGap; // Set a little difrence between max & min
        PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        if(IncEnemyGS >= maxEnemiesInGame)
        {
            SetSpawnerActivation(false); // Stop spawning if, reached max
        }

        if (IncEnemyGS <= minEnemiesInGame)
        {
            SetSpawnerActivation(true); // Start spawning if reached min
        }
    }

    private void SetSpawnerActivation(bool status)
    {
        foreach (GameObject spwn in spawners)
        {
            spwn.GetComponent<Spawner>().enabled = status;
        }
    }
}
