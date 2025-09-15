using OpenTK;
using System.IO.Pipes;

namespace SIMULATION
{
    class SIM_Networking
    {
        static private NamedPipeClientStream _client = null;
        public SIM_Networking() 
        { 
        
        }

        static public void SIM_Client_Send(Avril.ClientAssembly.Framework_Client obj)
        {
            using (_client = new NamedPipeClientStream("Avril_FSD_InputAction_S", "Avril_FSD_InputAction_C", PipeDirection.Out))
            {
                _client.Connect();
                byte praiseEventId = obj.Get_client().Get_data().Get_input_Instnace().Get_BACK_inputDoubleBuffer(obj).Get_praiseEventId();
                byte playerId = obj.Get_client().Get_data().Get_input_Instnace().Get_BACK_inputDoubleBuffer(obj).Get_playerId();
                switch (praiseEventId)
                {
                // USER IMPLAEMENTATION - ABCDE
                case 0:

                    break;

                case 1:
                    byte[] buffer = new byte[10];
                    buffer[0] = praiseEventId;
                    buffer[1] = playerId;
                    Avril.ClientAssembly.Praise_Files.Praise1_Input subset = (Avril.ClientAssembly.Praise_Files.Praise1_Input)obj.Get_client().Get_data().Get_input_Instnace().Get_BACK_inputDoubleBuffer(obj).Get_praiseInputBuffer_Subset();
                    byte[] byteArray = BitConverter.GetBytes(subset.Get_Mouse_X());
                    for (ushort index = 0; index < 4; index++)
                    {
                        buffer[index + 2] = byteArray[index];
                    }
                    byteArray = BitConverter.GetBytes(subset.Get_Mouse_Y());
                    for (ushort index = 0; index < 4; index++)
                    {
                        buffer[index + 6] = byteArray[index];
                    }
                    _client.Write(buffer, 0, buffer.Length);
                    break;
                }
                _client.Close();
            }

        }

        static public void SIM_Client_Recieve(Avril.ClientAssembly.Framework_Client obj)
        {
            using (_client = new NamedPipeClientStream("Avril_FSD_OutputRecieve_S", "Avril_FSD_OutputRecieve_C", PipeDirection.In))
            {
                _client.Connect();
                Avril_FSD.Library_For_WriteEnableForThreadsAt_CLIENTOUTPUTRECIEVE.Write_Start(obj.Get_client().Get_execute().Get_program_WriteQue_C_OR(), 1);

                byte[] buffer = new byte[1];
                int bytesRead = _client.Read(buffer, 0, buffer.Length);
                byte priaseEventId = buffer[0];
                obj.Get_client().Get_data().Get_output_Instnace().Get_BACK_outputDoubleBuffer(obj).Set_praiseEventId(priaseEventId);

                buffer = new byte[1];
                bytesRead = _client.Read(buffer, 1, buffer.Length);
                byte playerId = buffer[1];
                obj.Get_client().Get_data().Get_output_Instnace().Get_BACK_outputDoubleBuffer(obj).Set_playerId(playerId);

                switch (priaseEventId)
                {
                case 0:

                    break;

                case 1:

                    Avril.ClientAssembly.Praise_Files.Praise1_Output output_Subset = (Avril.ClientAssembly.Praise_Files.Praise1_Output)obj.Get_client().Get_data().Get_output_Instnace().Get_BACK_outputDoubleBuffer(obj).Get_praiseOutputBuffer_Subset();
                    buffer = new byte[12];
                    bytesRead = _client.Read(buffer, 2, buffer.Length);
                    float temp_X = System.BitConverter.ToSingle(buffer, 0);
                    float temp_Y = System.BitConverter.ToSingle(buffer, 4);
                    float temp_Z = System.BitConverter.ToSingle(buffer, 8);
                    Vector3 temp_Vec = new Vector3(temp_X, temp_Y, temp_Z);
                    output_Subset.Set_fowards(temp_Vec);

                    buffer = new byte[12];
                    bytesRead = _client.Read(buffer, 14, buffer.Length);
                    temp_X = System.BitConverter.ToSingle(buffer, 0);
                    temp_Y = System.BitConverter.ToSingle(buffer, 4);
                    temp_Z = System.BitConverter.ToSingle(buffer, 8);
                    temp_Vec = new Vector3(temp_X, temp_Y, temp_Z);
                    output_Subset.Set_right(temp_Vec);

                    buffer = new byte[12];
                    bytesRead = _client.Read(buffer, 26, buffer.Length);
                    temp_X = System.BitConverter.ToSingle(buffer, 0);
                    temp_Y = System.BitConverter.ToSingle(buffer, 4);
                    temp_Z = System.BitConverter.ToSingle(buffer, 8);
                    temp_Vec = new Vector3(temp_X, temp_Y, temp_Z);
                    output_Subset.Set_up(temp_Vec);
                    break;
                }
            }
        }
    }
}
