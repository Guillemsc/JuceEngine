using JuceEngine.Core.Results.Tasks;

namespace JuceEngine.Core.Files.Utils
{
    public static class FilesUtils
    {
        public static async Task SaveBytesAsync(string filePath, byte[] data, CancellationToken cancellationToken)
        {
            try
            {
                bool fileAlreadyExists = File.Exists(filePath);

                if(!fileAlreadyExists)
                {
                    string filePathDirectory = Path.GetDirectoryName(filePath);

                    Directory.CreateDirectory(filePathDirectory);
                }
                else
                {
                    File.Delete(filePath);
                }

                using (FileStream sourceStream = File.Open(filePath, FileMode.OpenOrCreate))
                {
                    sourceStream.Seek(0, SeekOrigin.End);

                    await sourceStream.WriteAsync(data, 0, data.Length, cancellationToken);
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine($"There was an exception trying to save bytes async to filePath " +
                    $"{filePath}, at {nameof(FilesUtils)}");

                Console.WriteLine(exception.Message);
            }
        }

        public static async Task<ITaskResult<byte[]>> LoadBytesAsync(string filePath, CancellationToken cancellationToken)
        {
            bool fileExists = File.Exists(filePath);

            if(!fileExists)
            {
                return TaskResult<byte[]>.FromEmpty();
            }

            try
            {
                byte[] loadedBytes;

                using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
                {
                    loadedBytes = new byte[fileStream.Length];

                    await fileStream.ReadAsync(loadedBytes, 0, (int)fileStream.Length, cancellationToken);
                }

                return TaskResult<byte[]>.FromResult(loadedBytes);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"There was an exception trying to load bytes async at path " +
                    $"{filePath}, at {nameof(FilesUtils)}");

                Console.WriteLine(exception.Message);
            }

            return TaskResult<byte[]>.FromEmpty();
        }
    }
}
