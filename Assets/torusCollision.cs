using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torusCollision : MonoBehaviour
{

    public BoolSO firstHit = null;
    public IntSO points = null;

    // Start is called before the first frame update
    void Start()
    {
        firstHit.value = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (firstHit)
        {
            firstHit.value = false;
            Debug.Log("Torus Hit! Points=" + points.value);
        }
    }
}
