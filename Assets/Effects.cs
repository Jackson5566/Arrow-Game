using PencilGame;
using UnityEngine;

public class Effects : Service<Effects>
{
    // public GameObject confetti;
    public ParticleSystem confettiParicles;

    public void InstantiateConfetti(Vector2 position)
    {
        confettiParicles.transform.position = position;
        confettiParicles.Play();
        // Instantiate(confetti, position, Quaternion.identity);
    }

}
