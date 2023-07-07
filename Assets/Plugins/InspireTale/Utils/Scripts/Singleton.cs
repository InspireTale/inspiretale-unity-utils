namespace InspireTale.Utils
{
    public class Singleton<T> where T : new()
    {
        private static T m_Instance;
        private static readonly object m_Padlock = new();

        public static T Instance
        {
            get
            {
                lock (m_Padlock)
                {
                    if (!IsInitialized)
                    {
                        m_Instance = new T();
                    }
                    return m_Instance;
                }
            }
        }

        public static bool IsInitialized => m_Instance != null;
    }
}
