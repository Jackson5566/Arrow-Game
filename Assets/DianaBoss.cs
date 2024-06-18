using UnityEngine;

[System.Serializable]
public class Boss
{
    public GameObject Diana;

    public GameObject[] eyes;
    public GameObject mouth;

    public int scoreEyes;
    public int scoreMouth;

    public int maxScore;
    [HideInInspector] public int minScore;

    public bool eyesActivated;
    public bool mouthActivated;

    public delegate void BossDestroy();
    public event BossDestroy OnDestroy;
    public event BossDestroy OnDissaperar;

    public void Start()
    {
        eyesActivated = false;
        mouthActivated = false;
    }

    public void OnScore(int counter)
    {
        if (counter == scoreEyes) SetEyes(true);
        else if (counter < scoreEyes && eyesActivated) SetEyes(false);

        if (counter == scoreMouth) SetMouth(true);
        else if (counter < scoreMouth && mouthActivated) SetMouth(false);

        if (counter == maxScore)
        {
            if (OnDestroy != null) OnDestroy();
        }

        else if(counter == minScore)
        {
            if (OnDissaperar != null) OnDissaperar();
        }
    }

    private void SetEyes(bool enable)
    {
        foreach (GameObject eye in eyes)
        {
            eye.SetActive(enable);
        }

        eyesActivated = enable;
    }

    private void SetMouth(bool enable)
    {
        mouthActivated = enable;
        mouth.SetActive(enable);
    }
}

public class DianaBoss : GameMode
{
    public Boss[] boss;

    private Boss currentBoss;

    private int maxLevel = 3;
    public static int currentLevel;

    private void OnValidate()
    {
        maxLevel = boss.Length - 1;

        for (int i = 0; i < boss.Length; i++)
        {
            if (i > 0)
            {
                boss[i].minScore = boss[i - 1].maxScore - 1;
            }
            else
            {
                boss[i].minScore = -1;
            }
        }
    }

    protected override void Start()
    {
        base.Start();

        currentLevel = 0;

        SetBoss(previousBossIndex: 0);
        SceneTransitions("transition_start");

        currentBoss.Start();
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        ClearBossEvents();
    }

    protected override void OnCounter(int counter)
    {
        if (counter < 0)
        {
            counter = 0;
            OnLose();
        }

        currentBoss.OnScore(counter);
    }

    private void SetBoss(int previousBossIndex)
    {
        currentBoss = boss[currentLevel];

        AddBossEvents();

        if (currentLevel >= 0) 
            boss[currentLevel + previousBossIndex].Diana.SetActive(false);
        currentBoss.Diana.SetActive(true);
    }
    private void NewBoss()
    {
        if (currentLevel < maxLevel)
        {
            ClearBossEvents();

            currentLevel += 1;
            SetBoss(previousBossIndex: -1);
        }
    }

    private void PreviousBoss()
    {
        if (currentLevel > 0)
        {
            ClearBossEvents();

            currentLevel -= 1;
            SetBoss(previousBossIndex: 1);
        }
    }

    private void ClearBossEvents()
    {
        currentBoss.OnDestroy -= NewBoss;
        currentBoss.OnDissaperar -= PreviousBoss;
    }

    private void AddBossEvents()
    {
        currentBoss.OnDestroy += NewBoss;
        currentBoss.OnDissaperar += PreviousBoss;
    }

    public override void OnWin() {}

    public override void OnLose()
    {
        _isLose = true;
        SceneTransitions();
        Invoke("ResetScene", 1.5f);
    }

}
