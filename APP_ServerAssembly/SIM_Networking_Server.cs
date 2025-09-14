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
        static public void SIM_Server_Recieve(Avril.ServerAssembly.Framework_Server obj)
        {
            _server.WaitForConnectionAsync();
            Avril_FSD.Library_For_WriteEnableForThreadsAt_SERVERINPUTACTION.Write_Start(Avril_FSD.Library_For_Server_Concurrency.Get_program_WriteEnableStack_ServerInputAction(obj), 0);

            byte[] buffer = new byte[1];
            int bytesRead = _server.Read(buffer, 0, buffer.Length);
            byte praiseEventId = buffer[0];
            Avril_FSD.Library_For_Server_Concurrency.Set_PraiseEventId((sbyte)praiseEventId);//TODO: change to byte

            buffer = new byte[1];
            bytesRead = _server.Read(buffer, 1, buffer.Length);
            byte playerID = buffer[0];
            Avril_FSD.Library_For_Server_Concurrency.Set_playerId((sbyte)playerID);//TODO: change to byte

            Avril_FSD.Library_For_Server_Concurrency.Select_Set_Intput_Subset(obj, praiseEventId);
            switch (praiseEventId)
            {
// USER IMPLEMENTATION - ABCDE
                case 0:

                    break;

                case 1:
                    buffer = new byte[8];
                    bytesRead = _server.Read(buffer, 2, buffer.Length);
                    float temp = System.BitConverter.ToSingle(buffer, 0);
                    Avril_FSD.Library_For_Praise_1_Events.Set_Praise1_Input_mouseDelta_X(temp);
                    temp = System.BitConverter.ToSingle(buffer, 4);
                    Avril_FSD.Library_For_Praise_1_Events.Set_Praise1_Input_mouseDelta_X(temp);
                    break;
            }

        }
        static public void SIM_Server_Send(Avril.ServerAssembly.Framework_Server obj)
        {
            _server.WaitForConnection();
            switch (obj.Get_server().Get_data().Get_output_Instnace().Get_FRONT_outputDoubleBuffer(obj).Get_praiseEventId())
            {
// USER IMPLEMENTATION - ABCDE
                case 0:

                    break;

                case 1:
                    byte[] buffer = new byte[38];
                    buffer[0] = obj.Get_server().Get_data().Get_output_Instnace().Get_FRONT_outputDoubleBuffer(obj).Get_praiseEventId();
                    buffer[1] = obj.Get_server().Get_data().Get_output_Instnace().Get_FRONT_outputDoubleBuffer(obj).Get_out_playerId();
                    Avril.ServerAssembly.Praise_Files.Praise1_Output subset = (Avril.ServerAssembly.Praise_Files.Praise1_Output)obj.Get_server().Get_data().Get_input_Instnace().Get_BACK_inputDoubleBuffer(obj).Get_praiseInputBuffer_Subset();
                    byte[] byteArray = BitConverter.GetBytes(subset.Get_fowards().X);
                    for (ushort index = 2; index < 6; index++)
                    {
                        buffer[index] = byteArray[index];
                    }
                    byteArray = BitConverter.GetBytes(subset.Get_fowards().Y);
                    for (ushort index = 6; index < 10; index++)
                    {
                        buffer[index] = byteArray[index];
                    }
                    byteArray = BitConverter.GetBytes(subset.Get_fowards().Z);
                    for (ushort index = 10; index < 14; index++)
                    {
                        buffer[index] = byteArray[index];
                    }
                    byteArray = BitConverter.GetBytes(subset.Get_right().X);
                    for (ushort index = 14; index < 18; index++)
                    {
                        buffer[index] = byteArray[index];
                    }
                    byteArray = BitConverter.GetBytes(subset.Get_right().Y);
                    for (ushort index = 18; index < 22; index++)
                    {
                        buffer[index] = byteArray[index];
                    }
                    byteArray = BitConverter.GetBytes(subset.Get_right().Z);
                    for (ushort index = 22; index < 26; index++)
                    {
                        buffer[index] = byteArray[index];
                    }
                    byteArray = BitConverter.GetBytes(subset.Get_up().X);
                    for (ushort index = 26; index < 30; index++)
                    {
                        buffer[index] = byteArray[index];
                    }
                    byteArray = BitConverter.GetBytes(subset.Get_up().Y);
                    for (ushort index = 30; index < 34; index++)
                    {
                        buffer[index] = byteArray[index];
                    }
                    byteArray = BitConverter.GetBytes(subset.Get_up().Z);
                    for (ushort index = 34; index < 38; index++)
                    {
                        buffer[index] = byteArray[index];
                    }
                    _server.Write(buffer, 0, buffer.Length);
                    break;
            }
        }
    }
}
