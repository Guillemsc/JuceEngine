namespace JuceEngine.Core.Service
{
    public struct CachedService<TService>
    {
        bool _isCached;
        TService _cachedService;

        public TService Value
        {
            get
            {
                if (_isCached)
                {
                    return _cachedService;
                }

                _cachedService = ServiceLocator.Get<TService>();
                _isCached = true;

                return _cachedService;
            }
        }
    }
}
