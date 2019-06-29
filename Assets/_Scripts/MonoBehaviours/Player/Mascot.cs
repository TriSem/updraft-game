using System.Collections;
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

    [SerializeField] BoolSO isInTunnel = null;
    [SerializeField] MascotLocation location = null;

    new Rigidbody rigidbody;


    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        location.SetMascotPosition(this);
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

        location.SetMascotPosition(this);
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
