using UnityEngine;

public class PencilLogic : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pencil"))
        {
            _animator.SetTrigger("destroyed");
            GameMode.Instance.OnLose();
        }

        if (collision.gameObject.CompareTag("Diana"))
        {
            collision.gameObject.GetComponent<DianaLogic>().OnCollider();
            transform.SetParent(collision.transform);
            Destroy(GetComponent<PencilMovement>());
            Destroy(this);
        }
    }
}
