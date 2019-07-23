using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboMeter : MonoBehaviour
{
    //[SerializeField] GameObject mascot;
    //[SerializeField] GameObject pickup;
    [SerializeField] IntSO comboIterator = null;
    [SerializeField] BoolSO lastPickupBool = null;

    // Start is called before the first frame update
    void Start()
    {
        comboIterator.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (lastPickupBool.value == true)
        {

            //Debug.Log(comboIterator.value);
        }
        else
        {
            comboIterator.value = 0;
            //Debug.Log(comboIterator.value);
        }
    }

}
