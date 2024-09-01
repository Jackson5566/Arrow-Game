using UnityEngine;

namespace Throw.Blockers
{
    public abstract class Blocker : MonoBehaviour
    {
        protected Blockeable[] blocks;

        protected virtual void Start()
        {
            /* 
             By default all lockables are blocked
             */

            blocks = GetComponentsInChildren<Blockeable>();

            for (int i = 0; i < blocks.Length; i++)
            {
                bool unlock = UnlockCondition(i, blocks[i]);
                if (unlock)
                    blocks[i].blocked = false;

                InIteration(i, blocks[i], unlock);
            }

            Finished();
        }

        protected virtual void Finished()
        {

        }

        protected abstract bool UnlockCondition(int index, Blockeable blockeable);
        protected abstract void InIteration(int index, Blockeable blockeable, bool unlock);
    }
}
