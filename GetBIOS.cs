using System;
using System.Runtime.InteropServices;

namespace USBFormatingWithWinForm {
    internal class GetBIOS {
        public const int ERROR_INVALID_FUNCTION = 1;
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode, ExactSpelling = true, CallingConvention = CallingConvention.StdCall)]
        public static extern int GetFirmwareType(string lpName, string lpGUID, IntPtr pBuffer, uint size);
    }
}