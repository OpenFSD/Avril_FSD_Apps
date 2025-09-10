namespace Avril.ClientAssembly
{
    public class Data_Control
    {
        private bool _flag_IsLoaded_Stack_InputAction;
        private bool _flag_IsLoaded_Stack_OutputAction;
        private bool[] _isPraiseActive;

        public Data_Control()
        {
            Set_flag_IsLoaded_Stack_InputAction(false);
            Set_flag_IsLoaded_Stack_OutputAction(false);
            
        }
        public void Initialise(Avril.ClientAssembly.Framework_Client obj)
        {
            _isPraiseActive = new bool[obj.Get_client().Get_global().Get_numberOfPraises()];
            for (int index = 0; index < obj.Get_client().Get_global().Get_numberOfPraises(); index++)
            {
                Set_isPraiseActive(index, false);
            }
        }
        public void Push_Stack_InputActions(
            List<Avril.ClientAssembly.Inputs.Input> stack_InputAction,
            Avril.ClientAssembly.Inputs.Input buffer_Back_Input
        )
        {
            stack_InputAction.Add(buffer_Back_Input);
        }

        public void Push_Stack_OutputRecieve(
            List<Avril.ClientAssembly.Outputs.Output> stack_OutputRecieve,
            Avril.ClientAssembly.Outputs.Output buffer_TransmitOutput
        )
        {
            stack_OutputRecieve.Add(buffer_TransmitOutput);
        }

        public void Pop_Stack_InputActions(
            Avril.ClientAssembly.Inputs.Input buffer_Transmit_Input,
            List<Avril.ClientAssembly.Inputs.Input> stack_InputAction
        )
        {
            buffer_Transmit_Input = stack_InputAction.ElementAt(0);
            stack_InputAction.RemoveAt(0);
        }

        public void Pop_Stack_OutputRecieve(
            Avril.ClientAssembly.Outputs.Output buffer_Back_Output,
            List<Avril.ClientAssembly.Outputs.Output> stack_OutputRecieve
        )
        {
            buffer_Back_Output = stack_OutputRecieve.ElementAt(0);
            stack_OutputRecieve.RemoveAt(0);
        }

        public bool Get_flag_IsLoaded_Stack_InputAction()
        {
            return _flag_IsLoaded_Stack_InputAction;
        }

        public bool Get_flag_IsLoaded_Stack_OutputAction()
        {
            return _flag_IsLoaded_Stack_OutputAction;
        }

        public bool Get_isPraiseActive(int praiseEventId)
        {
            return _isPraiseActive[praiseEventId];
        }
        
        public void Set_flag_IsLoaded_Stack_InputAction(bool value)
        {
            _flag_IsLoaded_Stack_InputAction = value;
        }

        public void Set_flag_IsLoaded_Stack_OutputAction(bool value)
        {
            _flag_IsLoaded_Stack_OutputAction = value;
        }

        public void Set_isPraiseActive(int praiseEventId, bool value)
        {
            _isPraiseActive[praiseEventId] = value; 
        }

    }
}
