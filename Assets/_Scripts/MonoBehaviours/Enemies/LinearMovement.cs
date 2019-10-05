using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    [SerializeField] protected float speed = 0f;

    [SerializeField] protected float gizmoLength = 4f;
    [SerializeField] protected float pauseDistance = 0f;
    [SerializeField] protected float pauseTime = 0f;

    float remainingPause = 0f;
    float traveledDistance = 0f;

    void Update()
    {
        Move();
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.right * gizmoLength);
    }

    // Moves in a straight line. 
    // Pauses at certain intervals for a specified amount of time.
    protected void Move()
    {
        if(remainingPause > 0)
        {
            remainingPause -= Time.deltaTime;
            remainingPause = Mathf.Max(0, remainingPause);
            return;
        }

        Vector3 velocity = transform.right * speed * Time.deltaTime;
        if(pauseDistance > 0)
        {
            traveledDistance += Vector3.Magnitude(velocity);
            if(traveledDistance >= pauseDistance)
            {
                remainingPause = pauseTime;
                traveledDistance = 0f;
            }
        }
        transform.position += velocity;
    }
}
