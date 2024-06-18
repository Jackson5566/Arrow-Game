using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Animator anim;

    [SerializeField]
    private static int _counter = 0;

    public int counter
    {
        get
        {
            return _counter;
        }
        set
        {
            _counter = value;
            anim.SetTrigger("set");

            if (_counter >= 0) text.text = _counter.ToString();
            if(OnCounterChanged != null)
                OnCounterChanged(value);

        }
    }

    public int initialCounter;

    public delegate void OnCounter(int counter);

    public static event OnCounter OnCounterChanged;

    protected void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        anim = GetComponent<Animator>();

        counter = initialCounter;
    }

    public void Rest()
    {
        counter -= 1;
    }

    public void Add()
    {
        counter += 1;
    }
}
