using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] List<Vector3> shotDirections = null;
    [SerializeField] LinearMovement projectile = null;
    [SerializeField] float spawnRate = 1f;


    float remainingCooldown = 0f;

    void Start()
    {
        if(shotDirections.Count == 0)
            Debug.Log("'shotDirections' needs at least one element.");
    }

    void Update()
    {
        if(remainingCooldown > 0f)
        {
            remainingCooldown -= Time.deltaTime;
            remainingCooldown = Mathf.Max(0, remainingCooldown);
            return;
        }
        else
        {
            foreach(var direction in shotDirections)
            {
                LinearMovement instance = Instantiate(projectile, transform.position, Quaternion.identity);
                instance.transform.right = direction;
            }
            remainingCooldown = spawnRate;
        }
    }
}
