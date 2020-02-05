namespace InspireTaleFramework
{
    public class Singleton<T> where T : new()
    {
        private static T m_Instance;
        private static readonly object m_Padlock = new object();

        public static T Instance
        {
            get
            {
                lock (m_Padlock)
                {
                    if (m_Instance == null)
                    {
                        m_Instance = new T();
                    }
                    return m_Instance;
                }
            }
        }
    }
}
