
namespace Avril.ClientAssembly.Inputs
{
    public class Input_Instance
    {
        private Avril.ClientAssembly.Inputs.Input_Instance_Control _inputInstance_Control;
        private Avril.ClientAssembly.Inputs.Input _empty_InputBuffer;
        private Avril.ClientAssembly.Inputs.Input[] _inputDoubleBuffer;

        public Input_Instance() 
        {
            Set_inputInstance_Control(new Avril.ClientAssembly.Inputs.Input_Instance_Control());
            while (Get_inputInstance_Control() == null) { }

            Set_empty_InputBuffer(new Avril.ClientAssembly.Inputs.Input());
            while (Get_empty_InputBuffer() == null) { }
            Get_empty_InputBuffer().InitialiseControl();

            _inputDoubleBuffer = new Avril.ClientAssembly.Inputs.Input[2];
            for (byte index = 0; index < 2; index++)
            {
                _inputDoubleBuffer[index] = Get_empty_InputBuffer();
                while (_inputDoubleBuffer[index] == null) { }
            }
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

        public Avril.ClientAssembly.Inputs.Input Get_FRONT_inputDoubleBuffer(Avril.ClientAssembly.Framework_Client obj)
        {
            return _inputDoubleBuffer[BoolToInt16(obj.Get_client().Get_data().Get_state_Buffer_Input_ToWrite())];
        }
        public Avril.ClientAssembly.Inputs.Input Get_BACK_inputDoubleBuffer(Avril.ClientAssembly.Framework_Client obj)
        {
            return _inputDoubleBuffer[BoolToInt16(!obj.Get_client().Get_data().Get_state_Buffer_Input_ToWrite())];
        }

        public Avril.ClientAssembly.Inputs.Input Get_empty_InputBuffer()
        {
            return _empty_InputBuffer;
        }

        public Avril.ClientAssembly.Inputs.Input_Instance_Control Get_inputInstance_Control()
        {
            return _inputInstance_Control;
        }

        public void Set_inputDoubleBuffer(Avril.ClientAssembly.Framework_Client obj, Avril.ClientAssembly.Inputs.Input value)
        {
            _inputDoubleBuffer[BoolToInt16(obj.Get_client().Get_data().Get_state_Buffer_Input_ToWrite())] = value;
        }

        public void Set_empty_InputBuffer(Avril.ClientAssembly.Inputs.Input input)
        {
            _empty_InputBuffer = input;
        }

        public void Set_inputInstance_Control(Avril.ClientAssembly.Inputs.Input_Instance_Control input_Instance_Control)
        {
            _inputInstance_Control = input_Instance_Control;
        }
    }
}
