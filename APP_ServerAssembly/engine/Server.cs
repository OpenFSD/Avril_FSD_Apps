namespace Avril.ServerAssembly
{
    public class Server
    {
        static private Avril.ServerAssembly.Algorithms algorithms;
        static private Avril.ServerAssembly.Data data;
        static private Avril.ServerAssembly.Execute execute;
        static private Avril.ServerAssembly.Global global;

        public Server()
        {
            global = new Avril.ServerAssembly.Global();
            while (global == null) { /* Wait while is created */ }

            algorithms = new Avril.ServerAssembly.Algorithms(global.Get_NumCores());
            while (algorithms == null) { /* Wait while is created */ }

            data = new Avril.ServerAssembly.Data();
            while (data == null) { /* Wait while is created */ }
            data.InitialiseControl();

            execute = new Avril.ServerAssembly.Execute();
            while (execute == null) { /* Wait while is created */ }
            execute.Initialise_Control(global.Get_NumCores(), global);

            System.Console.WriteLine("Avril.ServerAssembly: Server");
        }

        public Avril.ServerAssembly.Algorithms GetAlgorithms()
        {
            return algorithms;
        }
        public Avril.ServerAssembly.Data GetData()
        {
            return data;
        }

        public Avril.ServerAssembly.Global GetGlobal()
        {
            return global;
        }

        public Avril.ServerAssembly.Execute GetExecute()
        {
            return execute;
        }
    }
}