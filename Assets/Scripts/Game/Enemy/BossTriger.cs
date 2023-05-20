using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTriger : MonoBehaviour
{
    [SerializeField] private int enemyCount=10;
    [SerializeField] private Transform[] spawnLocations;
    [SerializeField] private GameObject[] enemies;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int randomSpawnIndex;
            int randomEnemyIndex;
            for(int i = 0; i < enemyCount; i++)
            {
                randomSpawnIndex = Random.Range(0, spawnLocations.Length-1);
                randomEnemyIndex = Random.Range(0, enemies.Length-1);
                Vector3 spawnLocation = new Vector3(spawnLocations[randomSpawnIndex].position.x, spawnLocations[randomSpawnIndex].position.y,0);
                GameObject enemy = Instantiate(enemies[randomEnemyIndex], spawnLocation, Quaternion.identity);
                enemy.GetComponent<AIChaseNoRot>().player = collision.gameObject;
            }

            Destroy(gameObject);
        }
    }
}
