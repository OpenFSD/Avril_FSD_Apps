
namespace Avril.ClientAssembly
{
    public class Client
    {
        static private Avril.ClientAssembly.Algorithms _algorithms;
        static private Avril.ClientAssembly.Data _data;
        static private Avril.ClientAssembly.Execute _execute;
        static private Avril.ClientAssembly.Global _global;

        public Client() 
        {
            _global = new Avril.ClientAssembly.Global();
            while (_global == null) { /* Wait while is created */ }

            _algorithms = new Avril.ClientAssembly.Algorithms(_global.Get_NumCores());
            while (_algorithms == null) { /* Wait while is created */ }

            _data = new Avril.ClientAssembly.Data();
            while (_data == null) { /* Wait while is created */ }
            _data.InitialiseControl();

            _execute = new Avril.ClientAssembly.Execute(_global.Get_NumCores());
            while (_execute == null) { /* Wait while is created */ }
            _execute.Initialise_Control(_global.Get_NumCores(), _global);

            System.Console.WriteLine("Avril.ClientAssembly: Client");
        }

        public Avril.ClientAssembly.Algorithms Get_Algorithms()
        {
            return _algorithms;
        }
        public Avril.ClientAssembly.Data Get_Data()
        {
            return _data;
        }
        public Avril.ClientAssembly.Execute Get_Execute()
        {
            return _execute;
        }

        public Avril.ClientAssembly.Global Get_Global()
        {
            return _global;
        }
    }
}