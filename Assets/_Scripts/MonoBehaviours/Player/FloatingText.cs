using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    //public IntSO currentPoints = null;
    //public StringSO currentColor = null;

    //public GameObject pickupPrefab;
    [SerializeField] float destroyTime = 1f;
    [SerializeField] int points = 0;
    [SerializeField] IntSO comboIterator = null;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("FloatingText");
        GetComponent<TextMesh>().text = comboIterator.value.ToString() + " X " +  points.ToString() ;
        Destroy(gameObject, destroyTime);
    }
}
