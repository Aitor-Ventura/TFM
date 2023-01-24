using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D rigidbody;
    private Vector2 motionVector;
    
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.gravityScale = 0;
    }

    private void Update()
    {
        motionVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rigidbody.velocity = motionVector * _speed;
    }
}
