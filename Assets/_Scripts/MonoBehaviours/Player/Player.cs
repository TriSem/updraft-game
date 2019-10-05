using UnityEngine;

// Controls the unit of mascot and updraft.
public class Player : MonoBehaviour
{

    [SerializeField] float maxSpeed = 6f;
    [SerializeField] float minSpeed = 1f;
    [SerializeField] float startingSpeed = 3f;
    [SerializeField] float rateOfChange = 1f;

    public float Speed { get; private set; }

    void Start()
    {
        Speed = startingSpeed;    
    } 

    void Update()
    {
        ChangeSpeed();
        transform.position += Vector3.right * Speed * Time.deltaTime;
    }

    // Change speed at the rate of change.
    void ChangeSpeed()
    {
        float accelDirection = Input.GetAxisRaw("Horizontal");

        Speed += accelDirection * rateOfChange;
        Speed = Mathf.Clamp(Speed, minSpeed, maxSpeed);
    }
}
