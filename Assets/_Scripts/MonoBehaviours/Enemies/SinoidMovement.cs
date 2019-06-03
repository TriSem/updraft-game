﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SinoidMovement : MonoBehaviour
{
    [SerializeField] Vector3 direction = Vector3.zero;
    [SerializeField] float amplitude = 1f;
    [SerializeField] float frequency = 1f;  
    [SerializeField] float speed = 1f;

    Vector3 start;

    void Start()
    {
        direction.Normalize();
        transform.right = direction;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 linearDisplacement = direction * speed;
        Vector3 sinoidDisplacement = amplitude * Mathf.Sin(Time.time * frequency) * transform.up;
        transform.position += (linearDisplacement + sinoidDisplacement) * Time.deltaTime;
    }
}
