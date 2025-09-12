using Avril.ServerAssembly;
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
        static public void SIM_Server_Recieve(Avril.ServerAssembly.Framework_Server obj, ushort priaseEventId)
        {
            _server.WaitForConnectionAsync();
            Avril_FSD.Library_For_Server_Concurrency.Select_Set_Intput_Subset(obj, priaseEventId);
            switch (priaseEventId)
            {
                case 0:

                    break;

                case 1:
                    byte[] buffer = new byte[8];
                    int bytesRead = _server.Read(buffer, 0, buffer.Length);
                    float temp = System.BitConverter.ToSingle(buffer, 0);
                    Avril_FSD.Library_For_Praise_1_Events.Set_Praise1_Input_mouseDelta_X(temp);
                    temp = System.BitConverter.ToSingle(buffer, 4);
                    Avril_FSD.Library_For_Praise_1_Events.Set_Praise1_Input_mouseDelta_X(temp);
                    break;
            }

        }
        static public void SIM_Server_Send(Avril.ServerAssembly.Framework_Server obj, ushort priaseEventId)
        {
            _server.WaitForConnection();
            switch (priaseEventId)
            {
                case 0:

                    break;

                case 1:
                    byte[] buffer = new byte[36];
                    Avril.ServerAssembly.Praise_Files.Praise1_Output subset = (Avril.ServerAssembly.Praise_Files.Praise1_Output)obj.Get_server().Get_data().Get_input_Instnace().Get_BACK_inputDoubleBuffer(obj).Get_praiseInputBuffer_Subset();
                    byte[] byteArray = BitConverter.GetBytes(subset.Get_fowards().X);
                    for (ushort index = 0; index < 4; index++)
                    {
                        buffer[index] = byteArray[index];
                    }
                    byteArray = BitConverter.GetBytes(subset.Get_fowards().Y);
                    for (ushort index = 4; index < 8; index++)
                    {
                        buffer[index] = byteArray[index];
                    }
                    byteArray = BitConverter.GetBytes(subset.Get_fowards().Z);
                    for (ushort index = 8; index < 12; index++)
                    {
                        buffer[index] = byteArray[index];
                    }
                    byteArray = BitConverter.GetBytes(subset.Get_right().X);
                    for (ushort index = 0; index < 4; index++)
                    {
                        buffer[index + 12] = byteArray[index];
                    }
                    byteArray = BitConverter.GetBytes(subset.Get_right().Y);
                    for (ushort index = 4; index < 8; index++)
                    {
                        buffer[index + 12] = byteArray[index];
                    }
                    byteArray = BitConverter.GetBytes(subset.Get_right().Z);
                    for (ushort index = 8; index < 12; index++)
                    {
                        buffer[index + 12] = byteArray[index];
                    }
                    byteArray = BitConverter.GetBytes(subset.Get_up().X);
                    for (ushort index = 0; index < 4; index++)
                    {
                        buffer[index + 24] = byteArray[index];
                    }
                    byteArray = BitConverter.GetBytes(subset.Get_up().Y);
                    for (ushort index = 4; index < 8; index++)
                    {
                        buffer[index + 24] = byteArray[index];
                    }
                    byteArray = BitConverter.GetBytes(subset.Get_up().Z);
                    for (ushort index = 8; index < 12; index++)
                    {
                        buffer[index + 24] = byteArray[index];
                    }
                    _server.Write(buffer, 0, buffer.Length);
                    break;
            }
        }
    }
}
