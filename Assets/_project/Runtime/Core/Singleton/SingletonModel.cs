namespace _project.Runtime.Core.Singleton
{
    public class SingletonModel<T>
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }
    }
}