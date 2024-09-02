using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public enum Theme
{
    Dark,
    Light
}

public static class DataStorage
{
    public static void SaveTheme(Theme theme)
    {
        PlayerPrefs.SetInt("Theme", (int)theme);
    }

    public static Theme GetTheme()
    {
        return (Theme)PlayerPrefs.GetInt("Theme", 0);
    }

    public static void SaveGameName(string gameName)
    {
        PlayerPrefs.SetString("GameName", gameName);
    }

    public static string GetGameName()
    {
        return PlayerPrefs.GetString("GameName");
    }

    public static void SaveGameScore(string gameName, int score)
    {
        PlayerPrefs.SetInt(gameName, score);
    }

    public static int GetGameScore(string gameName)
    {
        return PlayerPrefs.GetInt(gameName);
    }


}