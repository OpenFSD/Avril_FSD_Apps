
namespace Avril.ServerAssembly.Outputs
{
    public class Output_Instance
    {
        private Avril.ServerAssembly.Outputs.Output _empty_OutputBuffer;
        private Avril.ServerAssembly.Outputs.Output[] _outputDoubleBuffer;
        private Avril.ServerAssembly.Outputs.Output _transmitOutputBuffer;

        public Output_Instance() 
        {
            Set_empty_OutputBuffer(new Avril.ServerAssembly.Outputs.Output());
            while (Get_empty_OutputBuffer() == null) { }
            Get_empty_OutputBuffer().InitialiseControl();

            _outputDoubleBuffer = new Avril.ServerAssembly.Outputs.Output[2];
            for (byte index = 0; index < 2; index++)
            {
                _outputDoubleBuffer[index] = Get_empty_OutputBuffer();
                while (_outputDoubleBuffer[index] == null) { }
            }
            Set_transmitOutputBuffer(new Avril.ServerAssembly.Outputs.Output());
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

        public Avril.ServerAssembly.Outputs.Output Get_empty_OutputBuffer()
        {
            return _empty_OutputBuffer;
        }
        public Avril.ServerAssembly.Outputs.Output Get_FRONT_outputDoubleBuffer(Avril.ServerAssembly.Framework_Server obj)
        {
            return _outputDoubleBuffer[BoolToInt16(obj.Get_server().Get_data().Get_state_Buffer_Output_ToWrite())];
        }
        public Avril.ServerAssembly.Outputs.Output Get_BACK_outputDoubleBuffer(Avril.ServerAssembly.Framework_Server obj)
        {
            return _outputDoubleBuffer[BoolToInt16(!obj.Get_server().Get_data().Get_state_Buffer_Output_ToWrite())];
        }
        public Avril.ServerAssembly.Outputs.Output Get_transmitOutputBuffer()
        {
            return _transmitOutputBuffer;
        }

        private void Set_empty_OutputBuffer(Avril.ServerAssembly.Outputs.Output value)
        {
            _empty_OutputBuffer = value;
        }
        public void Set_outputDoubleBuffer(Avril.ServerAssembly.Framework_Server obj, Avril.ServerAssembly.Outputs.Output value)
        {
            _outputDoubleBuffer[BoolToInt16(!obj.Get_server().Get_data().Get_state_Buffer_Output_ToWrite())] = value;
        }
        private void Set_transmitOutputBuffer(Avril.ServerAssembly.Outputs.Output value)
        {
            _transmitOutputBuffer = value;
        }
    }
}
