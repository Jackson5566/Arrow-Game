using UnityEngine;
using UnityEngine.UI;

public class ThemeButton : MonoBehaviour
{
    private Image _image;
    bool _isDark;

    [SerializeField] private Sprite _darkSprite;
    [SerializeField] private Sprite _lightSprite;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(ChangeTheme);
        _isDark = ThemeSwitcher.Instance.currentTheme == Theme.Dark;


        print(_isDark);
        ChangeImage();
    }

    void ChangeTheme()
    {
        _isDark = !_isDark;
        Theme theme = _isDark ? Theme.Dark : Theme.Light;

        DataStorage.SaveTheme(theme);

        ChangeImage();

        ThemeSwitcher.Instance.SetTheme(theme);
    }

    /// <summary>
    /// Change Image looking isDark variable
    /// </summary>
    void ChangeImage()
    {
        _image.sprite = _isDark ? _darkSprite : _lightSprite;

    }
}
