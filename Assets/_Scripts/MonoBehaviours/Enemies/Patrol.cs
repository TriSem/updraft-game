using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] List<Vector3> patrolPoints = null;
    [SerializeField] float speed = 1f;
    [SerializeField] float pauseTime = 0f;

    int nextPatrolPoint = 0;
    float remainingPause = 0f;

    Vector3 moveDirection = Vector3.zero;

    void Awake()
    {
        patrolPoints[0] = transform.position;
        if(patrolPoints.Count < 2)
            Debug.LogError("Needs at least two patrol points to move.");
        else
        {
            nextPatrolPoint = 1;
            UpdateMoveDirection();
        }
    }

    void Update()
    {
        if(remainingPause > 0f)
        {
            remainingPause -= Time.deltaTime;
            remainingPause = Mathf.Max(0, remainingPause);
        }
        else
        {
            Move();
        }
    }

    void Move()
    {
        transform.position += moveDirection * Time.deltaTime * speed;
        if(Vector3.SqrMagnitude(patrolPoints[nextPatrolPoint] - transform.position) < 0.01f)
        {
            remainingPause = pauseTime;
            nextPatrolPoint = (nextPatrolPoint + 1) % patrolPoints.Count;
            UpdateMoveDirection();
        }
    }

    void UpdateMoveDirection()
    {
        moveDirection = (patrolPoints[nextPatrolPoint] - transform.position).normalized;
    }
}
