using System;
using UnityEngine;

public enum Color
{
    Green,
    Yellow,
    Purple,
    Blue
}

public class Chameleon : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _spriteRenderers;

    public Color currentColor;
    [SerializeField, Header("Color Scriptable Object")] private ColorSO colorSO;

    public Skin skin;

    public void ChangeColor(float alpha = 1)
    {
        int color = GetRandomColor();
        currentColor = (Color)color;

        skin = colorSO.skinList.Find(x => x.selectedColor == currentColor);

        foreach (SpriteRenderer spriteRenderer in _spriteRenderers)
        {
            UnityEngine.Color newColor = skin.spriteColor;
            newColor.a = alpha;
            spriteRenderer.color = newColor;
        }
    }

    public int GetRandomColor()
    {
        int color = UnityEngine.Random.Range(0, Enum.GetValues(typeof(Color)).Length);
        if ((Color)color != currentColor)
        {
            return color;
        }
        else
        {
            return GetRandomColor();
        }
    }
}
