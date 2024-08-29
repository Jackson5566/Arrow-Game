using System.Collections;
using System.Collections.Generic;
using Throw.Core;
using UnityEngine;
using UnityEngine.UI;

public class LoadButton : MonoBehaviour
{
    [SerializeField] private string _scene;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => SceneLoader.Instance.LoadAsync(_scene));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
