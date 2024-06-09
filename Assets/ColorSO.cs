using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Skin
{
    public UnityEngine.Color spriteColor;
    public Color selectedColor;
}

[CreateAssetMenu(fileName="color", menuName = "Resources/Color")]
public class ColorSO : ScriptableObject
{
    public List<Skin> skinList;
}
