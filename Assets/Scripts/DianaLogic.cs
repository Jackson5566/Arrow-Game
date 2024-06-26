using PencilGame;
using UnityEngine;

public class DianaLogic : MonoBehaviour
{
    public Player player;
    private Diana diana;

    private void Start()
    {
        diana = GetComponent<Diana>();
    }

    public void OnCollider()
    {
        diana.ChangeDirection();
        player.counter.Rest();
    }
}
