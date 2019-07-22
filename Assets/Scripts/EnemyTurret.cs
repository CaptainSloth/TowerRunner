using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    Transform target;
    public float range = 15f;
    public float turnSpeed = 10f;
    public Transform partToRotate;

    void Start()
    {
        target = PlayerManager.instance.player.transform; //Pulls "Player" out of PlayerManager
        InvokeRepeating("UpdateTarget", 0f, 0.5f); //Calls UpdateTarget 2x 1sec
    }

    void UpdateTarget()
    {
        float distanceToPlayer = Vector3.Distance(target.position, transform.position);
        if (distanceToPlayer <= range)
        {
            Debug.Log("Yo mofo I've found:" + target);
        }
    }

    void Update()
    {
        //Target lock on
        Vector3 dir = target.position - transform.position;  //Direction
        Quaternion lookRotation = Quaternion.LookRotation(dir); //Look Direction
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles; //Converts to eulerangles
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f); //Sets rotation on y
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
