using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    [SerializeField] private GameObject _scroller;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(GoBack);
    }

    private void GoBack()
    {
        if (_scroller.activeSelf)
        {
            transform.parent.gameObject.SetActive(false);
        }
        else
        {
            _scroller.SetActive(true);
        }
    }
}
