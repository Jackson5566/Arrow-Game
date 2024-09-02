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
            Invoke(nameof(DestroyGameObject), 1.5f);
        }

        else
        {

            Color color = Color.Blue;

            try
            {
                color = collision.gameObject.GetComponent<Chameleon>().skin.selectedColor;
            }

            catch
            {
                Debug.LogWarning("Chamaleon component is missing !!!");
            }

            if (color == _skin.selectedColor)
            {
                collision.gameObject.GetComponent<AbstractDianaLogic>().OnCollider(transform);
                transform.SetParent(collision.transform);
                Destroy(gameObject);
            }
            else
            {
                collision.gameObject.GetComponent<AbstractDianaLogic>().NotCollider();
                _animator.SetTrigger("destroyed");
                Invoke(nameof(DestroyGameObject), 1.5f);
            }
        }
    }

    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
