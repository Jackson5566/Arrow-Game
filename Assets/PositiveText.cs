using PencilGame;
using TMPro;
using UnityEngine;

public class PositiveText : Service<PositiveText>
{
    private Animator _animator;
    private TextMeshProUGUI _textUI;

    [SerializeField] private string[] _messages;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _textUI = GetComponent<TextMeshProUGUI>();
    }

    public void Show()
    {
        string text = _messages[Random.Range(0, _messages.Length)];

        _textUI.text = text;

        _animator.SetTrigger("show");
    }

}
