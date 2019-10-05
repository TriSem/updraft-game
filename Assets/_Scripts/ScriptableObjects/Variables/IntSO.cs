using UnityEngine;

// ScriptableObject wrapper around the int data type.
[CreateAssetMenu(menuName = "Assets/Numbers/Integer")]
public class IntSO : ScriptableObject
{
    public int value;
}
