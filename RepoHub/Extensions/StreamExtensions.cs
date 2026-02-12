namespace RepoHub.Extensions
{
    public static class StreamExtension
    {
        public static void SaveToFile(this Stream stream, string fileName)
        {
            byte[] array = new byte[stream.Length];
            stream.Read(array, 0, array.Length);
            if (!Directory.Exists(Path.GetDirectoryName(fileName)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
            }

            using FileStream fileStream = new FileStream(fileName, FileMode.Create);
            using BinaryWriter binaryWriter = new BinaryWriter(fileStream);
            binaryWriter.Write(array);
            binaryWriter.Close();
            fileStream.Close();
        }

        public static Task<string> ReadToEndAsync(this Stream stream)
        {
            string empty = string.Empty;
            using StreamReader streamReader = new StreamReader(stream);
            return streamReader.ReadToEndAsync();
        }
    }
}
