namespace Avril.ServerAssembly
{
    public class Framework_Server
    {
        static private Avril.ServerAssembly.Server _server;
        //private Networking networkingClient;

        private Int16 threadId = 0;

        public Framework_Server() 
        {
            Set_server(new Avril.ServerAssembly.Server());
            while (Get_server() == null){ /* Wait whileis created */ }
            System.Console.WriteLine("Created = > Avril.ServerAssembly.Server()");//TESTBENCH
        }
        public void Initialise(Avril.ServerAssembly.Framework_Server obj)
        {
            obj.Get_server().Get_data().Get_data_Control().Initialise(obj);
            System.Console.WriteLine("alpha");//TESTBENCH
            obj.Get_server().Get_execute().Initialise_Libraries();
            System.Console.WriteLine("bravo");//TESTBENCH
            obj.Get_server().Get_execute().Initialise(obj);
            System.Console.WriteLine("charlie");//TESTBENCH
            obj.Get_server().Get_execute().Initialise_Threads(obj);
            System.Console.WriteLine("delta");//TESTBENCH
            //obj.Get_server().Get_execute().Create_And_Run_Graphics(obj);
            System.Console.WriteLine("foxtrot");//TESTBENCH
        }
        static public Avril.ServerAssembly.Server Get__server()
        {
            return _server;
        }
        public Avril.ServerAssembly.Server Get_server()
        {
            return _server;
        }
        private void Set_server(Avril.ServerAssembly.Server value)
        {
            _server = value;
        }
    }
}
