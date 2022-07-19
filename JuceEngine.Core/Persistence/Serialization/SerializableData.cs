using System.Diagnostics;
using Newtonsoft.Json;
using JuceEngine.Core.Persistence.StorageMethods;
using JuceEngine.Core.Results.Tasks;

namespace JuceEngine.Core.Persistence.Serialization
{
    /// <summary>
    /// Utility for serializing and deserializing any type of class as a json in a safe manner
    /// </summary>
    public sealed class SerializableData<T> : ISerializableData<T> where T : class
    {
        public static JsonSerializerSettings JsonSettings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented
        };

        readonly IStorageMethod _storageMethod;
        readonly string _localPath;

        T _data;

        public event Action<T> OnSave;
        public event Action<T, bool> OnLoad;

        public T Data => GetData();

        public SerializableData(IStorageMethod storageMethod, string localPath)
        {
            _storageMethod = storageMethod;
            _localPath = localPath;
        }

        public async Task Save(CancellationToken cancellationToken)
        {
            TryGenerateData();

            OnSave?.Invoke(_data);

            try
            {
                Stopwatch saveStopWatch = Stopwatch.StartNew();

                string dataString = JsonConvert.SerializeObject(_data, JsonSettings);

                await _storageMethod.Save(_localPath, dataString, cancellationToken);

                saveStopWatch.Stop();

                Console.WriteLine($"{nameof(SerializableData<T>)} {typeof(T).Name} saved ({saveStopWatch.ElapsedMilliseconds}ms) \n{_data}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error saving {nameof(SerializableData<T>)} {typeof(T).Name} with " +
                    $"the following exception {exception}");
            }
        }

        public async Task Load(CancellationToken cancellationToken)
        {
            try
            {
                Stopwatch loadStopWatch = Stopwatch.StartNew();

                ITaskResult<string> dataStringResult = await _storageMethod.Load(_localPath, cancellationToken);

                bool hasResult = dataStringResult.TryGetResult(out string dataString);

                if (!hasResult)
                {
                    TryGenerateData();

                    OnLoad?.Invoke(_data, /*First time:*/ true);

                    Console.WriteLine($"{nameof(SerializableData<T>)} {typeof(T).Name} not found. Creating with default values");
                }
                else
                {
                    _data = JsonConvert.DeserializeObject<T>(dataString, JsonSettings);

                    OnLoad?.Invoke(_data, /*First time:*/ false);

                    Console.WriteLine($"{nameof(SerializableData<T>)} {typeof(T).Name} loaded ({loadStopWatch.ElapsedMilliseconds}ms) \n{Data}");
                }

                loadStopWatch.Stop();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Error loading {nameof(SerializableData<T>)} {typeof(T).Name} " +
                    $"with the following exception {exception}");
            }

            TryGenerateData();
        }

        T GetData()
        {
            if (_data == null)
            {
                TryGenerateData();

                Console.WriteLine($"Tried to get Data before it was loaded, at {nameof(SerializableData<T>)} {typeof(T).Name}");
            }

            return _data;
        }

        void TryGenerateData()
        {
            if (_data != null)
            {
                return;
            }

            _data = Activator.CreateInstance<T>();
        }
    }
}
