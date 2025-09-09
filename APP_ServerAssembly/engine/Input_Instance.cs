
namespace Avril.ServerAssembly.Inputs
{
    public class Input_Instance
    {
        static private Avril.ServerAssembly.Inputs.Input_Instance_Control inputInstance_Control;
        static private Avril.ServerAssembly.Inputs.Input empty_InputBuffer;
        static private Avril.ServerAssembly.Inputs.Input[] inputDoubleBuffer;
        static private Avril.ServerAssembly.Inputs.Input transmitInputBuffer;

        public Input_Instance()
        {
            inputInstance_Control = new Avril.ServerAssembly.Inputs.Input_Instance_Control();
            while (inputInstance_Control == null) { /* Wait while is created */ }

            empty_InputBuffer = new Avril.ServerAssembly.Inputs.Input();
            while (empty_InputBuffer == null) { /* Wait while is created */ }
            empty_InputBuffer.InitialiseControl();

            inputDoubleBuffer = new Avril.ServerAssembly.Inputs.Input[2];
            for (byte index = 0; index < 2; index++)
            {
                inputDoubleBuffer[index] = empty_InputBuffer;
                while (inputDoubleBuffer[index] == null) { /* Wait while is created */ }
            }

            transmitInputBuffer = new Avril.ServerAssembly.Inputs.Input();
            while (transmitInputBuffer == null) { /* Wait while is created */ }
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

        public Avril.ServerAssembly.Inputs.Input GetBuffer_Front_InputDouble()
        {
            return inputDoubleBuffer[BoolToInt16(Avril.ServerAssembly.Framework.GetGameServer().GetData().GetState_Buffer_InputPraise_SideToWrite())];
        }
        public Avril.ServerAssembly.Inputs.Input GetBuffer_Back_InputDouble()
        {
            return inputDoubleBuffer[BoolToInt16(!Avril.ServerAssembly.Framework.GetGameServer().GetData().GetState_Buffer_InputPraise_SideToWrite())];
        }

        public Avril.ServerAssembly.Inputs.Input GetEmptyInput()
        {
            return empty_InputBuffer;
        }

        public Avril.ServerAssembly.Inputs.Input_Instance_Control GetInputInstance_Control()
        {
            return inputInstance_Control;
        }

        public Avril.ServerAssembly.Inputs.Input Get_Transmit_InputBuffer()
        {
            return transmitInputBuffer;
        }

        public void SetBuffer_Input(Avril.ServerAssembly.Inputs.Input value)
        {
            inputDoubleBuffer[BoolToInt16(Avril.ServerAssembly.Framework.GetGameServer().GetData().GetState_Buffer_InputPraise_SideToWrite())] = value;
        }
    }
}
