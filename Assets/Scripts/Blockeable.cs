using UnityEngine;
using UnityEngine.UI;

namespace Throw.Blockers
{
    public class Blockeable : MonoBehaviour
    {
        [SerializeField] private bool _blocked;

        public bool blocked
        {
            get { return _blocked; }
            set { ChangeState(value); }
        }

        protected Button _button;

        protected virtual void Awake()
        {
            _button = GetComponentInChildren<Button>();
            _blocked = true;
        }

        /// <summary>
        /// This method is called when blocked change its value
        /// </summary>
        /// <param name="isBlocked"></param>
        protected virtual void ChangeState(bool isBlocked)
        {
            _blocked = isBlocked;
        }
    }
}
