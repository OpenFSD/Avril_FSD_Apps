using System;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Text;

namespace SIMULATION
{
    class SIM_Networking
    {
        static private NamedPipeClientStream _client = null;
        public SIM_Networking() 
        { 
        
        }
        static public void Initialise_Cleint()
        {
            using (_client = new NamedPipeClientStream(".", "Avril_FSD", PipeDirection.In))
            {

            }
        }

        static public void SIM_Client_Send(Avril.ClientAssembly.Framework_Client obj, ushort priaseEventId)
        {
            _client.Connect();
            switch (priaseEventId)
            {
                case 0:

                    break;

                case 1:
                    byte[] buffer = new byte[8];
                    Avril.ClientAssembly.Praise_Files.Praise1_Input subset = (Avril.ClientAssembly.Praise_Files.Praise1_Input)obj.Get_client().Get_data().Get_input_Instnace().Get_BACK_inputDoubleBuffer(obj).Get_praiseInputBuffer_Subset();
                    byte[] byteArray = BitConverter.GetBytes(subset.Get_Mouse_X());
                    for (ushort index = 0; index < 4; index++)
                    {
                        buffer[index] = byteArray[index];
                    }
                    byteArray = BitConverter.GetBytes(subset.Get_Mouse_Y());
                    for (ushort index = 0; index < 4; index++)
                    {
                        buffer[index + 4] = byteArray[index];
                    }
                    _client.Write(buffer, 0, buffer.Length);
                    break;
            }

        }

        static public void SIM_Client_Recieve(ushort priaseEventId)
        {
            _client.Connect();
            switch (priaseEventId)
            {
                case 0:

                    break;

                case 1:

                    break;
            }
            byte[] buffer = new byte[256];
            int bytesRead = _client.Read(buffer, 0, buffer.Length);
            string receivedMessage = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine($"CLIENT Received: {receivedMessage}");
        }
    }
}
