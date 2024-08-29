using UnityEngine;

[RequireComponent(typeof(Chameleon))]
public class Multicolor : MonoBehaviour
{
    public float MaxTime2Change;
    public float time2Pass;

    public float timePassed;

    private Chameleon chameleon;

    private void Start()
    {
        chameleon = GetComponent<Chameleon>();
        timePassed = 0;
        NewTime();
    }

    private void Update()
    {
        timePassed += Time.deltaTime; 
        if (timePassed >= time2Pass)
        {
            chameleon.ChangeColor();
            timePassed = 0;
            NewTime();
        }
    }

    private void NewTime()
    {
        time2Pass = UnityEngine.Random.Range(0, MaxTime2Change);
    }
}
