using PencilGame;
using UnityEngine;

public class PencilLogic : MonoBehaviour
{
    public Counter counter;
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
            counter.Rest();
            //Diana.Instance.ChangeDirection();
            collision.gameObject.GetComponent<Diana>().ChangeDirection();
            transform.SetParent(collision.transform);
            Destroy(GetComponent<PencilMovement>());
            Destroy(this);
        }
    }
}
