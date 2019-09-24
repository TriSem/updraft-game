using UnityEngine;

public class FauxProjection : MonoBehaviour
{
    [SerializeField] float nearZ = 0f;
    [SerializeField] float farZ = 100f;
    [SerializeField] float maxScale = 1f;
    [SerializeField] float minScale = 0.05f;


    void Update()
    {
        float z = transform.position.z;
        float scale = Mathf.Lerp(maxScale, minScale, (z - nearZ) / (farZ - nearZ));
        transform.localScale = Vector3.one * scale;
    }

    #if (UNITY_EDITOR)
    void OnDrawGizmos()
    {
        float z = transform.position.z;
        float scale = Mathf.Lerp(maxScale, minScale, z / farZ);
        transform.localScale = Vector3.one * scale;
    }
    #endif
}
