using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    Transform target;
    public GameObject enemyPrefab;
    public int numberOfEnemies = 3;
    public float radius = 3f;

    void Start()
    {
        target = PlayerManager.instance.player.transform; //Pulls "Player" out of PlayerManager
        for (int i = 0; i < numberOfEnemies; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfEnemies;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            Vector3 pos = transform.position + new Vector3(x, 0, z);
            float angleDegrees = -angle * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
            // Instantiate(enemyPrefab, new Vector3(i * 2.0f, 0, 0), Quaternion.identity);
            Instantiate(enemyPrefab, pos, rot);
        }
    }

    void Update()
    {
        
    }
}
