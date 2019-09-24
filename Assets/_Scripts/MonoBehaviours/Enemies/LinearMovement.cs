﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 direction = Vector3.zero;
    [SerializeField] protected float speed = 0f;

    [SerializeField] protected float gizmoLength = 4f;
    [SerializeField] protected float pauseDistance = 0f;
    [SerializeField] protected float pauseTime = 0f;

    float remainingPause = 0f;
    float traveledDistance = 0f;

    void Start()
    {
        AlignToDirection();
    }

    void Update()
    {
        Move();
    }

    void OnDrawGizmos()
    {
        AlignToDirection();
        Gizmos.DrawRay(transform.position, direction * gizmoLength);
    }

    protected void AlignToDirection() => transform.right = direction;

    // Moves in a straight line.
    protected void Move()
    {
        if(remainingPause > 0)
        {
            remainingPause -= Time.deltaTime;
            remainingPause = Mathf.Max(0, remainingPause);
            return;
        }

        Vector3 velocity = direction.normalized * speed * Time.deltaTime;
        if(pauseDistance > 0)
        {
            traveledDistance += Vector3.Magnitude(velocity);
            if(traveledDistance >= pauseDistance)
            {
                remainingPause = pauseTime;
                traveledDistance = 0f;
            }
        }
        transform.position += direction.normalized * speed * Time.deltaTime;
    }
}
