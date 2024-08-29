
using System.Collections.Generic;
using UnityEditor;

namespace Assets.Scripts
{
    public static class SceneCache
    {
        public static Dictionary<string, int> categoryLevel = new();

        public static void SetLevel(string sceneName, int level)
        {
            categoryLevel.Add(sceneName, level);
        }

        public static void GetLevel()
        {

        }

    }
}
