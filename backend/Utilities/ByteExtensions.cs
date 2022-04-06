namespace BrewController.Utilities;

internal static class ByteExtensions
{
    public static bool GetBit(this byte b, int bitNumber) => ((b >> bitNumber) & 1) != 0;
}