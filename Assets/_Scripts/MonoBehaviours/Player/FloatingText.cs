using UnityEngine;

public class FloatingText : MonoBehaviour
{
    [SerializeField] float destroyTime = 1f;

    int points = 0;
    Color color = new Color();
    Animator anim;

    public int Points { get => points; set => points = value; }
    public Color Color { get => color; set => color = value; }


    void Start()
    {
        anim = GetComponent<Animator>();
        anim.Play("FloatingText");
        GetComponent<TextMesh>().color = Color;
        GetComponent<TextMesh>().text =  points.ToString() ;
        Destroy(gameObject, destroyTime);
    }
}
