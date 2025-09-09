using System.Runtime.InteropServices;
using System.Security;

namespace Avril_FSD
{
    [SuppressUnmanagedCodeSecurity]
    public static class Library_For_LaunchEnableForConcurrentThreadsAt_CLIENT
	{
        [DllImport("LIBLaunchEnableForConcurrentThreadsAtSERVER.dll", EntryPoint = "")]
        public static extern IntPtr Initialise_LaunchEnableForConcurrentThreadsAt();

		[DllImport("LIBLaunchEnableForConcurrentThreadsAtSERVER.dll", EntryPoint = "")]
		public static extern void Request_Wait_Launch(IntPtr obj, byte concurrent_CoreId);

		[DllImport("LIBLaunchEnableForConcurrentThreadsAtSERVER.dll", EntryPoint = "")]
		public static extern void Thread_End(IntPtr obj, byte concurrent_CoreId);

		[DllImport("LIBLaunchEnableForConcurrentThreadsAtSERVER.dll", EntryPoint = "")]
		public static extern byte Get_coreId_To_Launch(IntPtr obj);

		[DllImport("LIBLaunchEnableForConcurrentThreadsAtSERVER.dll", EntryPoint = "")]
		public static extern bool Get_Flag_Active(IntPtr obj);

		[DllImport("LIBLaunchEnableForConcurrentThreadsAtSERVER.dll", EntryPoint = "")]
		public static extern bool Get_Flag_ConcurrentCoreState(IntPtr obj, byte concurrent_CoreId);

		[DllImport("LIBLaunchEnableForConcurrentThreadsAtSERVER.dll", EntryPoint = "")]
		public static extern bool Get_Flag_Idle(IntPtr obj);

		[DllImport("LIBLaunchEnableForConcurrentThreadsAtSERVER.dll", EntryPoint = "")]
		public static extern bool Get_State_LaunchBit(IntPtr obj);

		[DllImport("LIBLaunchEnableForConcurrentThreadsAtSERVER.dll", EntryPoint = "")]
		public static extern void Set_State_ConcurrentCoreState(IntPtr obj, byte concurrent_CoreId, bool value);
	}
}