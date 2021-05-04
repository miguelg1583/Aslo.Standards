namespace Outputs.Extensions
{
    public static class IntHelper
    {
        public static int GetResId(this int mask, int code)
        {
            return mask | (code << 16);
        }

        public static int GetHighWord(this int intValue)
        {
            return intValue >> 16;
        }

        public static int GetLowWord(this int intValue)
        {
            return intValue & 0x0000FFFF;
        }
    }
}