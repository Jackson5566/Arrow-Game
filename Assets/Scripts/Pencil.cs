using UnityEngine;

namespace PencilGame
{
    public class Pencil : MonoBehaviour
    {
        private void Awake()
        {
            GetComponent<PencilMovement>().speed = PencilLauncher.Instance.speed;
        }
    }
}
