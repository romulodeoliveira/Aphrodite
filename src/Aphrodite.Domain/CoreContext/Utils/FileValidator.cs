namespace Aphrodite.Domain.CoreContext.Utils;

public class FileValidator
{
    public static bool IsMp4(byte[] fileBytes)
    {
        // Magic numbers para arquivos MP4: [00 00 00 ?? 66 74 79 70 69 73 6F 6D]
        if (fileBytes == null || fileBytes.Length < 12) return false;

        return fileBytes[4] == 0x66 && fileBytes[5] == 0x74 &&
               fileBytes[6] == 0x79 && fileBytes[7] == 0x70 &&
               fileBytes[8] == 0x69 && fileBytes[9] == 0x73 &&
               fileBytes[10] == 0x6F && fileBytes[11] == 0x6D;
    }

    public static bool IsMov(byte[] fileBytes)
    {
        // Magic numbers para arquivos MOV: [00 00 00 ?? 66 74 79 70 71 74 20 20]
        if (fileBytes == null || fileBytes.Length < 12) return false;

        return fileBytes[4] == 0x66 && fileBytes[5] == 0x74 &&
               fileBytes[6] == 0x79 && fileBytes[7] == 0x70 &&
               fileBytes[8] == 0x71 && fileBytes[9] == 0x74;
    }

    public static bool IsJpg(byte[] fileBytes)
    {
        // Magic numbers para arquivos JPG: [FF D8 FF]
        if (fileBytes == null || fileBytes.Length < 3) return false;

        return fileBytes[0] == 0xFF && fileBytes[1] == 0xD8 && fileBytes[2] == 0xFF;
    }

    public static bool IsPng(byte[] fileBytes)
    {
        // Magic numbers para arquivos PNG: [89 50 4E 47 0D 0A 1A 0A]
        if (fileBytes == null || fileBytes.Length < 8) return false;

        return fileBytes[0] == 0x89 && fileBytes[1] == 0x50 &&
               fileBytes[2] == 0x4E && fileBytes[3] == 0x47 &&
               fileBytes[4] == 0x0D && fileBytes[5] == 0x0A &&
               fileBytes[6] == 0x1A && fileBytes[7] == 0x0A;
    }

    public static bool IsSupportedImageOrVideo(byte[] fileBytes)
    {
        return IsMp4(fileBytes) || IsMov(fileBytes) || IsJpg(fileBytes) || IsPng(fileBytes);
    }
}