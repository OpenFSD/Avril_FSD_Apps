namespace Avril.ClientAssembly
{
    public class Framework_Client
    {
        static private Avril.ClientAssembly.Client _client;
        //private Networking networkingClient;

        private Int16 threadId = 0;

        public Framework_Client() 
        {
            Set_client(new Avril.ClientAssembly.Client());
            while (Get_client() == null){ /* Wait whileis created */ }
            System.Console.WriteLine("Created = > Avril.ClientAssembly.Client()");//TESTBENCH
        }
        public void Initialise(Avril.ClientAssembly.Framework_Client obj)
        {
            obj.Get_client().Get_data().Get_data_Control().Initialise(obj);
            System.Console.WriteLine("alpha");//TESTBENCH
            //obj.Get_client().Get_execute().Initialise_Libraries();
            System.Console.WriteLine("bravo");//TESTBENCH
            obj.Get_client().Get_execute().Initialise(obj);
            System.Console.WriteLine("charlie");//TESTBENCH
            obj.Get_client().Get_execute().Initialise_Threads(obj);
            System.Console.WriteLine("delta");//TESTBENCH
            obj.Get_client().Get_execute().Create_And_Run_Graphics(obj);
            System.Console.WriteLine("foxtrot");//TESTBENCH
        }
        static public Avril.ClientAssembly.Client Get__client()
        {
            return _client;
        }
        public Avril.ClientAssembly.Client Get_client()
        {
            return _client;
        }
        private void Set_client(Avril.ClientAssembly.Client value)
        {
            _client = value;
        }
    }
}
