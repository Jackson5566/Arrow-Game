using PencilGame;
using System;
using UnityEngine;

[DisallowMultipleComponent]
public class AbstractDianaLogic : MonoBehaviour
{
    private Diana diana;
    public PositiveText positiveText;

    public Effects effects;

    public event Action onNotCollider;
    public event Action<Transform> onCollider;


    // Configurations
    [SerializeField] private bool _activeEffects;
    [SerializeField] private bool _changeDirection;

    public Animator dianaAnimator;

    private void Start()
    {
        diana = GetComponent<Diana>();
    }

    public virtual void OnCollider(Transform obj)
    {
        if (onCollider != null) 
            onCollider(obj);

        if (_activeEffects)
            effects.InstantiateConfetti(obj.position);

        if (_changeDirection)
            diana.ChangeDirection();

    }

    public virtual void NotCollider()
    {
        if (onNotCollider != null)
            onNotCollider();
    }
}

//public class DianaMovementLogic : AbstractDianaLogic, IDiana
//{
//    private Diana diana;
//    public PositiveText positiveText;
//    public Effects effects;


//    private void Start()
//    {
//        diana = GetComponent<Diana>();
//    }

//    public override void OnCollider(Transform obj)
//    {
//        base.OnCollider(obj);
//        effects.InstantiateConfetti(obj.position);
//    }
//}
