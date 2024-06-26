using UnityEngine;

public class Effects : MonoBehaviour
{
    public ParticleSystem confettiParicles;

    public void InstantiateConfetti(Vector2 position)
    {
        confettiParicles.transform.position = position;
        confettiParicles.Play();
    }
}
