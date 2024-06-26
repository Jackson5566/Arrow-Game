using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.Playables;

public class MultiplayerGameMode : GameMode
{
    public Player player2;

    public float timer;
    //public float maxTime;

    public TextMeshProUGUI timer1Text;
    public TextMeshProUGUI timer2Text;

    bool isEnded;

    public PlayableDirector startGameTimeline;
    public PlayableDirector winTimeline;

    public TextMeshProUGUI winText;

    bool isStarted;

    protected override void Start()
    {
        base.Start();
        isEnded = false;
        isStarted = false;
    }

    public void StartGame(float maxTtime)
    {
        timer = maxTtime;
        StartCoroutine(StartGameCorutine());
    }

    public IEnumerator StartGameCorutine()
    {
        startGameTimeline.Play();
        yield return new WaitForSeconds(3);
        isStarted = true;
    }

    private void Update()
    {
        timer1Text.text = TimerText();
        timer2Text.text = TimerText();

        if (!isEnded && isStarted)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                isEnded = true;
                OnWin();
            }
        }

    }
    private string TimerText()
    {
        return "Time: " + ((int)timer).ToString();
    }

    public override void OnWin()
    {
        print("Ha terminado el tiempo");

        if (player.counter.score > player2.counter.score)
        {
            winText.text = player.name;
            print("Ha ganado: " + player.name);
        }

        else if (player2.counter.score > player.counter.score)
        {
            print("Ha ganado: " + player2.name);
            winText.text = player2.name;
        }

        else
        {
            winText.text = "Ended in a draw";
            print("Ha sido empate");
        }

        winTimeline.Play();
    }

    public override void OnLose()
    {
    }

    protected override void OnCounter()
    {
    }
}
