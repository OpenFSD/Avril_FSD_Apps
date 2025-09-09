using System.Runtime.InteropServices;
using System.Security;

namespace Avril_FSD
{
    [SuppressUnmanagedCodeSecurity]
    public static class Library_For_WriteEnableForThreadsAt_CLIENTOUTPUTRECIEVE
    {
        [DllImport("LIBWriteEnableForThreadsAtClientOutputRecieve.dll", EntryPoint = "?Initialise_WriteEnable@Library_WriteEnableForThreadsAt_CLIENTOUTPUTRECIEVE@Avril_FSD@@SAPAXXZ")]
        public static extern IntPtr Initialise_WriteEnable();

        [DllImport("LIBWriteEnableForThreadsAtClientOutputRecieve.dll", EntryPoint = "?Write_End@Library_WriteEnableForThreadsAt_CLIENTOUTPUTRECIEVE@Avril_FSD@@SAXPAVWriteEnableForThreadsAt_CLIENTOUTPUTRECIEVE_Framework@2@E@Z")]
        public static extern void Write_End(IntPtr obj, byte coreId);

        [DllImport("LIBWriteEnableForThreadsAtClientOutputRecieve.dll", EntryPoint = "?Write_Start@Library_WriteEnableForThreadsAt_CLIENTOUTPUTRECIEVE@Avril_FSD@@SAXPAVWriteEnableForThreadsAt_CLIENTOUTPUTRECIEVE_Framework@2@E@Z")]
        public static extern void Write_Start(IntPtr obj, byte coreId);
    }
}