using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float speed;

    [SerializeField] private Rigidbody2D _rb;

    private Vector2 _pos;

    public Vector2 pos
    {
        get { return _pos; }
        set
        {
            _pos = value;
            print(_pos);
            print(_pos.normalized);
        }
    }

    private void Start()
    {
        _rb  = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rb.velocity = _pos.normalized * speed;
    }

    private void FixedUpdate()
    {
    }
}
