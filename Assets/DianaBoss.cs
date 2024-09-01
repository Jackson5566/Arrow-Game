using UnityEngine;
using UnityEngine.Playables;

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
    public static int level;

    public PlayableDirector finalBossTimeline;

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

    protected override void OnCollider(Transform obj)
    {
        player.counter.Add();
    }

    protected override void OnNotCollider()
    {
        player.counter.Rest();
    }

    protected override void Start()
    {
        base.Start();
        level = 0;

        SetBoss(previousBossIndex: 0);

        currentBoss.Start();
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        ClearBossEvents();
    }

    protected override void OnCounter()
    {
        if (player.counter.score < 0)
        {
            player.counter.score = 0;
            OnLose();
        }

        currentBoss.OnScore(player.counter.score);
    }

    private void SetBoss(int previousBossIndex)
    {
        currentBoss = boss[level];

        AddBossEvents();

        if (level >= 0) 
            boss[level + previousBossIndex].Diana.SetActive(false);
        currentBoss.Diana.SetActive(true);

        _dianaLogic = currentBoss.Diana.GetComponent<AbstractDianaLogic>();
    }
    private void NewBoss()
    {
        if (level < maxLevel)
        {
            ClearBossEvents();

            level += 1;
            SetBoss(previousBossIndex: -1);
        }

        else
        {
            finalBossTimeline.Play();
        }
    }

    private void PreviousBoss()
    {
        if (level > 0)
        {
            ClearBossEvents();

            level -= 1;
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
        ResetScene();
    }

}
