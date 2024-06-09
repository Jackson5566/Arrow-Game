using UnityEngine;

public class World : MonoBehaviour
{
    public static float scale;

    void Awake()
    {
        float referenceAspectRatio = 720f / 1280f;

        float currentAspectRatio = (float)Screen.width / Screen.height;

        scale = currentAspectRatio / referenceAspectRatio;

        transform.localScale = new Vector3(scale, scale, 1f);
    }
}
