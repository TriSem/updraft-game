using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class HomingMovement : LinearMovement
{
    [SerializeField] MascotPosition mascotPosition = null;
    [Range(0f, 0.5f)]
    [SerializeField] float lerpFactor = 0f;

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
        if(targetPositition.x < transform.position.x)
        {
            var towardsPlayer = targetPositition - transform.position;
            towardsPlayer.Normalize();
            transform.right = Vector3.Lerp(
                transform.right, 
                towardsPlayer, 
                lerpFactor).normalized;
        }
    }
}
