using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float speed;
    private Vector3 _direction;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _direction = transform.forward*Input.GetAxisRaw("Vertical") + transform.right*Input.GetAxisRaw("Horizontal");
        _direction.Normalize();
    }

    private void FixedUpdate()
    {
        _rb.AddForce(_direction * speed);
    }
}
