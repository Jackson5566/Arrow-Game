using PencilGame;
using UnityEngine;

public class Effects : Service<Effects>
{
    public GameObject confetti;

    public void InstantiateConfetti(Vector2 position)
    {
        Instantiate(confetti, position, Quaternion.identity);
    }

}
