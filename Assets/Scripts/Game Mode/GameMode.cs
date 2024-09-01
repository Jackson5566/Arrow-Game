using PencilGame;
using Throw.Core;
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

    [SerializeField] protected AbstractDianaLogic _dianaLogic;
    public Player player;

    public string gameName;

    public int currentLevel;
    [SerializeField] protected bool _isFinalLevel;

    private void OnEnable()
    {
        _dianaLogic.onCollider += OnCollider;
        _dianaLogic.onNotCollider += OnNotCollider;
    }

    private void OnDisable()
    {
        _dianaLogic.onCollider -= OnCollider;
        _dianaLogic.onNotCollider -= OnNotCollider;
    }

    protected override void Awake()
    {
        base.Awake();
    }

    protected virtual void Start()
    {
        DataStorage.SaveGameName(gameName);
        Counter.OnCounterChanged += OnCounter;
    }

    protected virtual void OnDestroy()
    {
        Counter.OnCounterChanged -= OnCounter;
    }

    protected abstract void OnCounter();
    public abstract void OnWin();
    public virtual void OnLose()
    {
        _isLose = true;
        DeadAnimations();
        Invoke(nameof(ResetScene), 1);
    }
    protected abstract void OnCollider(Transform obj);
    protected abstract void OnNotCollider();

    //public abstract void OnPencilCollider();
    //public abstract void OnPencilNotCollider();

    protected void SceneTransitions(string trigger = "transition")
    {
        foreach (Animator animator in _sceneTransitions)
        {
            animator.SetTrigger(trigger);
        }
    }

    protected void DeadAnimations()
    {
        _dianaLogic.GetComponent<Animator>().SetTrigger("dead");
        Camera.main.GetComponent<Animator>().SetTrigger("dead");
    }

    protected void ResetScene()
    {
        SceneLoader.Instance.LoadAsync(SceneManager.GetActiveScene().name);
    }

    public void LoadNextLevel()
    {
        try
        {
            if (!_isFinalLevel)
                LoadLevel($"{TCache.levelBlock.name} {currentLevel + 1}");

            else
            {
                LoadLevel("Main");
            }
        }

        catch
        {
            Debug.LogWarning("Doesn't have next level");
        }
    }

    public void LoadLevel(string sceneName)
    {
        SceneLoader.Instance.LoadAsync(sceneName);
    }

    public void SaveLevel()
    {
        if (PlayerPrefs.GetInt(TCache.levelBlock.storageRoute) < currentLevel)
        {
            PlayerPrefs.SetInt(TCache.levelBlock.storageRoute, currentLevel);
        }
    }
}
