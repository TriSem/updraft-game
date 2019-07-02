using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class HomingMovement : LinearMovement
{
    [SerializeField] MascotPosition mascotPosition = null;
    [Range(0f, 1f)]
    [SerializeField] float lerpFactor = 0f;

    // Start is called before the first frame update
    void Start()
    {
        AlignToDirection();
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        AdjustTrajectory();
        Move();
    }

    // Will adjust it's trajectory towards the player.
    // Stops homing once it has passed them.
    void AdjustTrajectory()
    {
        var targetPositition = mascotPosition.Position;
        if(targetPositition.x > transform.position.x * Mathf.Sign(direction.x))
        {
            var towardsPlayer = targetPositition - transform.position;
            towardsPlayer.Normalize();
            direction.y = Vector3.Lerp(
                direction, 
                towardsPlayer, 
                lerpFactor).normalized.y;
        }
    }
}
