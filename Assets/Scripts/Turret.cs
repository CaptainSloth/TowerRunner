using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{

    public Transform target;
    public float range = 15f;



    // Start is called before the first frame update
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
            //Rotate Head
            //Fire
            Debug.Log(target);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
