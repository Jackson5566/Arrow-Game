using UnityEngine;

namespace PencilGame
{
    public class Singleton<T> : MonoBehaviour where T : Component
    {
        private static T _Instance;
        public static T Instance
        {
            get
            {
                if (_Instance == null)
                {
                    Debug.LogError("¡Instance is null! I going to created");
                    GameObject singletonObject = new GameObject(typeof(T).Name);
                    _Instance = singletonObject.AddComponent<T>();
                }
                return _Instance;
            }
        }

        protected void DoSingleton(bool perssistan = false)
        {

            if (_Instance == null)
            {
                _Instance = this as T;
                if(perssistan) DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    public class Service<T> : Singleton<T> where T : Component
    {
        protected virtual void Awake()
        {
            DoSingleton();
        }
    }

    public class PerssistanService<T> : Singleton<T> where T : Component
    {
        protected virtual void Awake()
        {
            DoSingleton(true);
        }
    }
}
