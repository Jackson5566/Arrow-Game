using UnityEngine;

namespace Throw.Core
{
    public enum LevelBlockID
    {
        Home,
        Multicolor,
        Troll,
        Multiplayer
    }

    [System.Serializable]
    public class LevelBlockInfo
    {
        // Must coincide with the scene name
        public string name;
        public string storageRoute;
    }

    [System.Serializable]
    public class Music
    {
        public AudioClip clip;
        public LevelBlockID levelBlockID;
    }

    [System.Serializable]
    public class LevelStorage
    {
        public string route;
        public LevelBlockInfo levelBlock;
    }
}
