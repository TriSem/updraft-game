using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RapidAttack : MonoBehaviour
{
    [Tooltip("Amount of time before the attacker charges.")]
    [SerializeField] float chargeTime = 3f;
    [SerializeField] float speed = 20f;
    [SerializeField] LineRenderer lineRenderer = null;

    float timePassed = 0f;
    Vector3 direction;

    void Awake()
    {
        if(lineRenderer == null)
            Debug.LogError("Forgot to set line renderer in editor.");
        lineRenderer.SetPosition(0, transform.position);
        direction = lineRenderer.GetPosition(1) - lineRenderer.GetPosition(0);
        direction.Normalize();
    }

    void Update()
    {
        if(timePassed < chargeTime)
        {
            float lerpFactor = timePassed / chargeTime;
            Color color = Color.Lerp(Color.cyan, Color.red, lerpFactor);
            color.a = Mathf.Lerp(0, 1, lerpFactor);
            lineRenderer.startColor = lineRenderer.endColor = color;
            timePassed += Time.deltaTime;
        }
        else
        {
            Move();
        }
    }

    void Move()
    {
        transform.position += direction * Time.deltaTime * speed;
    }

    void OnDrawGizmosSelected()
    {
        if(!Application.isPlaying)
            lineRenderer.SetPosition(0, transform.position);
    }
}
