using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    [SerializeField] Vector3 direction = Vector3.zero;
    [SerializeField] float speed = 0f;

    [SerializeField] float gizmoLength = 4f;

    // Start is called before the first frame update
    void Start()
    {
        AlignToDirection();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnDrawGizmos()
    {
        AlignToDirection();
        Gizmos.DrawRay(transform.position, direction * gizmoLength);
    }

    void AlignToDirection() => transform.right = direction;
}
