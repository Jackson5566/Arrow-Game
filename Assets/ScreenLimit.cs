using UnityEngine;

public class ScreenLimit : MonoBehaviour
{
    private void Update()
    {
        if (Mathf.Abs(transform.position.x) > 4)
        {
            GameMode.Instance.OnLose();
        }
        else if (Mathf.Abs(transform.position.y) > 6)
        {
            GameMode.Instance.OnLose();
        }
    }
}
