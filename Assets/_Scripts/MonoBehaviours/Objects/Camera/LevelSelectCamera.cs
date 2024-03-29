﻿using UnityEngine;

public class LevelSelectCamera : MonoBehaviour
{
    [SerializeField] Transform target = null;
    [SerializeField] float offset = 0f;

    void Update()
    {
        var nextPosition = transform.position;
        nextPosition.x = target.position.x;
        nextPosition.y = target.position.y + Vector3.up.y * offset;
        nextPosition.z = target.position.z - Vector3.forward.z * offset;
        transform.position = nextPosition;
        //transform.LookAt(target);
    }
}
