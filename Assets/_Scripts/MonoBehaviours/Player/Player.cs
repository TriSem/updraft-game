using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    GameEventListener listener;

    [SerializeField] float speed = 3f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * speed * Time.deltaTime;
    }

    public void OnDeath()
    {
        transform.position = Vector3.zero;
    }
}
