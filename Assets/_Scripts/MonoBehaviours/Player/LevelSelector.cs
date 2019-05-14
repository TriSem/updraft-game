using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    new Rigidbody rigidbody;

    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float turnSpeed = 1f;
    [SerializeField] GameEvent levelSelectedEvent = null;
    [SerializeField] BoolSO controlsEnabled;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Submit"))
        {
            levelSelectedEvent.NotifyListeners();
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        var direction = new Vector3(horizontalInput, 0f, verticalInput);
        direction.Normalize();

        Vector3 lookDirection = Vector3.RotateTowards(
            transform.forward, 
            direction, 
            turnSpeed * Time.deltaTime, 
            0f);

        var rotation = Quaternion.LookRotation(lookDirection);
        var targetPosition = transform.position + direction * moveSpeed * Time.deltaTime;
        rigidbody.MovePosition(targetPosition);
        rigidbody.MoveRotation(rotation);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(new Ray(transform.position, transform.forward));
    }
}


