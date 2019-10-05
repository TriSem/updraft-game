using UnityEngine;

// ScriptableObject wrapper around Vector3.
[CreateAssetMenu(menuName = "Assets/Numbers/Vector 3")]
public class Vec3SO : ScriptableObject
{
    [SerializeField] public Vector3 Value;
}
