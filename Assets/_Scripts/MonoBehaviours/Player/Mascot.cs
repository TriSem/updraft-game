﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mascot : MonoBehaviour
{
    public GameEvent onDeath;

    [SerializeField] float fallSpeedFactor = 0f;
    [SerializeField] float fallingAirResistance = 0f;
    [SerializeField] float risingAirResistance = 0f;
    [SerializeField] float fallingTunnelAirResistance = 0f;
    [SerializeField] float risingTunnelAirResistance = 0f;

    [SerializeField] CustomBool isInTunnel = null;

    new Rigidbody rigidbody;


    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.X))
            Die();


        if(rigidbody.velocity.y < 0)
        {
            rigidbody.drag = isInTunnel.value ? fallingTunnelAirResistance : fallingAirResistance;
            rigidbody.velocity += fallSpeedFactor * Vector3.up * Time.deltaTime * Physics.gravity.y;
        }
        else
        {
            rigidbody.drag = isInTunnel.value ? risingTunnelAirResistance : risingAirResistance;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        int layer = collision.collider.gameObject.layer;
        if(LayerMask.LayerToName(layer).Equals("Hazard"))
            Die();
    }

    void Die()
    {
        onDeath.NotifyListeners();
    }
}
