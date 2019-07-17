using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{

    GameObject player;
    NavMeshAgent enemy;

    // Use this for initialization
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.Log("Did u forgot to tag your player or FPS Controller");
        }


        enemy = GetComponent<NavMeshAgent>();


    }

    // Update is called once per frame
    void Update()
    {

        if (player != null)
            enemy.destination = player.transform.position;

    }
}