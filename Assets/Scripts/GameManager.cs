using UnityEngine;
using UnityEngine.SceneManagement;

namespace PencilGame
{
    public class GameManager : Service<GameManager>
    {
        //private bool _isLose;
        //public bool isLose
        //{
        //    get { return _isLose; }
        //    set { 
        //        _isLose = value; 
        //        if (_isLose) GameIsLose(); 
        //    }
        //}

        //private bool _isWinned;
        //public bool isWinned
        //{
        //    get { return _isWinned; }
        //    set
        //    {
        //        _isWinned = value;
        //        if (_isWinned) GameIsLose();
        //    }
        //}

        //[SerializeField] public Animator[] _deadAnimators;

        //[SerializeField] public Animator[] _sceneTransitions;
        
        //public static int level = 0;

        //protected override void Awake()
        //{
        //    base.Awake();
        //}

        //private void Start()
        //{
        //    _isLose = false;

        //    foreach (Animator animator in _sceneTransitions)
        //    {
        //        animator.SetTrigger("transition_start");
        //    }
        //}

        //public void LoadNewLevel()
        //{
        //    level += 1;
        //    Invoke("ResetScene", 1.5f);
        //}

        //public void IsLose()
        //{
        //    _isLose = true;
        //    level = 0;
        //    GameIsLose();
        //}

        //public void IsWinnded()
        //{
        //    _isWinned = true;

        //    foreach (Animator animator in _sceneTransitions)
        //    {
        //        animator.SetTrigger("transition");
        //    }
        //    LoadNewLevel();
        //}

        //private void GameIsLose()
        //{
        //    foreach (Animator animator in _deadAnimators)
        //    {
        //        animator.SetTrigger("dead");
        //    }

        //    foreach (Animator animator in _sceneTransitions)
        //    {
        //        animator.SetTrigger("transition");
        //    }

        //    Invoke("ResetScene", 1.5f);
        //}

        //private void ResetScene()
        //{
        //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //}
    }
}
