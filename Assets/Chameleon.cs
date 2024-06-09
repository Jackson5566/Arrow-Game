using System;
using UnityEngine;

public enum Color
{
    Black,
    Red,
    Green,
    Yellow,
    Purple,
    Pink,
    Blue
}

public class Chameleon : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _spriteRenderers;

    public Color currentColor;
    public ColorSO colorSO;

    public Skin skin;

    public void Change()
    {
        print(Enum.GetValues(typeof(Color)).Length);
        int color = GetRandomColor();
        print("COlor elegido: " +
            color);
        currentColor = (Color)color;

        skin = colorSO.skinList.Find(x => x.selectedColor == currentColor);

        foreach (SpriteRenderer spriteRenderer in _spriteRenderers)
        {
            spriteRenderer.color = skin.spriteColor;
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
