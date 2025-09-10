using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avril.ClientAssembly.Outputs
{
    public class Output_Instance
    {
        static private Avril.ClientAssembly.Outputs.Output empty_OutputBuffer;
        static private Avril.ClientAssembly.Outputs.Output[] outputDoubleBuffer;
        static private Avril.ClientAssembly.Outputs.Output transmitOutputBuffer;

        public Output_Instance() 
        {
            empty_OutputBuffer = new Avril.ClientAssembly.Outputs.Output();
            while (empty_OutputBuffer == null) { /* Wait while is created */ }
            empty_OutputBuffer.InitialiseControl();

            outputDoubleBuffer = new Avril.ClientAssembly.Outputs.Output[2];
            for (byte index = 0; index < 2; index++)
            {
                outputDoubleBuffer[index] = empty_OutputBuffer;
                while (outputDoubleBuffer == null) { /* Wait while is created */ }
            }

            transmitOutputBuffer = new Avril.ClientAssembly.Outputs.Output();
            while (transmitOutputBuffer == null) { /* Wait while is created */ }

        }

        private UInt16 BoolToInt16(bool value)
        {
            UInt16 temp = new UInt16();
            if (value)
            {
                temp = (UInt16)1;
            }
            else if (!value)
            {
                temp = (UInt16)0;
            }
            return temp;
        }

        public Avril.ClientAssembly.Outputs.Output GetEmptyOutput()
        {
            return empty_OutputBuffer;
        }
        public Avril.ClientAssembly.Outputs.Output GetBuffer_FrontOutputDouble(Avril.ClientAssembly.Framework_Client obj)
        {
            return outputDoubleBuffer[BoolToInt16(obj.Get_Client().Get_Data().GetState_Buffer_OutputPraise_SideToWrite())];
        }
        public Avril.ClientAssembly.Outputs.Output GetBuffer_BackOutputDouble(Avril.ClientAssembly.Framework_Client obj)
        {
            return outputDoubleBuffer[BoolToInt16(!obj.Get_Client().Get_Data().GetState_Buffer_OutputPraise_SideToWrite())];
        }

        public Avril.ClientAssembly.Outputs.Output GetTransmitOutputBuffer()
        {
            return transmitOutputBuffer;
        }


        public void SetBuffer_Output(Avril.ClientAssembly.Framework_Client obj, Avril.ClientAssembly.Outputs.Output value)
        {
            outputDoubleBuffer[BoolToInt16(!obj.Get_Client().Get_Data().GetState_Buffer_OutputPraise_SideToWrite())] = value;
        }
    }
}
