using System;

namespace JuceEngine.Core.Singletons
{
    public abstract class Singleton<T> where T : class
    {
        static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Activator.CreateInstance<T>();
                }

                return _instance;
            }
        }
    }
}
