using UnityEngine;

public sealed class HomingMovement : LinearMovement
{
    [SerializeField] MascotPosition mascotPosition = null;

    [Tooltip("Determines how strongly the object will home in on its target.")]
    [Range(0f, 0.5f)][SerializeField] float steeringFactor = 0.05f;

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
                steeringFactor).normalized;
        }
    }
}
