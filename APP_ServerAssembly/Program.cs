
namespace Avril_FSD_ServerAssembly
{
    static class Program
    {
        static void Main()
        {
            var programId_ServerConcurrency = Avril_FSD.Library_For_Server_Concurrency.Initialise_Server_Assembly();
            var programId_ConcurrencyQue = Avril_FSD.Library_For_LaunchEnableForConcurrentThreadsAt_SERVER.Initialise_LaunchEnableForConcurrentThreadsAt();
            var programId_WriteQue_S_IA = Avril_FSD.Library_For_WriteEnableForThreadsAt_SERVERINPUTACTION.Initialise_WriteEnable();
            var programId_WriteQue_S_OR = Avril_FSD.Library_For_WriteEnableForThreadsAt_SERVEROUTPUTRECIEVE.Initialise_WriteEnable();
            while(true) { }
        }
    }
}