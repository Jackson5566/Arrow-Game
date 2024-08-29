using PencilGame;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.SceneManagement;
using UnityEngine.AddressableAssets;

namespace Throw.Core
{
    public class SceneLoader : PerssistanService<SceneLoader>
    {
        public static bool sceneLoading;

        public static void Load(string name)
        {
            try
            {
                SceneManager.LoadScene(name);
            }

            catch (Exception ex)
            {
                ErrorLoadingScene(ex);
            }
        }
        public static void Load(int index)
        {
            try
            {
                SceneManager.LoadScene(index);
            }

            catch (Exception ex)
            {
                ErrorLoadingScene(ex);
            }
        }

        public void LoadAsync(string name)
        {
            StartCoroutine(LoadAsyncCorutine(name));
        }

        public static IEnumerator ResetScene()
        {
            return LoadAsyncCorutine(SceneManager.GetActiveScene().name);
        }

        public static IEnumerator LoadAsyncCorutine(string name)
        {
            if (!sceneLoading)
            {
                sceneLoading = true;

                FadeOut();

                yield return new WaitForSeconds(0.15f);

                AsyncOperationHandle handle;

                try
                {
                    handle = Addressables.LoadSceneAsync(
                        key: name,
                    loadMode: LoadSceneMode.Single,
                        activateOnLoad: true
                       );
                }

                catch (InvalidKeyException ex)
                {
                    handle = ErrorLoadingScene(ex);
                }


                handle.Completed += (AsyncOperationHandle handle) =>
                {
                    if (handle.Status == AsyncOperationStatus.Succeeded)
                    {
                        sceneLoading = false;
                    }
                };
            }

            else
            {
                yield return null;
            }
        }

        private static AsyncOperationHandle ErrorLoadingScene(Exception ex)
        {
            FadeOut();
            Debug.LogException(ex);
            return Addressables.LoadSceneAsync(
                key: "Main",
                loadMode: LoadSceneMode.Single,
                activateOnLoad: true
               );

        }

        private static void FadeOut()
        {
            try
            {
                SceneTransition.Instance.PanelFadeIn();
            }
            catch
            {
                Debug.LogError("Wasn't possible active fade out transition!");
            }
        }
    }
}