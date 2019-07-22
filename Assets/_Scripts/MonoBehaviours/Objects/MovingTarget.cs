using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;
    
    // Movement speed in units/sec.
    public float speed = 1.0F;

    public GameObject Target;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    public BoolSO firstHit = null;

    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
    }

    // Follows the target position like with a spring
    void Update()
    {
        //PingPongs the value between 0 and 1
        float pingPong = Mathf.PingPong(Time.time * speed, 1);
        // Set our position as a fraction of the distance between the markers. 
        Target.transform.position = Vector3.Lerp(startMarker.position, endMarker.position, pingPong);

        if (firstHit.value)
        {
            Destroy(this.gameObject);
        }
    }


}
