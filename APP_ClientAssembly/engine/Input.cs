using System;

namespace Avril.ClientAssembly.Inputs
{
    public class Input
    {
        private Avril.ClientAssembly.Inputs.Input_Control _input_Control;
        private Object _praiseInputBuffer_Subset;
        private UInt16 _praiseEventId;

        public Input()
        {
            Set_input_Control(null);
            Set_praiseInputBuffer_Subset(null);
            Set_praiseEventId(0);
            System.Console.WriteLine("Avril.ClientAssembly: Input");
        }

        public void InitialiseControl() 
        {
            Set_input_Control(new Avril.ClientAssembly.Inputs.Input_Control());
            while (Get_input_Control() == null) { }
        }
        public Avril.ClientAssembly.Inputs.Input_Control Get_input_Control()
        {
            return _input_Control;
        }
        public Object Get_praiseInputBuffer_Subset()
        {
            return _praiseInputBuffer_Subset;
        }
        public int Get_praiseEventId()
        {
            return _praiseEventId;
        }
        public void Set_input_Control(Input_Control value)
        {
            _input_Control = value;
        }
        public void Set_praiseInputBuffer_Subset(Object value)
        {
            _praiseInputBuffer_Subset = value;
        }
        
        public void Set_praiseEventId(UInt16 value)
        {
            _praiseEventId = value;
        }
    }
}