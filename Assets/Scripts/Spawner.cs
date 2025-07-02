using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;
    public float respawnTime = 2f;
    public int enemySpawnCount = 10;
    public GameController gamecontroller;

    private bool lastEnemySpawned = false;
    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    // Update is called once per frame
    void Update()
    {
        if(lastEnemySpawned&&FindObjectOfType<EnemyScript>()==null)
        {
            StartCoroutine(gamecontroller.LevelComplete());
        }
    }
    IEnumerator EnemySpawner()
    {
        for (int i = 0; i < enemySpawnCount; i++)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
        lastEnemySpawned=true;
    }
    void SpawnEnemy()
    {
        int randomValue = Random.Range(0, enemy.Length);
        int randomXpos = Random.Range(-3, 3);
        Instantiate(enemy[randomValue],new Vector2(randomXpos,transform.position.y),Quaternion.identity);
    }
}
