using UnityEngine;

public static class DataStorage
{
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