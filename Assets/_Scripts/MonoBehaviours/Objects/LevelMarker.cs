using UnityEngine;

public class LevelMarker : MonoBehaviour
{
    [SerializeField] StringSO selectedLevelDesignation = null; 

    [SerializeField] string designation = "";

    void OnTriggerEnter()
    {
        selectedLevelDesignation.value = designation;
    }

    void OnTriggerExit()
    {
        selectedLevelDesignation.value = "";
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
}
