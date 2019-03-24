using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawn : MonoBehaviour
{
    // breytur
    private float timer;
    private int count = 0;

    public GameObject enemyPrefab;
    private GameObject enemy;

    void Update()
    {

        timer += Time.deltaTime; // tekur tíman
        // ef timinn er meira en 10 sek eða þegar það er enginn afturganga og teljarinn er 0
        // og teljarinn er ekki jafnt og 5
        if ((timer > 10f || (enemy == null && count == 0)) && count != 5)
        {
            count += 1;
            // býr til klón af afturgöngu og byrtir hana á mapinu
            enemy = Instantiate(enemyPrefab) as GameObject; 
            enemy.transform.position = transform.position;

            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
            timer = 0f;
  
        }
    }
}

