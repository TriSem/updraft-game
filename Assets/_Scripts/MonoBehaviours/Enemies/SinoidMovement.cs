using UnityEngine;

public sealed class SinoidMovement : MonoBehaviour
{
    [SerializeField] Vector3 direction = Vector3.zero;
    [SerializeField] bool spiraling = false;
    [SerializeField] float amplitude = 1f;
    [SerializeField] float speed = 1f;

    Vector3 start;

    void Start()
    {
        direction.Normalize();
        transform.right = direction;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 linearDisplacement = direction * speed;
        Vector3 sinoidDisplacement = amplitude * Mathf.Sin(Time.time * speed) * transform.up ;
        if(spiraling)
            sinoidDisplacement += amplitude * Mathf.Cos(Time.time * speed) * transform.right;
        transform.position += (linearDisplacement + sinoidDisplacement) * Time.deltaTime;
    }
}
