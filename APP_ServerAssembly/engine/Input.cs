
namespace Avril.ServerAssembly.Inputs
{
    public class Input
    {
        static private Avril.ServerAssembly.Inputs.Input_Control input_Control;
        static private Object praiseInputBuffer_Subset;

        private UInt16 praiseEventId;
        

        public Input()
        {
            input_Control = null;

            praiseEventId = new int();
            praiseEventId = 0;

            praiseInputBuffer_Subset = null;
            System.Console.WriteLine("Avril.ServerAssembly: Input");
        }

        public void InitialiseControl() 
        {
            input_Control = new Avril.ServerAssembly.Inputs.Input_Control();
            while (input_Control == null) { /* Wait while is created */ }
        }

        public Object Get_InputBufferSubset()
        {
            return praiseInputBuffer_Subset;
        }

        public Avril.ServerAssembly.Inputs.Input_Control GetInputControl()
        {
            return input_Control;
        }

        public int GetPraiseEventId() 
        {   
            return praiseEventId; 
        }

        public void Set_InputBuffer_SubSet(Object value)
        {
            praiseInputBuffer_Subset = value;
        }

        public void SetPraiseEventId(UInt16 value)
        {
            praiseEventId = value;
        }
    }
}