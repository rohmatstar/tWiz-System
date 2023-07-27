namespace API.Utilities.Handlers;

public static class FileHandler
{
    public static void DeleteFileIfExist(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
    }
}

