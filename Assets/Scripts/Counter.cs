using PencilGame;
using UnityEngine;
using UnityEngine.UI;

public class Counter : Service<Counter>
{
    public Text text;
    public Animator anim;

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
            print(text);
            _counter = value;
            text.text = _counter.ToString();
            anim.SetTrigger("set");
            if(OnCounterChanged != null)
                OnCounterChanged(value);

        }
    }

    public int initialCounter;

    public delegate void OnCounter(int counter);

    public static event OnCounter OnCounterChanged;

    protected override void Awake()
    {
        base.Awake();

        text = GetComponent<Text>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        // Esto tampoco
        counter = initialCounter + GameManager.level;
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
