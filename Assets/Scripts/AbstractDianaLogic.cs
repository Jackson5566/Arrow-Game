using PencilGame;
using System;
using UnityEngine;

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


    private void Start()
    {
        diana = GetComponent<Diana>();
    }

    public virtual void OnCollider(Transform obj)
    {
        onCollider(obj);

        if (_activeEffects)
            effects.InstantiateConfetti(obj.position);

        if (_changeDirection)
            diana.ChangeDirection();

    }

    public virtual void NotCollider()
    {
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
