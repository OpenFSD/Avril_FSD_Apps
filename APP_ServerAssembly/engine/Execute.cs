
namespace Avril.ServerAssembly
{
    public class Execute
    {
        static private Avril.ServerAssembly.Execute_Control execute_Control = null;
        private Thread input_Listen = null;
        private Thread output_Send = null;

        public Execute()
        {
            input_Listen = null;
            output_Send = null;
        }
        public void Initialise()
        {
            Avril.ServerAssembly.Framework.GetGameServer().GetAlgorithms().Initialise(Avril.ServerAssembly.Framework.GetGameServer().GetGlobal().Get_NumCores());
        }

        public void Initialise_Control(
            byte numberOfCores,
            Global global
        )
        {
            execute_Control = new Avril.ServerAssembly.Execute_Control(numberOfCores);
            while (execute_Control == null) { /* Wait while is created */ }
        }

        public void Initialise_Threads()
        {
            input_Listen = new Thread(Avril.ServerAssembly.Framework.GetGameServer().GetAlgorithms().GetIO_ListenRespond().Thread_Input_Listen);
            input_Listen.Start();

            output_Send = new Thread(Avril.ServerAssembly.Framework.GetGameServer().GetAlgorithms().GetIO_ListenRespond().Thread_Output_Send);
            output_Send.Start();
        }

        public void Create_And_Run_Graphics()
        {
            using (Avril.ServerAssembly.Game_Instance gameInstance = new Avril.ServerAssembly.Game_Instance())
            {
                gameInstance.Run(Avril.ServerAssembly.Framework.GetGameServer().GetData().GetSettings().Get_refreshRate());
            }
        }

        public Execute_Control GetExecute_Control()
        {
            return execute_Control;
        }
    }
}