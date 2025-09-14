namespace Avril.ServerAssembly
{
    public class Execute
    {
        private Avril.ServerAssembly.Execute_Control _execute_Control;
        private Thread[] _threads = {null, null, null, null};
        private IntPtr _program_ServerConcurrency;

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
            Set_program_ServerConcurrency(Avril_FSD.Library_For_Server_Concurrency.Initialise_Server_Assembly());
        }
        public void Initialise_Threads(Avril.ServerAssembly.Framework_Server obj)
        {
            Set_thread(0, Thread.CurrentThread);

            Set_thread(1, new Thread(obj.Get_server().Get_algorithms().Get_io_ListenRespond().Thread_Output_Respond));
            Get_thread(1).Start();
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

        public IntPtr Get_program_ServerConcurrency()
        {
            return _program_ServerConcurrency;
        }

        private void Set_execute_Control(Avril.ServerAssembly.Execute_Control execute_Control)
        {
            _execute_Control = execute_Control;
        }

        private void Set_thread(byte index, Thread thread) 
        {
            _threads[index] = thread;
        }

        private void Set_program_ServerConcurrency(IntPtr handle)
        {
            _program_ServerConcurrency = handle;
        }
    }   
}
