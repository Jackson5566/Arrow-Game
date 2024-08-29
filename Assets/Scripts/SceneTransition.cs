using UnityEngine;
using UnityEngine.SceneManagement;
using PencilGame;

public class SceneTransition : PerssistanService<SceneTransition>
{
    [SerializeField] private Animator panelFade;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PanelFadeOut();
    }

    public void PanelFadeOut()
    {
        panelFade.SetTrigger("start");
    }

    public void PanelFadeIn()
    {
        print("Pa tras");
        panelFade.SetTrigger("end");
    }
}
