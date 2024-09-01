using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Throw.Blockers;
using TMPro;

namespace TouchWall.Blockers
{
    public class LevelBlocker : Blocker
    {
        public string _blockName;
        private List<TextMeshProUGUI> _levelsText = new();

        private LevelBlock levelBlock;


        #region Configurations
        public bool setAutomaticLevel2Load = true;
        public bool setAutomaticLevelText = true;
        #endregion

        protected override void Start()
        {
            levelBlock = GetComponent<LevelBlock>();
            base.Start();
        }

        protected override void Finished()
        {
            base.Finished();

            if (setAutomaticLevelText) BlockName();
        }

        protected override void InIteration(int index, Blockeable blockeable, bool unlock)
        {
            int levelNumber = index + 1;

            if (setAutomaticLevelText)  _levelsText.Add(blockeable.GetComponentInChildren<TextMeshProUGUI>());
            if (setAutomaticLevel2Load) (blockeable as LevelLockable).levelToLoad = $"{levelBlock.levelBlock.name} {levelNumber}";
        }

        protected override bool UnlockCondition(int index, Blockeable blockeable)
        {
            return !(index > PlayerPrefs.GetInt(levelBlock.levelBlock.storageRoute));
        }

        public void BlockName()
        {
            for (int i = 0; i < _levelsText.Count; i++)
            {
                _levelsText[i].text = _blockName + " " + (i + 1);
            }
        }
    }
}