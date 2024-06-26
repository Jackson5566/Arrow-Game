using UnityEngine;
using System;

public class MulticolorPencilLogic : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private SpriteRenderer[] _spriteRenderers;

    private Skin _skin;
    public Skin skin { 
        get { return _skin; } 
        set {
            _skin = value;

            foreach (SpriteRenderer sp in _spriteRenderers)
            {
                sp.color = _skin.spriteColor;
            }
        }
    }

    public Counter counter;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!(collision.gameObject.tag == "Diana"))
        {
            _animator.SetTrigger("destroyed");
            Invoke("DestroyGameObject", 1.5f);
        }

        else
        {
            try
            {
                Color color = collision.gameObject.GetComponent<Chameleon>().skin.selectedColor;

                if (color == _skin.selectedColor)
                {
                    collision.gameObject.GetComponent<DianaMulticolorLogic>().OnCollider(transform);
                    transform.SetParent(collision.transform);
                    Destroy(gameObject);
                }
                else
                {
                    collision.gameObject.GetComponent<DianaMulticolorLogic>().Subsctract();
                    _animator.SetTrigger("destroyed");
                    Invoke("DestroyGameObject", 1.5f);
                }
            }

            catch (NullReferenceException ex)
            {
                Debug.LogError(ex);
            }
        }

        //if (collision.gameObject.CompareTag("Pencil"))
        //{
        //    GameManager.Instance.IsLose();
        //}

        //if (collision.gameObject.CompareTag("Diana"))
        //{
        //    Counter.Instance.Rest();
        //    Diana.Instance.ChangeDirection();
        //    transform.SetParent(collision.transform);
        //    Destroy(this);
        //}
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
