using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Throw.Core
{
    public static class TCache
    {
        private static LevelBlockInfo _levelBlock;

        public static LevelBlockInfo levelBlock
        {
            get { return _levelBlock; }
            set { _levelBlock = value; }
        }

        public static LevelBlockID levelID;

        private static Dictionary<string, GameObject[]> gameObjects = new();

        public static GameObject[] Get(string key)
        {
            if (gameObjects.ContainsKey(key)) return gameObjects[key];
            else return Array.Empty<GameObject>();
        }

        public static void AddGameObject(string key, GameObject gameObject)
        {
            if (gameObjects.ContainsKey(key))
            {
                gameObjects[key].Append(gameObject);
            }

            else
            {
                gameObjects.Add(key, new GameObject[] { gameObject });
            }
        }

        public static void Add(string key, GameObject[] objects)
        {
            gameObjects.Add(key, objects);
        }

        public static void AddEmpy(string key)
        {
            if (!gameObjects.ContainsKey(key))
                gameObjects.Add(key, Array.Empty<GameObject>());
        }

        public static bool Exists(string key)
        {
            return gameObjects.ContainsKey(key);
        }

        public static void SetLevelBlock(LevelBlockInfo levelBlock)
        {
            _levelBlock = levelBlock;
        }

        public static void SetLevelID(LevelBlockID id)
        {
            levelID = id;
        }
    }
}
