using JuceEngine.Core.Files.Utils;
using JuceEngine.Core.Results.Tasks;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JuceEngine.Serialization.Objects
{
    public static class SerializableObject
    {
        public static JsonSerializerSettings JsonSettings = new JsonSerializerSettings()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.All,
        };

        public static Task Save<T>(string filePath, T serializableObject, CancellationToken cancellationToken)
        {
            try
            {
                string dataString = JsonConvert.SerializeObject(serializableObject, JsonSettings);

                byte[] dataBytes = Encoding.UTF8.GetBytes(dataString);

                return FilesUtils.SaveBytesAsync(filePath, dataBytes, cancellationToken);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return Task.CompletedTask;
        }

        public static async Task<ITaskResult<T>> Load<T>(string filePath, CancellationToken cancellationToken)
        {
            try
            {
                ITaskResult<byte[]> bytesResult = await FilesUtils.LoadBytesAsync(filePath, cancellationToken);

                bool hasResult = bytesResult.TryGetResult(out byte[] resultValue);

                if (!hasResult)
                {
                    return TaskResult<T>.FromEmpty();
                }

                string finalString = Encoding.UTF8.GetString(resultValue);

                T serializableObject = JsonConvert.DeserializeObject<T>(finalString, JsonSettings);

                if (serializableObject == null)
                {
                    return TaskResult<T>.FromEmpty();
                }

                return TaskResult<T>.FromResult(serializableObject);
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return TaskResult<T>.FromEmpty();
        }
    }
}
