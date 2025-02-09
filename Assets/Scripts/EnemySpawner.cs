using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval=2;
    public int enemyCount=1;
    public int enemyCountIncreaseInterval = 15;
    public float enemySpeed = 0.3f;
    public float enemySpeedMultiplier = 0.1f;
    public float minimumSpawnInterval = 0.6f;
    public int enemySpeedIncreaseFreq = 5;
    public int spawnIntervalIncreaseFreq = 10;
    int currentRound = 0; //counts how many times an enemy has been spawned
    float timer=0;
    Transform player;
    Transform disc;
    [Header("Spawn Positions")]
    public List<Transform> relativeSpawnPoints; //a list to store all the relative spawn points of enemies

    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        disc = FindObjectOfType<Disc>().transform;
    }

    void SpawnEnemy()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            //instantiate enemy as child of disc (so it will rotate accordingly)
            //GameObject newEnemy = Instantiate(enemyPrefab, player.position + relativeSpawnPoints[Random.Range(0, relativeSpawnPoints.Count)].position, Quaternion.identity, disc);
            GameObject newEnemy = Instantiate(enemyPrefab, relativeSpawnPoints[Random.Range(0, relativeSpawnPoints.Count)].position, Quaternion.identity, disc);
            newEnemy.GetComponent<Enemy>().speed = (Random.Range(0.3f, enemySpeed));
            //Debug.Log(newEnemy.GetComponent<Enemy>().speed);
        }
    }
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>=spawnInterval)
        {
            timer = 0;
            currentRound++;
            SpawnEnemy();
            //every 5 enemies, increase enemy speed
            if (currentRound > 0 && currentRound % enemySpeedIncreaseFreq == 0)
            {
                enemySpeed += enemySpeedMultiplier;
            }
            //every 10 enemies, reduce how long it takes to spawn enemies
            if (currentRound > 0 && currentRound % spawnIntervalIncreaseFreq == 0)
            {
                spawnInterval -= enemySpeedMultiplier;
                if (spawnInterval < minimumSpawnInterval)
                    spawnInterval = minimumSpawnInterval;
                Debug.Log("spawn interval has been reduced to " + spawnInterval);

            }
            if (currentRound > 0&&currentRound % enemyCountIncreaseInterval == 0)
            {
                enemyCount++;
            }
        }
    }
}
