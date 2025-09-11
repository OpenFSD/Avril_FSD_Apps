using System;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Text;

namespace SIMULATION
{
    class SIM_Networking_Server
    {
        static private NamedPipeServerStream _server = null;

        public SIM_Networking_Server() 
        { 
        
        }
        static public void Initialise_Server()
        {
            using (_server = new NamedPipeServerStream("Avril_FSD", PipeDirection.InOut))
            {

            }
        }
        static public void SIM_Server_Recieve(ushort priaseEventId)
        {
            _server.WaitForConnectionAsync();
            switch (priaseEventId)
            {
                case 0:
                    
                    break;

                case 1:
                    byte[] buffer = new byte[8];
                    int bytesRead = _server.Read(buffer, 0, buffer.Length);
                    byte[] receivedMessage = buffer;
                    break;
            }
        }
        static public void SIM_Server_Send(ushort priaseEventId)
        {
            _server.WaitForConnection();
            switch (priaseEventId)
            {
                case 0:

                    break;

                case 1:

                    break;
            }
            byte[] message = Encoding.UTF8.GetBytes("Hello from Sender - serverside!");
            _server.Write(message, 0, message.Length);
        }
    }
}
