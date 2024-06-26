using PencilGame;
using UnityEngine;

public class DianaMulticolorLogic : MonoBehaviour
{
    private Diana diana;
    public Player player;
    public PositiveText positiveText;
    public Effects effects;

    private void Start()
    {
        diana = GetComponent<Diana>();
    }

    public void OnCollider(Transform obj)
    {
        diana.ChangeDirection();
        player.counter.Add();
        // positiveText.Show();
        effects.InstantiateConfetti(obj.position);
    }

    public void Add()
    {
        player.counter.Add();
    }

    public void Subsctract()
    {

        player.counter.Rest(); 
    }
}
