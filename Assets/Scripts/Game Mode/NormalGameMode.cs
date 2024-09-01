
using Throw.Core;
using UnityEngine;
using UnityEngine.AddressableAssets;

[DisallowMultipleComponent]
public class NormalGameMode : GameMode
{
    public static int level;

    public int maxLevel;

    [SerializeField] private AssetReference _destroyDianaParticle;

    protected override void OnCollider(Transform obj)
    {
        player.counter.Rest();
    }

    protected override void OnNotCollider() 
    {
        print("Perdio");
    }

    protected override void Start()
    {
        base.Start();

        player.counter.score += level * 2;

        if (player.counter.IsInitial())
        {
            level = 0;
        }
    }

    protected override void OnCounter()
    {
        if (player.counter.score == 0) OnWin();
    }

    public override void OnWin()
    {
        _isWinned = true;

        if (level < maxLevel)
        {
            Invoke(nameof(ResetScene), 1);
        }
        else
        {

            level = 0;
            SaveLevel();

            Invoke(nameof(LoadNextLevel), 1);
        }

        _dianaLogic.dianaAnimator.SetTrigger("dead");

        level += 1;
    }


    public override void OnLose()
    {
        base.OnLose();
        level = 0;
    }
}
