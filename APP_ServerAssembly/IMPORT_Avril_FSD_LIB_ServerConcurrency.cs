using System.Runtime.InteropServices;
using System.Security;

namespace Avril_FSD
{
    [SuppressUnmanagedCodeSecurity]
    public static class Library_For_Server_Concurrency
    {
        [DllImport("LIBServerConcurrency.dll", EntryPoint = "")]
        public static extern bool Flip_InBufferToWrite();
        
        [DllImport("LIBServerConcurrency.dll", EntryPoint = "")]
        public static extern bool Flip_OutBufferToWrite();

        [DllImport("LIBServerConcurrency.dll", EntryPoint = "?Initialise_Server_Assembly@CLIBServerConcurrency@Avril_FSD@@SAPAXXZ")]
        public static extern IntPtr Initialise_Server_Assembly();

        [DllImport("LIBServerConcurrency.dll", EntryPoint = "?Pop_Stack_Output@CLIBServerConcurrency@Avril_FSD@@SAXPAVFramework_Server@2@@Z")]
        public static extern void Pop_Stack_Output();

        [DllImport("LIBServerConcurrency.dll", EntryPoint = "?Push_Stack_InputPraises@CLIBServerConcurrency@Avril_FSD@@SAXPAVFramework_Server@2@@Z")]
        public static extern void Push_Stack_InputPraises();

        [DllImport("LIBServerConcurrency.dll", EntryPoint = "")]
        public static extern void Select_Set_Intput_Subset(Avril.ServerAssembly.Framework_Server obj, ushort priaseEventId);

        [DllImport("LIBServerConcurrency.dll", EntryPoint = "?Get_Flag_isNewInputDataReady@CLIBServerConcurrency@Avril_FSD@@SA_NPAVFramework_Server@2@@Z")]
        public static extern bool Get_flag_isNewInputDataReady();

        [DllImport("LIBServerConcurrency.dll", EntryPoint = "?Get_flag_isNewOutputDataReady@CLIBServerConcurrency@Avril_FSD@@SA_NPAVFramework_Server@2@@Z")]
        public static extern bool Get_flag_isNewOutputDataReady();

        [DllImport("LIBServerConcurrency.dll", EntryPoint = "?Get_Flag_IsStackLoaded_Server_InputAction@CLIBServerConcurrency@Avril_FSD@@SA_NPAVFramework_Server@2@@Z")]
        public static extern bool Get_flag_IsStackLoaded_Server_InputAction();

        [DllImport("LIBServerConcurrency.dll", EntryPoint = "?Get_Flag_IsStackLoaded_Server_OutputRecieve@CLIBServerConcurrency@Avril_FSD@@SA_NPAVFramework_Server@2@@Z")]
        public static extern bool Get_flag_IsStackLoaded_Server_OutputRecieve();

        [DllImport("LIBServerConcurrency.dll", EntryPoint = "?GetFlag_ServerConcurrency_Initialised@CLIBServerConcurrency@Avril_FSD@@SA_NPAVFramework_Server@2@@Z")]
        public static extern bool Get_flag_ServerConcurrency_Initialised();

        [DllImport("LIBServerConcurrency.dll", EntryPoint = "")]
        public static extern void Set_flag_isNewInputDataReady(bool value);

        [DllImport("LIBServerConcurrency.dll", EntryPoint = "")]
        public static extern void Set_flag_isNewOutputDataReady(bool value);
        

        // Praise Event Id
        [DllImport("LIBServerConcurrency.dll", EntryPoint = "?Get_PraiseEventId@CLIBServerConcurrency@Avril_FSD@@SADPAVFramework_Server@2@@Z")]
        public static extern byte Get_PraiseEventId();

        [DllImport("LIBServerConcurrency.dll", EntryPoint = "?Set_PraiseEventId@CLIBServerConcurrency@Avril_FSD@@SAXPAVFramework_Server@2@D@Z")]
        public static extern void Set_PraiseEventId(sbyte value);
    }

    // Praise 0 Data
    [SuppressUnmanagedCodeSecurity]
    internal static class Library_For_Praise_0_Events
    {
        [DllImport("LIBServerConcurrency.dll", EntryPoint = "?Get_Praise0_Input_IsPingActive@CLIBServerConcurrency@Avril_FSD@@SA_NPAVFramework_Server@2@@Z")]
        public static extern bool Get_Praise0_Input_IsPingActive();

