using System;

namespace Avril.ServerAssembly.Inputs
{
    public class Input
    {
        private Avril.ServerAssembly.Inputs.Input_Control _input_Control;
        private Object _praiseInputBuffer_Subset;
        private byte _in_praiseEventId;
        private byte _in_playerId;

        public Input()
        {
            Set_input_Control(null);
            Set_praiseInputBuffer_Subset(null);
            Set_praiseEventId(0);
            System.Console.WriteLine("Avril.ServerAssembly: Input");
        }

        public void InitialiseControl() 
        {
            Set_input_Control(new Avril.ServerAssembly.Inputs.Input_Control());
            while (Get_input_Control() == null) { }
        }
        public Avril.ServerAssembly.Inputs.Input_Control Get_input_Control()
        {
            return _input_Control;
        }
        public Object Get_praiseInputBuffer_Subset()
        {
            return _praiseInputBuffer_Subset;
        }
        public ushort Get_praiseEventId()
        {
            return _in_praiseEventId;
        }
        public void Set_input_Control(Input_Control value)
        {
            _input_Control = value;
        }
        public void Set_praiseInputBuffer_Subset(Object value)
        {
            _praiseInputBuffer_Subset = value;
        }
        
        public void Set_praiseEventId(byte value)
        {
            _in_praiseEventId = value;
        }
    }
}