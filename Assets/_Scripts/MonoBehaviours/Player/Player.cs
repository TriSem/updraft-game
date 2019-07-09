using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameEventListener listener;

    [SerializeField] float maxSpeed = 6f;
    [SerializeField] float minSpeed = 1f;
    [SerializeField] float startingSpeed = 3f;
    [SerializeField] float rateOfChange = 1f;

    public float Speed { get; private set; }

    void Start()
    {
        Speed = startingSpeed;    
    } 

    // Update is called once per frame
    void Update()
    {
        ChangeSpeed();
        transform.position += Vector3.right * Speed * Time.deltaTime;
    }


    void ChangeSpeed()
    {
        float accelDirection = Input.GetAxisRaw("Horizontal");

        Speed += accelDirection * rateOfChange;
        Speed = Mathf.Clamp(Speed, minSpeed, maxSpeed);
    }
}
