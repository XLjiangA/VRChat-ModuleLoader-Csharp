using System.Runtime.InteropServices;

namespace VRCTans.Utility
{
    internal class NativeAPI
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public extern static int LoadLibraryA(string path);

    }
}
