using ManagedBass;
using System;

namespace ShTK.Audio.Framework
{
    public static class ShBass
    {
        public static bool CreateStream(IntPtr pointer, int freq = 44100, DeviceInitFlags flags = DeviceInitFlags.Default)
        {
            return Bass.Init(-1, freq, flags, pointer);
        }

        public static int GetHandle(string path, int offset = 0, int length = 0, BassFlags flags = BassFlags.Default)
        {
            return Bass.CreateStream(path, offset, length, flags);
        }
    }
}
