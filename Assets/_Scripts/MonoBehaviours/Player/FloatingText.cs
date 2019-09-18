using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    //public IntSO currentPoints = null;
    //public StringSO currentColor = null;

    //public GameObject pickupPrefab;
    [SerializeField] float destroyTime = 1f;
    [SerializeField] IntSO comboIterator = null;

    int points = 0;
    Animator anim;

    public int Points { get => points; set => points = value; }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("FloatingText");
        GetComponent<TextMesh>().text = comboIterator.value.ToString() + " X " +  points.ToString() ;
        Destroy(gameObject, destroyTime);
    }
}
