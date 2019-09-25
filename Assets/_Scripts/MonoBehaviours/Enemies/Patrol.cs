using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] List<Vector3> patrolPoints = null;
    [SerializeField] float speed = 1f;
    [Tooltip("The time that the object waits after it reaches a patrol point.")]
    [SerializeField] float pauseTime = 0f;

    [Tooltip("The color that the patrol path will be visualized in.")]
    [SerializeField] Color gizmoColor = Color.black;

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

    void OnDrawGizmosSelected()
    {
        patrolPoints[0] = transform.position;
        Gizmos.color = gizmoColor;
        for(int i = 0; i < patrolPoints.Count; i++)
        {
            Vector3 point = patrolPoints[i];
            Gizmos.DrawSphere(point, 0.2f);
            Gizmos.DrawLine(point, patrolPoints[(i + 1) % patrolPoints.Count]);
        }
    }
}
