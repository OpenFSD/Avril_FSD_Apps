using System.Threading;

namespace Avril.ClientAssembly
{
    public class Execute
    {
        static private Avril.ClientAssembly.Execute_Control execute_Control;
        private IntPtr program_ConcurrentQue_C;
        private IntPtr program_WriteQue_C_OR;

        private Thread[] concurrent = null;
        private Thread liaten_OutputRecieve = null;
        private Thread send_InputAction = null;
        private Thread[] threads = null;
        
        public Execute(int numberOfCores) 
        {
            execute_Control = null;
            threads = new Thread[4];//NUMBER OF CORES
            concurrent = new Thread[2];//NUMBER OF CORES
        }

        public void Initialise_Control(int numberOfCores, Global global)
        {
            execute_Control = new Avril.ClientAssembly.Execute_Control(numberOfCores);
            while (execute_Control == null) { /* Wait while is created */ }
        }

        public void Initialise(Avril.ClientAssembly.Framework_Client obj)
        {
            obj.Get_Client().Get_Algorithms().Initialise(obj.Get_Client().Get_Global().Get_NumCores());
        }

        public void Initialise_Libraries()
        {
            program_ConcurrentQue_C = Avril_FSD.Library_For_LaunchEnableForConcurrentThreadsAt_CLIENT.Initialise_LaunchEnableForConcurrentThreadsAt();
            program_WriteQue_C_OR = Avril_FSD.Library_For_WriteEnableForThreadsAt_CLIENTOUTPUTRECIEVE.Initialise_WriteEnable();
        }
        public void Initialise_Threads(Avril.ClientAssembly.Framework_Client obj)
        {
            threads[0] = Thread.CurrentThread;

            threads[1] = new Thread(obj.Get_Client().Get_Algorithms().GetIO_ListenRespond().Thread_Output_Respond);
            threads[1].Start();

            for (byte i = 0; i < (obj.Get_Client().Get_Global().Get_NumCores() - 2); i++)
            {
                obj.Get_Client().Get_Algorithms().GetConcurrent(i).Set_ConcurrentCoreId(i);
                threads[i] = new Thread(obj.Get_Client().Get_Algorithms().GetConcurrent(i).Thread_Concurrent);
                threads[i].Start();
            }
        }

        public void Create_And_Run_Graphics(Avril.ClientAssembly.Framework_Client obj)
        {
            new Avril.ClientAssembly.Game_Instance().Run(144);
            using (Avril.ClientAssembly.Game_Instance gameInstance = new Avril.ClientAssembly.Game_Instance())
            {
                gameInstance.Run(obj.Get_Client().Get_Data().GetSettings().Get_refreshRate());
            }
        }

        public Avril.ClientAssembly.Execute_Control GetExecute_Control()
        {
            return execute_Control;
        }

        public Thread GetThread(int index)
        {
            return threads[index];
        }
    }   
}
