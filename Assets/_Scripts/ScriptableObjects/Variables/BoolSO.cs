using UnityEngine;

// ScriptableObject wrapper around the bool data type.
[CreateAssetMenu(menuName = "Assets/Bool")]
public class BoolSO : ScriptableObject
{
    public bool value;
}