        [DllImport("LIBServerConcurrency.dll", EntryPoint = "?Set_Praise0_Input_IsPingActive@CLIBServerConcurrency@Avril_FSD@@SAXPAVFramework_Server@2@_N@Z")]
        public static extern void Set_Praise0_Input_IsPingActive(bool value);

        [DllImport("LIBServerConcurrency.dll", EntryPoint = "?Get_Praise0_Output_IsPingActive@CLIBServerConcurrency@Avril_FSD@@SA_NPAVFramework_Server@2@@Z")]
        public static extern void Get_Praise0_Output_IsPingActive();

        [DllImport("LIBServerConcurrency.dll", EntryPoint = "?Set_Praise0_Output_IsPingActive@CLIBServerConcurrency@Avril_FSD@@SAXPAVFramework_Server@2@_N@Z")]
        public static extern void Set_Praise0_Output_IsPingActive(bool value);
    }
    // Praise 1 Data
    [SuppressUnmanagedCodeSecurity]
    internal static class Library_For_Praise_1_Events
    {
        // Praise 1 Data
        [DllImport("LIBServerConcurrency.dll", EntryPoint = "?Get_Praise1_Input_mouseDelta_X@CLIBServerConcurrency@Avril_FSD@@SAMPAVFramework_Server@2@@Z")]
        public static extern float Get_Praise1_Input_mouseDelta_X();

        [DllImport("LIBServerConcurrency.dll", EntryPoint = "?Get_Praise1_Input_mouseDelta_Y@CLIBServerConcurrency@Avril_FSD@@SAMPAVFramework_Server@2@@Z")]
        public static extern float Get_Praise1_Input_mouseDelta_Y();

        [DllImport("LIBServerConcurrency.dll", EntryPoint = "?Set_Praise1_Input_mouseDelta_X@CLIBServerConcurrency@Avril_FSD@@SAXPAVFramework_Server@2@M@Z")]
        public static extern void Set_Praise1_Input_mouseDelta_X(float value);

        [DllImport("LIBServerConcurrency.dll", EntryPoint = "?Set_Praise1_Input_mouseDelta_Y@CLIBServerConcurrency@Avril_FSD@@SAXPAVFramework_Server@2@M@Z")]
        public static extern void Set_Praise1_Input_mouseDelta_Y(float value);

        [DllImport("LIBServerConcurrency.dll", EntryPoint = "?Get_Praise1_Output_Player_Fowards@CLIBServerConcurrency@Avril_FSD@@SA?AV?$array@M$02@std@@PAVFramework_Server@2@@Z")]
        public static extern float[] Get_Praise1_Output_Player_Fowards();

        [DllImport("LIBServerConcurrency.dll", EntryPoint = "?Get_Praise1_Output_Player_Up@CLIBServerConcurrency@Avril_FSD@@SA?AV?$array@M$02@std@@PAVFramework_Server@2@@Z")]
        public static extern float[] Get_Praise1_Output_Player_Up();

        [DllImport("LIBServerConcurrency.dll", EntryPoint = "?Get_Praise1_Output_Player_Right@CLIBServerConcurrency@Avril_FSD@@SA?AV?$array@M$02@std@@PAVFramework_Server@2@@Z")]
        public static extern float[] Get_Praise1_Output_Player_Right();

        [DllImport("LIBServerConcurrency.dll", EntryPoint = "?Set_Praise1_Output_Player_Fowards@CLIBServerConcurrency@Avril_FSD@@SAXPAVFramework_Server@2@V?$array@M$02@std@@@Z")]
        public static extern void Set_Praise1_Output_Player_Fowards(float[] value);

        [DllImport("LIBServerConcurrency.dll", EntryPoint = "?Set_Praise1_Output_Player_Up@CLIBServerConcurrency@Avril_FSD@@SAXPAVFramework_Server@2@V?$array@M$02@std@@@Z")]
        public static extern void Set_Praise1_Output_Player_Up(float[] value);

        [DllImport("LIBServerConcurrency.dll", EntryPoint = "?Set_Praise1_Output_Player_Right@CLIBServerConcurrency@Avril_FSD@@SAXPAVFramework_Server@2@V?$array@M$02@std@@@Z")]
        public static extern void Set_Praise1_Output_Player_Right(float[] value);

    }
    // Praise 2 Data
    [SuppressUnmanagedCodeSecurity]
    internal static class Library_For_Praise_2_Events
    {

    }

}
