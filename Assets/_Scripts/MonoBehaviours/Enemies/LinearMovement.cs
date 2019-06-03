using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 direction = Vector3.zero;
    [SerializeField] protected float speed = 0f;

    [SerializeField] protected float gizmoLength = 4f;

    // Start is called before the first frame update
    void Start()
    {
        AlignToDirection();
        direction.Normalize();
    }

    // Update is called once per frame
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
    protected void Move() => transform.position += direction * speed * Time.deltaTime;
    
}
