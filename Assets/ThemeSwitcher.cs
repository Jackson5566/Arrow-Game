using PencilGame;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ThemeSwitcher : PerssistanService<ThemeSwitcher>
{
    Theme _currentTheme;
    public Theme currentTheme
    {
        get
        {
            return _currentTheme;
        }
    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += SceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= SceneLoaded;
    }

    protected override void Awake()
    {
        base.Awake();
        _currentTheme = DataStorage.GetTheme();
    }

    private void SceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LookTheme(_currentTheme);
    }

    public void SetTheme(Theme theme)
    {
        _currentTheme = theme;

        LookTheme(theme);
    }

    public void LookTheme(Theme theme)
    {
        if (theme.Equals(Theme.Dark))
        {
            ChangeTheme(UnityEngine.Color.black, UnityEngine.Color.white);
        }

        else if (theme.Equals(Theme.Light))
        {
            ChangeTheme(UnityEngine.Color.white, UnityEngine.Color.black);
        }
    }

    private void ChangeTheme(UnityEngine.Color primaryColor, UnityEngine.Color secondColor)
    {
        CustomImage[] images = FindObjectsOfType<CustomImage>();
        TextMeshProUGUI[] texts = FindObjectsOfType<TextMeshProUGUI>();
        Button[] buttons = FindObjectsOfType<Button>();

        Camera.main.backgroundColor = primaryColor;

        foreach (CustomImage item in images)
        {
            item.color = secondColor;
        }

        foreach (TextMeshProUGUI item in texts)
        {
            item.color = secondColor;
        }

        foreach (Button btn in buttons)
        {
            ColorBlock cb = btn.colors;
            cb.normalColor = secondColor;
            btn.colors = cb;
        }
    }
}
