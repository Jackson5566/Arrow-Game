using PencilGame;
using TMPro;
using UnityEngine;

public class PositiveText : Service<PositiveText>
{
    private Animator _animator;
    private TextMeshProUGUI _textUI;

    [SerializeField] private string[] _positiveTexts;
    [SerializeField] private string[] _negativeTexts;


    private void Start()
    {
        _animator = GetComponent<Animator>();
        _textUI = GetComponent<TextMeshProUGUI>();
    }

    public void ShowPositiveText()
    {
        SelectText(_positiveTexts);
    }

    public void ShowNegativeText()
    {
        SelectText(_negativeTexts);
    }

    private void SelectText(string[] texts)
    {
        string text = texts[Random.Range(0, texts.Length)];

        _textUI.text = text;

        _animator.SetTrigger("show");

    }
}
