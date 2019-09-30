using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Tooltip("A shot will be spawned for each direction.")]
    [SerializeField] List<Vector3> shotDirections = null;

    [SerializeField] Transform projectile = null;

    [Tooltip("The amount of seconds in between spawns.")]
    [SerializeField] float spawnRate = 1f;

    [Tooltip("Determines how many units the prefabs are spawned away from the cannon.")]
    [SerializeField] float spawnDistance = 2f;

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
            Shoot();
            remainingCooldown = spawnRate;
        }
    }

    void Shoot()
    {
        foreach(var direction in shotDirections)
            {
                Transform instance = Instantiate(projectile, transform.position + direction * spawnDistance, Quaternion.identity);
                instance.transform.right = direction;
            }
    }
}
