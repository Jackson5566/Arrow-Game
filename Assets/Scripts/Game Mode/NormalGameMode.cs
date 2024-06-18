
public class NormalGameMode : GameMode
{
    public static int level;

    protected override void Start()
    {
        base.Start();
        Counter.Instance.counter += level;

        SceneTransitions("transition_start");
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    protected override void OnCounter(int counter)
    {
        if (counter == 0) OnWin();
    }

    public override void OnWin()
    {
        _isWinned = true;
        SceneTransitions();
        LoadNewLevel();
    }

    public void LoadNewLevel()
    {
        level += 1;
        Invoke("ResetScene", 1.5f);
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
        SceneTransitions();

        Invoke("ResetScene", 1.5f);
    }
}
