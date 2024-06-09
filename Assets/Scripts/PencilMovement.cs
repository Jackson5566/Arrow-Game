using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PencilMovement : MonoBehaviour
{
    public float speed;

    [SerializeField] private Rigidbody2D _rb;

    private void Start()
    {
        _rb  = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(transform.position + Vector3.up * speed * Time.fixedDeltaTime);
    }
}
