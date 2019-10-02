using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Updraft : MonoBehaviour
{
    BoxCollider windbox;
    float startingHeight;
    [SerializeField] BoolSO isInTunnel = null;

    [SerializeField] float windStrength = 0f;
    [SerializeField] float resizeSpeed = 0f;
    [SerializeField] float minHeight = 0f;
    [SerializeField] float maxHeight = 0f;

    // The minimum depth the mascot can fall into
    // the drift before downwards velocity is killed.
    [SerializeField] float minPenetrationRatio = 0f;
    
    // The maximum depth the mascot can fall into
    // the drift before downwards velocity is killed.
    [SerializeField] float maxPenetrationRatio = 0f;

     static float spacebarHeight = -0.5f;

    public float Height
    {
        get 
        {
            float upperBound = transform.position.y + 0.5f * windbox.bounds.size.y;
            float lowerBound = transform.position.y - 0.5f * windbox.bounds.size.y;
            return upperBound - lowerBound;
        }
    }

    void Awake()
    {
        windbox = GetComponent<BoxCollider>();
        startingHeight = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //AdjustSize();
        AdjustSizeWithSpace();
    }

    void OnTriggerStay(Collider other)
    {
        var rb = other.attachedRigidbody;
        if(rb.velocity.y < 0 && VelocityKilled(other.transform))
        {
            rb.velocity = Vector3.zero;
        }
        rb.AddForce(Vector3.up * windStrength, ForceMode.Force);
    }

    void OnTriggerEnter()
    {
        isInTunnel.value = true;
    }

    void OnTriggerExit()
    {
        isInTunnel.value = false;
    }
    void AdjustSize()
    {
        float nextScale = transform.localScale.y + 
            (Time.deltaTime * resizeSpeed * Input.GetAxisRaw("Vertical"));
        float nextHeight = Height * nextScale / transform.localScale.y;
        nextScale = Mathf.Clamp(nextScale, minHeight / (nextHeight / nextScale), maxHeight / (nextHeight / nextScale));
        transform.position = new Vector3(transform.position.x, startingHeight + nextScale - 1, transform.position.z);
        transform.localScale = new Vector3(transform.localScale.x, nextScale, transform.localScale.z);
    }

    // Velocity should be stopped before
    // the mascot completely falls through the drift.
    bool VelocityKilled(Transform t)
    {
         // The smaller the collider, the shallower the penetration gets.
        float lerpFactor = (Height - minHeight) / (maxHeight - minHeight);
        float penetrationRatio = 1 - Mathf.Lerp(minPenetrationRatio, maxPenetrationRatio, lerpFactor);
        float stopLine = windbox.bounds.min.y + Height * penetrationRatio;
        return t.position.y < stopLine;
    }

    void changeHeightWithSpace()
    {
        if (Input.GetKeyDown("space"))
        {
            spacebarHeight += 1f;
        }
        if (Input.GetKeyUp("space"))
        {
            spacebarHeight -= 1f;
        }
    }

    void AdjustSizeWithSpace()
    {
        changeHeightWithSpace();
        float nextScale = transform.localScale.y +
            (Time.deltaTime * resizeSpeed * spacebarHeight);
        float nextHeight = Height * nextScale / transform.localScale.y;
        nextScale = Mathf.Clamp(nextScale, minHeight / (nextHeight / nextScale), maxHeight / (nextHeight / nextScale));
        transform.position = new Vector3(transform.position.x, startingHeight + nextScale - 1, transform.position.z);
        transform.localScale = new Vector3(transform.localScale.x, nextScale, transform.localScale.z);
    }
}
