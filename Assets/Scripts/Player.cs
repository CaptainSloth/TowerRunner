using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 5.0f;

    void Start()
    {
        _controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Direction to move (vec3)
        Vector3 direction = new Vector3(0, 0, 1);

        //Velocity = direction * speed
        Vector3 velocity = direction * _speed;

        //Move (vel * timeDelta)
        _controller.Move(velocity * Time.deltaTime);
    }
}
