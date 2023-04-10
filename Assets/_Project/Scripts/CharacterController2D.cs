using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class CharacterController2D : MonoBehaviour
{
    public Vector2 lastMotionVector;
    
    [SerializeField] private float speed;
    
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private Vector2 _motionVector;
    private bool _isMoving;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        _motionVector = new Vector2(horizontal, vertical);

        if (horizontal != 0 || vertical != 0)
        {
            lastMotionVector = new Vector2(horizontal, vertical).normalized;
            
            _animator.SetFloat("lastHorizontal", horizontal);
            _animator.SetFloat("lastVertical", vertical);
        }
        
        _animator.SetFloat("horizontal", horizontal);
        _animator.SetFloat("vertical", vertical);
        
        _isMoving = horizontal != 0 || vertical != 0;
        _animator.SetBool("isMoving", _isMoving);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody.velocity = _motionVector * speed;
    }
}
