
namespace Avril_FSD_CLientAssembly
{
    static class Program
    {
        static void Main()
        {
            var programId_ConcurrencyQue_C = Avril_FSD.Library_For_LaunchEnableForConcurrentThreadsAt_CLIENT.Initialise_LaunchEnableForConcurrentThreadsAt();
            var programId_WriteQue_C_OR = Avril_FSD.Library_For_WriteEnableForThreadsAt_CLIENTOUTPUTRECIEVE.Initialise_WriteEnable();
            while (true) { }
        }
    }
}