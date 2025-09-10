//using Avril.NetworkingClient;
using System;
using System.Text;

namespace Avril.ClientAssembly
{
    public class Framework_Client
    {
        static private Avril.ClientAssembly.Client _client = null;
        //private Networking networkingClient;

        private Int16 threadId = 0;

        public Framework_Client() 
        {
            _client = new Avril.ClientAssembly.Client();
            while (_client == null){ /* Wait whileis created */ }
            System.Console.WriteLine("Created = > Avril.ClientAssembly.Client()");//TEST
        }
        public void Initialise(Avril.ClientAssembly.Framework_Client obj)
        {
            obj.Get_Client().Get_Execute().Initialise_Libraries();
            obj.Get_Client().Get_Execute().Initialise(obj);
            obj.Get_Client().Get_Execute().Initialise_Threads(obj);
/*
            Valve.Sockets.Library.Initialize();
            Valve.Sockets.Library.Initialize(new StringBuilder(1024));
            Valve.Sockets.NetworkingIdentity networkingIdentity = new Valve.Sockets.NetworkingIdentity();
            Valve.Sockets.Library.Initialize(ref networkingIdentity, new StringBuilder(1024));
*/
            //Framework.Get_Client().GetExecute().Create_And_Run_Graphics();//ToDo re enable

        }
        static public Avril.ClientAssembly.Client Get__Client()
        {
            return _client;
        }
        public Avril.ClientAssembly.Client Get_Client()
        {
            return _client;
        }
        //static public Networking GetNetworking()
        //{
        //    return networkingClient;
        //}
    }
}
