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

        eyesActivated = false;
        mouthActivated = false;
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
    }

    protected override void OnCounter(int counter)
    {
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
        throw new System.NotImplementedException();
    }

    public override void Lose()
    {
        throw new System.NotImplementedException();
    }
}
