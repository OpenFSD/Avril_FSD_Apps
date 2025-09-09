using Avril.ServerAssembly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avril.ServerAssembly.Outputs
{
    public class Output_Instance
    {
        static private Avril.ServerAssembly.Outputs.Output empty_OutputBuffer;
        static private Avril.ServerAssembly.Outputs.Output[] outputDoubleBuffer;
        static private Avril.ServerAssembly.Outputs.Output transmitOutputBuffer;

        public Output_Instance()
        {
            empty_OutputBuffer = new Avril.ServerAssembly.Outputs.Output();
            while (empty_OutputBuffer == null) { /* Wait while is created */ }
            empty_OutputBuffer.InitialiseControl();

            outputDoubleBuffer = new Avril.ServerAssembly.Outputs.Output[2];
            for (byte index = 0; index < 2; index++)
            {
                outputDoubleBuffer[index] = empty_OutputBuffer;
                while (outputDoubleBuffer == null) { /* Wait while is created */ }
            }

            transmitOutputBuffer = new Avril.ServerAssembly.Outputs.Output();
            while (transmitOutputBuffer == null) { /* Wait while is created */ }

        }

        private ushort BoolToInt16(bool value)
        {
            ushort temp = new ushort();
            if (value)
            {
                temp = 1;
            }
            else if (!value)
            {
                temp = 0;
            }
            return temp;
        }

        public Avril.ServerAssembly.Outputs.Output GetEmptyOutput()
        {
            return empty_OutputBuffer;
        }
        public Avril.ServerAssembly.Outputs.Output GetBuffer_FrontOutputDouble()
        {
            return outputDoubleBuffer[BoolToInt16(Avril.ServerAssembly.Framework.GetGameServer().GetData().GetState_Buffer_OutputPraise_SideToWrite())];
        }
        public Avril.ServerAssembly.Outputs.Output GetBuffer_BackOutputDouble()
        {
            return outputDoubleBuffer[BoolToInt16(!Avril.ServerAssembly.Framework.GetGameServer().GetData().GetState_Buffer_OutputPraise_SideToWrite())];
        }

        public Avril.ServerAssembly.Outputs.Output GetTransmitOutputBuffer()
        {
            return transmitOutputBuffer;
        }


        public void SetBuffer_Output(Avril.ServerAssembly.Outputs.Output value)
        {
            outputDoubleBuffer[BoolToInt16(!Framework.GetGameServer().GetData().GetState_Buffer_InputPraise_SideToWrite())] = value;
        }
    }
}
