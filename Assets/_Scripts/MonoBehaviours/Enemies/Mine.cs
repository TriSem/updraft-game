using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
   new Rigidbody rigidbody;

    [SerializeField] float rotationSpeed;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Vector3 torque = Random.rotation.eulerAngles;
        rigidbody.AddTorque(torque);    
    }
}
