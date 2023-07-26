﻿namespace API.Utilities.Validations;

public static class FileValidation
{
    public static bool IsValidImageExtension(IFormFile file)
    {
        var extensionFile = Path.GetExtension(file.FileName);

        if (extensionFile == ".jpg" || extensionFile == ".png" || extensionFile == ".jpeg")
        {
            return true;
        }

        return false;
    }
}
