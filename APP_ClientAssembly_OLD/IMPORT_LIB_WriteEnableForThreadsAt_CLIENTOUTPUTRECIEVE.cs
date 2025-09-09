using System.Runtime.InteropServices;
using System.Security;

namespace Avril_FSD
{
    [SuppressUnmanagedCodeSecurity]
    public static class Library_For_WriteEnableForThreadsAt_CLIENTOUTPUTRECIEVE
    {
        [DllImport("LIBWriteEnableForThreadsAtSERVEROUTPUTRECIEVE.dll", EntryPoint = "")]
        public static extern IntPtr Initialise_WriteEnable();

        [DllImport("LIBWriteEnableForThreadsAtSERVEROUTPUTRECIEVE.dll", EntryPoint = "")]
        public static extern void Write_End(IntPtr obj, byte coreId);

        [DllImport("LIBWriteEnableForThreadsAtSERVEROUTPUTRECIEVE.dll", EntryPoint = "")]
        public static extern void Write_Start(IntPtr obj, byte coreId);
    }
}