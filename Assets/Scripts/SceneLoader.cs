using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneByIndex(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void LoasSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }
}
