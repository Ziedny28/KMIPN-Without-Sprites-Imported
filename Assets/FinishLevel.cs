using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public AIChaseNoRot[] enemies;
    private bool enemiesIsFar=false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        CheckEnemyDistance();

        Debug.Log(enemiesIsFar);
        if (other.gameObject.CompareTag("Player") && enemiesIsFar)
        {
            //lanjut lv berikutny
            Debug.Log("Level Tamat");
        }
    }

    void CheckEnemyDistance()
    {
        foreach (AIChaseNoRot enemy in enemies)
        {
            
            enemiesIsFar = enemy.distance > enemy.distanceBetween? true: false;
            Debug.Log(enemiesIsFar );
            if (!enemiesIsFar)
            {
                return;
            } 
        }
    }
}
