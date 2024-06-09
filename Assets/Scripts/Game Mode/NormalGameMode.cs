
using PencilGame;

public class NormalGameMode : GameMode
{
    public int level;
    protected override void Start()
    {
        base.Start();

        SceneTransitions("transition_start");
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    protected override void OnCounter(int counter)
    {
        if (counter == 0) Win();
        if (counter == 0) GameManager.Instance.IsWinnded();
    }

    public override void Win()
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

    public override void Lose()
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
