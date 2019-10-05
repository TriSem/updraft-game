using UnityEngine;

// ScriptableObject wrapper around the string data type.
[CreateAssetMenu(menuName = "Assets/Variables/String")]
public class StringSO : ScriptableObject
{
    public string value;
}
