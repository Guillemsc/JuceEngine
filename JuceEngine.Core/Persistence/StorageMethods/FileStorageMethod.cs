using System.Text;
using JuceEngine.Core.Files.Utils;
using JuceEngine.Core.Persistence.StorageMethods;
using JuceEngine.Core.Results.Tasks;

namespace JuceEngine.Core.Persistence.Methods
{
    public class FileStorageMethod : IStorageMethod
    {
        public Task Save(string localPath, string data, CancellationToken cancellationToken)
        {
            string finalPath = GetFilePathFromLocalPath(localPath);

            byte[] dataBytes = Encoding.UTF8.GetBytes(data);

            return FilesUtils.SaveBytesAsync(finalPath, dataBytes, cancellationToken);
        }

        public async Task<ITaskResult<string>> Load(string localPath, CancellationToken cancellationToken)
        {
            string finalPath = GetFilePathFromLocalPath(localPath);

            ITaskResult<byte[]> bytesResult = await FilesUtils.LoadBytesAsync(finalPath, cancellationToken);

            bool hasResult = bytesResult.TryGetResult(out byte[] resultValue);

            if (!hasResult)
            {
                return TaskResult<string>.FromEmpty();
            }

            string finalString = Encoding.UTF8.GetString(resultValue);

            return TaskResult<string>.FromResult(finalString);
        }

        public static string GetFilePathFromLocalPath(string fileName)
        {
            return string.Format(
                "{0}{1}",
                GetStorageDirectory(),
                fileName
            );
        }

        public static string GetStorageDirectory()
        {
            return Path.Combine(
                $"SerializableData{Path.DirectorySeparatorChar}"
            );
        }

        public static void ClearAllStoredData()
        {
            string path = GetStorageDirectory();

            Directory.Delete(path, recursive: true);
        }

        public static void ClearStoredData(string localPath)
        {
            string finalPath = GetFilePathFromLocalPath(localPath);

            Directory.Delete(finalPath, recursive: true);
        }
    }
}
