namespace Avril.ServerAssembly
{
    public class Execute
    {
        private Avril.ServerAssembly.Execute_Control _execute_Control;
        private IntPtr _program_ConcurrentQue_C;
        private IntPtr _program_WriteQue_C_OR;

        private Thread[] _threads = {null, null, null, null};
        
        public Execute(int numberOfCores) 
        {
            Set_execute_Control(null);
        }

        public void Initialise_Control(int numberOfCores, Global global)
        {
            Set_execute_Control(new Avril.ServerAssembly.Execute_Control(numberOfCores));
            while (Get_execute_Control() == null) { }
        }

        public void Initialise(Avril.ServerAssembly.Framework_Server obj)
        {
            obj.Get_server().Get_algorithms().Initialise(obj.Get_server().Get_global().Get_numberOfCores());
        }

        public void Initialise_Libraries()
        {
            //_program_ConcurrentQue_C = Avril_FSD.Library_For_LaunchEnableForConcurrentThreadsAt_CLIENT.Initialise_LaunchEnableForConcurrentThreadsAt();
            //_program_WriteQue_C_OR = Avril_FSD.Library_For_WriteEnableForThreadsAt_CLIENTOUTPUTRECIEVE.Initialise_WriteEnable();
        }
        public void Initialise_Threads(Avril.ServerAssembly.Framework_Server obj)
        {
            Set_thread(0, Thread.CurrentThread);

            Set_thread(1, new Thread(obj.Get_server().Get_algorithms().Get_io_ListenRespond().Thread_Output_Respond));
            Get_thread(1).Start();

            for (byte i = 0; i < (obj.Get_server().Get_global().Get_numberOfCores() - 2); i++)
            {
                obj.Get_server().Get_algorithms().Get_concurrent(i).Set_concurrentCoreId(i);
                Set_thread(i, new Thread(obj.Get_server().Get_algorithms().Get_concurrent(i).Thread_Concurrent));
                Get_thread(i).Start();
            }
        }

        public void Create_And_Run_Graphics(Avril.ServerAssembly.Framework_Server obj)
        {
            System.Console.WriteLine("starting = > gameInstance");//TESTBENCH
            using (Avril.ServerAssembly.Game_Instance gameInstance = new Avril.ServerAssembly.Game_Instance())
            {
                gameInstance.Run(obj.Get_server().Get_data().Get_settings().Get_refreshRate());
            }
        }

        public Avril.ServerAssembly.Execute_Control Get_execute_Control()
        {
            return _execute_Control;
        }

        public Thread Get_thread(int index)
        {
            return _threads[index];
        }

        private void Set_execute_Control(Avril.ServerAssembly.Execute_Control execute_Control)
        {
            _execute_Control = execute_Control;
        }
        private void Set_program_ConcurrentQue_C(IntPtr programID)
        {
            _program_ConcurrentQue_C = programID;
        }
        private void Set_program_WriteQue_C_OR(IntPtr programId)
        {
            _program_WriteQue_C_OR = programId;
        }

        private void Set_thread(byte index, Thread thread) 
        {
            _threads[index] = thread;
        }
    }   
}
