using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    //public IntSO currentPoints = null;
    //public StringSO currentColor = null;

    //public GameObject pickupPrefab;
    public float destroyTime = 1f;
    public string points;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("FloatingText");
        GetComponent<TextMesh>().text = points;
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showFloatingText()
    {
        
        //Debug.Log(currentColor.value + " " + currentPoints.value);
    }
}
