using Throw.Core;
using UnityEngine;


public class MulticolorMovementGameMode : GameMode
{
    [SerializeField] private Oscilation _dianaOscilation;

    protected override void OnCollider(Transform obj)
    {
        player.counter.Rest();
    }

    protected override void OnNotCollider()
    {
        OnLose();
    }

    protected override void Start()
    {
        base.Start();
    }

    public override void OnLose()
    {
        base.OnLose();
    }

    public override void OnWin()
    {
        SaveLevel();
        LoadNextLevel();
    }

    protected override void OnCounter()
    {
        if (player.counter.score == 0) OnWin();

        if (player.counter.score == 5)
        {
            _dianaOscilation.speed *= 2;
        }
    }
}
