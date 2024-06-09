using UnityEngine;

public class Reutilizable : MonoBehaviour
{
    [Header("Position Y by default")]
    public float positionY;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position = new Vector2(transform.position.x, positionY);
    }
}
