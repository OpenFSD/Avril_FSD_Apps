
using System;

namespace Avril.ClientAssembly.Inputs
{
    public class Input_Instance
    {
        static private Avril.ClientAssembly.Inputs.Input_Instance_Control inputInstance_Control;
        static private Avril.ClientAssembly.Inputs.Input empty_InputBuffer;
        static private Avril.ClientAssembly.Inputs.Input[] inputDoubleBuffer;

        public Input_Instance() 
        {
            inputInstance_Control = new Avril.ClientAssembly.Inputs.Input_Instance_Control();
            while (inputInstance_Control == null) { /* Wait while is created */ }

            empty_InputBuffer = new Avril.ClientAssembly.Inputs.Input();
            while (empty_InputBuffer == null) { /* Wait while is created */ }
            empty_InputBuffer.InitialiseControl();

            inputDoubleBuffer = new Avril.ClientAssembly.Inputs.Input[2];
            for (byte index = 0; index < 2; index++)
            {
                inputDoubleBuffer[index] = empty_InputBuffer;
                while (inputDoubleBuffer[index] == null) { /* Wait while is created */ }
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

        public Avril.ClientAssembly.Inputs.Input GetBuffer_Front_InputDouble(Avril.ClientAssembly.Framework_Client obj)
        {
            return inputDoubleBuffer[BoolToInt16(obj.Get_Client().Get_Data().GetState_Buffer_InputPraise_SideToWrite())];
        }
        public Avril.ClientAssembly.Inputs.Input GetBuffer_Back_InputDouble(Avril.ClientAssembly.Framework_Client obj)
        {
            return inputDoubleBuffer[BoolToInt16(!obj.Get_Client().Get_Data().GetState_Buffer_InputPraise_SideToWrite())];
        }

        public Avril.ClientAssembly.Inputs.Input GetEmptyInput()
        {
            return empty_InputBuffer;
        }

        public Avril.ClientAssembly.Inputs.Input_Instance_Control GetInputInstance_Control()
        {
            return inputInstance_Control;
        }

        public void SetBuffer_Input(Avril.ClientAssembly.Framework_Client obj, Avril.ClientAssembly.Inputs.Input value)
        {
            inputDoubleBuffer[BoolToInt16(obj.Get_Client().Get_Data().GetState_Buffer_InputPraise_SideToWrite())] = value;
        }
    }
}
