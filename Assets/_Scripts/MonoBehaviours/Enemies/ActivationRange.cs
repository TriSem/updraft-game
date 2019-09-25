using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationRange : MonoBehaviour
{
    [SerializeField] Vector2 rectangleSize = new Vector2(10f, 10f); 
    [SerializeField] Vector2 offset = Vector2.zero;

    [SerializeField] Transform centerOfRange = null;

    void Update()
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if(IsInRectangle(child.position))
                child.gameObject.SetActive(true);
            else
                child.gameObject.SetActive(false);
        }
    }

    void OnDrawGizmos()
    {
        if(!centerOfRange)
        {
            Debug.LogError("No transform slotted in!");
        }
        Gizmos.color = Color.yellow;
        Vector3 center = centerOfRange.position + (Vector3) offset;
        Gizmos.DrawWireCube(center, rectangleSize);
    }

    bool IsInRectangle(Vector3 position)
    {
        Vector2 centerPoint = (Vector2) centerOfRange.position + offset;
        var origin = centerPoint - 0.5f * rectangleSize;
        
        if(position.x < origin.x)
            return false;
        else if(position.y < origin.y)
            return false;
        else if(position.x > origin.x + rectangleSize.x)
            return false;
        else if(position.y > origin.y + rectangleSize.y)
            return false;
        else
            return true;
    }
}
