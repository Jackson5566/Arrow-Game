using PencilGame;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class GameMode : Service<GameMode>
{
    protected bool _isLose;
    public bool isLose
    {
        get { return _isLose; }
        set
        {
            _isLose = value;
            if (_isLose) OnLose();
        }
    }

    protected bool _isWinned;
    public bool isWinned
    {
        get { return _isWinned; }
        set
        {
            _isWinned = value;
            if (_isWinned) OnWin();
        }
    }

    [SerializeField] public Animator[] _deadAnimators;

    [SerializeField] public Animator[] _sceneTransitions;

    protected override void Awake()
    {
        base.Awake();
    }

    protected virtual void Start()
    {
        Counter.OnCounterChanged += OnCounter;
    }

    protected virtual void OnDestroy()
    {
        Counter.OnCounterChanged -= OnCounter;
    }

    protected abstract void OnCounter(int counter);
    public abstract void OnWin();
    public abstract void OnLose();

    protected void SceneTransitions(string trigger = "transition")
    {
        foreach (Animator animator in _sceneTransitions)
        {
            animator.SetTrigger(trigger);
        }
    }

    protected void DeadAnimations()
    {
        foreach (Animator animator in _deadAnimators)
        {
            animator.SetTrigger("dead");
        }
    }

    private void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
