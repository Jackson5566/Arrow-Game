using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private TextMeshProUGUI text;
    private Animator anim;

    private int _score = 0;



    public int score
    {
        get
        {
            return _score;
        }
        set
        {
            anim.SetTrigger("set");


            if (value >= 0)
            {
                _score = value;
                text.text = _score.ToString();
            }
            if (OnCounterChanged != null)
                OnCounterChanged();

        }
    }

    public delegate void OnCounter();
    public static event OnCounter OnCounterChanged;

    public int initialCounter;

    protected void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
        anim = GetComponent<Animator>();

        score = initialCounter;
    }

    public void Rest()
    {
        score -= 1;
    }

    public void Add()
    {
        score += 1;
    }
}
