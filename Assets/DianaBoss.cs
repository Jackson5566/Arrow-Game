using UnityEngine;

public class DianaBoss : GameMode
{
    public GameObject[] eyes;
    public GameObject mouth;

    public int scoreEyes;
    public int scoreMouth;

    bool eyesActivated;
    bool mouthActivated;

    protected override void Start()
    {
        base.Start();
        SceneTransitions("transition_start");
        eyesActivated = false;
        mouthActivated = false;
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    protected override void OnCounter(int counter)
    {
        if (counter < 0)
        {
            counter = 0;
            Lose();
        }

        if (counter == scoreEyes)
        {
            foreach (GameObject eye in eyes)
            {
                eye.SetActive(true);
            }

            eyesActivated = true;
        }

        else if(counter < scoreEyes && eyesActivated)
        {
            eyesActivated = false;
            foreach (GameObject eye in eyes)
            {
                eye.SetActive(false);
            }
        }

        if (counter == scoreMouth)
        {
            mouthActivated = true;
            mouth.SetActive(true);
        }

        else if (counter < scoreMouth && mouthActivated)
        {
            mouth.SetActive(false);
            mouthActivated = false;
        }
    }

    public override void Win()
    {
    }

    public override void Lose()
    {
        _isLose = true;
        SceneTransitions();
        Invoke("ResetScene", 1.5f);
    }
}
