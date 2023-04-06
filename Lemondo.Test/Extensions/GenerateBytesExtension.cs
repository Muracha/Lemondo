namespace Lemondo.Test.Extensions;

public static class GenerateBytesExtension
{
    public static byte[] GenerateRandomBytes(this byte[] buffer, int length)
    {
        buffer = new byte[length];
        Random rand = new Random();
        rand.NextBytes(buffer);
        return buffer;
    }
}
