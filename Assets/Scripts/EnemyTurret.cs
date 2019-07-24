using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{
    private Transform target;

    [Header("Attributes")]
    public float range = 15f;
    public float fireRate = 1f; //1f = 1 shot per sec
    private float fireCountdown = 0f;

    [Header("Settings")]
    public float turnSpeed = 10f;
    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firePoint;

    void Start()
    {
        target = PlayerManager.instance.player.transform; //Pulls "Player" out of PlayerManager
        // InvokeRepeating("UpdateTarget", 0f, 0.5f); //Calls UpdateTarget 2x 1sec
    }

    //void UpdateTarget()
    //{
    //    float distanceToPlayer = Vector3.Distance(target.position, transform.position);
    //    if (distanceToPlayer <= range)
    //    {
    //        Debug.Log("Yo mofo I've found:" + target);
    //    }
    //}
    

    void Update()
    {
        //Target lock on
        Vector3 dir = target.position - transform.position;  //Direction
        Quaternion lookRotation = Quaternion.LookRotation(dir); //Look Direction
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles; //Converts to eulerangles
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f); //Sets rotation on y

        //Shooting
        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        Debug.Log("Turret go PEW!");
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<bullet>();

        if (bullet != null)
            Bullet.Seek(target);
    }

private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}

