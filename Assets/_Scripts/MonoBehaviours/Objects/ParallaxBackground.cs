using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] Player player = null;
    [SerializeField] float offset = 0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(
            player.transform.position.x, 
            player.transform.position.y, 
            transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = player.transform.position.x - transform.position.x;
        if(distance > offset)
        {
            Vector3 velocity = Vector3.right;
            velocity *= player.Speed * Time.deltaTime;
            transform.position += velocity;
        }
    }
}
