using UnityEngine;

namespace InspireTaleFramework
{
    public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static bool m_ShuttingDown = false;
        private static object m_Padlock = new object();
        private static T m_Instance;

        public static T Instance
        {
            get
            {
                if (m_ShuttingDown)
                {
                    Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
                        "' going to be destroyed because of ApplicationQuit.");
                    return m_Instance;
                }

                lock (m_Padlock)
                {
                    if (m_Instance == null)
                    {
                        m_Instance = (T)FindObjectOfType(typeof(T));

                        if (m_Instance == null)
                        {
                            var singletonObject = new GameObject();
                            m_Instance = singletonObject.AddComponent<T>();
                            singletonObject.name = typeof(T).ToString() + " (Singleton)";

                            DontDestroyOnLoad(singletonObject);
                        }
                    }

                    return m_Instance;
                }
            }
        }
        public static bool isInitialized
        {
            get
            {
                return m_Instance != null;
            }
        }

        protected virtual void Awake()
        {
            if (m_Instance == null)
            {
                m_Instance = this as T;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
        
        protected virtual void OnApplicationQuit()
        {
            m_ShuttingDown = true;
        }
    }
}
