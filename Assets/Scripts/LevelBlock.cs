using UnityEngine;
using Throw.Core;

public class LevelBlock : MonoBehaviour
{
    public LevelBlockInfo levelBlock;
    public LevelBlockID blockID;

    private void OnEnable()
    {
        TCache.SetLevelBlock(levelBlock);
        TCache.SetLevelID(blockID);
    }
}
