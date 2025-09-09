using System.Runtime.InteropServices;

namespace Avril.ServerAssembly
{
    public class Framework
    {
        static private Avril.ServerAssembly.Server game_server = null;
        //static private Valve.Networking networkingServer = null;

        public Framework()
        {
            System.Console.WriteLine("entered => Avril.ServerAssembly.Framework()");//TestBench

            game_server = new Avril.ServerAssembly.Server();
            while (game_server == null) { /* Wait whileis created */ }
            game_server.GetExecute().Initialise();
            System.Console.WriteLine("created => Avril.ServerAssembly.Server()");//TestBench

            //Avril.Server_IO.Library.Create_Hosting_Server();
           // System.Console.WriteLine("created => Server_Library.Framework_Server()");//TestBench

            game_server.GetExecute().Initialise_Threads();//todo

            //Avril.ServerAssembly.Framework.GetGameServer().GetExecute().Create_And_Run_Graphics();

            System.Console.WriteLine("skipped => Valve.Networking()");//TestBench
        }

        static public Avril.ServerAssembly.Server GetGameServer()
        {
            return game_server;
        }

        /*
        static public Valve.Networking GetNetworkingServer()
        {
             return networkingServer;
        }
        */
    }
}
