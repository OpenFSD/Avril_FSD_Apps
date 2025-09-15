
namespace Avril.ClientAssembly.Outputs
{
    public class Output_Instance
    {
        private Avril.ClientAssembly.Outputs.Output _empty_OutputBuffer;
        private Avril.ClientAssembly.Outputs.Output[] _outputDoubleBuffer;
        private Avril.ClientAssembly.Outputs.Output _transmitOutputBuffer;

        public Output_Instance() 
        {
            Set_empty_OutputBuffer(new Avril.ClientAssembly.Outputs.Output());
            while (Get_empty_OutputBuffer() == null) { }
            Get_empty_OutputBuffer().Initialise_Control();

            _outputDoubleBuffer = new Avril.ClientAssembly.Outputs.Output[2];
            for (byte index = 0; index < 2; index++)
            {
                _outputDoubleBuffer[index] = Get_empty_OutputBuffer();
                while (_outputDoubleBuffer[index] == null) { }
            }
            Set_transmitOutputBuffer(new Avril.ClientAssembly.Outputs.Output());
            while (Get_transmitOutputBuffer() == null) { }
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

        public Avril.ClientAssembly.Outputs.Output Get_empty_OutputBuffer()
        {
            return _empty_OutputBuffer;
        }
        public Avril.ClientAssembly.Outputs.Output Get_FRONT_outputDoubleBuffer(Avril.ClientAssembly.Framework_Client obj)
        {
            return _outputDoubleBuffer[BoolToInt16(obj.Get_client().Get_data().Get_state_Buffer_Output_ToWrite())];
        }
        public Avril.ClientAssembly.Outputs.Output Get_BACK_outputDoubleBuffer(Avril.ClientAssembly.Framework_Client obj)
        {
            return _outputDoubleBuffer[BoolToInt16(!obj.Get_client().Get_data().Get_state_Buffer_Output_ToWrite())];
        }
        public Avril.ClientAssembly.Outputs.Output Get_transmitOutputBuffer()
        {
            return _transmitOutputBuffer;
        }

        private void Set_empty_OutputBuffer(Avril.ClientAssembly.Outputs.Output value)
        {
            _empty_OutputBuffer = value;
        }
        public void Set_outputDoubleBuffer(Avril.ClientAssembly.Framework_Client obj, Avril.ClientAssembly.Outputs.Output value)
        {
            _outputDoubleBuffer[BoolToInt16(!obj.Get_client().Get_data().Get_state_Buffer_Output_ToWrite())] = value;
        }
        private void Set_transmitOutputBuffer(Avril.ClientAssembly.Outputs.Output value)
        {
            _transmitOutputBuffer = value;
        }
    }
}
