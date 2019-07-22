using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{

    Transform target; //target data from GameManager (PlayerManager Script)
    public float e_RotSpeed = 3.0f;
    public float e_MoveSpeed = 3.0f;

    public float lookRadius = 10f;

    void Start()
    {
        target = PlayerManager.instance.player.transform; //Pulls "Player" out of PlayerManager
    }

    void Update()
    {
        /* Look at Player */ 
        /* O.O */
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), e_RotSpeed * Time.deltaTime);

        /* Move Towards Player*/
        /* >.< */
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            transform.position += transform.forward * e_MoveSpeed * Time.deltaTime;
            Debug.Log("Found:" + target);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}