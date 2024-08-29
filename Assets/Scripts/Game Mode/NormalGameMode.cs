
using Throw.Core;
using UnityEngine;

public class NormalGameMode : GameMode
{
    public static int level;

    public int maxLevel;

    protected override void OnCollider(Transform obj)
    {
        player.counter.Rest();
    }

    protected override void OnNotCollider()
    {
    }

    protected override void Start()
    {
        base.Start();

        player.counter.score += level;
    }

    protected override void OnCounter()
    {
        if (player.counter.score == 0) OnWin();
    }

    public override void OnWin()
    {
        _isWinned = true;
        level += 1;

        if (level < maxLevel)
        {
            LoadNewLevel();
        }
        else
        {
            SceneLoader.Instance.LoadAsync("Main");
        }

    }

    public void LoadNewLevel()
    {
        Invoke(nameof(ResetScene), 1.5f);
    }


    public override void OnLose()
    {
        _isLose = true;
        level = 0;

        LoseTransition();
    }

    public void LoseTransition()
    {
        DeadAnimations();

        Invoke(nameof(ResetScene), 1.5f);
    }
}
