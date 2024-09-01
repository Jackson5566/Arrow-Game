using UnityEngine;
using UnityEngine.UI;
using Throw.Blockers;
using Throw.Core;

namespace TouchWall.Blockers
{
    public class LevelLockable : Blockeable
    {
        [SerializeField] private Image _levelImage;

        [SerializeField] private Sprite _blockImage;
        [SerializeField] private Sprite _unlockImage;

        public string levelToLoad;

        protected override void Awake()
        {
            base.Awake();
        }

        protected override void ChangeState(bool isBlocked)
        {
            base.ChangeState(isBlocked);

            if (isBlocked) _levelImage.sprite = _blockImage;

            else
            {
                Destroy(_levelImage);
                if (!isBlocked) gameObject.GetComponentInChildren<Button>().onClick.AddListener(LoadLevel);
            }
        }
        private void LoadLevel()
        {
            SceneLoader.Instance.LoadAsync(levelToLoad);
        }
    }
}
