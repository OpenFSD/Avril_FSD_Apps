
namespace Avril.ClientAssembly
{ 
    public class IO_Listen_Respond
    {
        private Avril.ClientAssembly.IO_Listen_Respond_Control _io_Control;
        private byte _listen_CoreId;
        private byte _respond_CoreId;
        

        public IO_Listen_Respond() 
        {
            Set_io_Control(null);
            Set_listen_CoreId(255);
            Set_respond_CoreId(255);
        }
        public void InitialiseControl()
        {
            Set_io_Control(new Avril.ClientAssembly.IO_Listen_Respond_Control());
            while (Get_io_Control() == null) { }
        }

        public void Thread_Input_Listen()
        {
            Set_listen_CoreId(0);
            Avril.ClientAssembly.Framework_Client obj = Program.Get_framework_Client();
            bool done_once = true;
            while (obj.Get_client().Get_execute().Get_execute_Control().Get_flag_ThreadInitialised(Get_listen_CoreId()) == true)
            {
                if (done_once == true)
                {
                    obj.Get_client().Get_execute().Get_execute_Control().Set_flag_ThreadInitialised(Get_listen_CoreId(), false);
                    done_once = false;
                }
            }
            System.Console.WriteLine("Thread Initalised => Thread_Input_Listen()");//TestBench
            while (obj.Get_client().Get_execute().Get_execute_Control().Get_flag_isInitialised_ClientApp() == true)
            {

            }
            System.Console.WriteLine("Thread Starting => Thread_Input_Listen()");//TestBench
            while (obj.Get_client().Get_execute().Get_execute_Control().Get_flag_isInitialised_ClientApp() == false)
            {
                //Networking.CopyPayloadFromMessage();//todo
            }
        }

        public void Thread_Output_Respond()
        {
            Set_respond_CoreId(1);
            Avril.ClientAssembly.Framework_Client obj = Program.Get_framework_Client();
            bool done_once = true;
            while (obj.Get_client().Get_execute().Get_execute_Control().Get_flag_ThreadInitialised(Get_respond_CoreId()) == true)
            {
                if (done_once == true)
                {
                    obj.Get_client().Get_execute().Get_execute_Control().Set_flag_ThreadInitialised(Get_respond_CoreId(), false);
                    done_once = false;
                }
            }
            System.Console.WriteLine("Thread Initalised => Thread_Output_Respond()");//TestBench
            while (obj.Get_client().Get_execute().Get_execute_Control().Get_flag_isInitialised_ClientApp() == true)
            {

            }
            System.Console.WriteLine("Thread Starting => Thread_Output_Respond()");//TestBench
            while (obj.Get_client().Get_execute().Get_execute_Control().Get_flag_isInitialised_ClientApp() == false)
            {
                //Networking.CreateAndSendNewMessage();//todo
            }
        }
        public IO_Listen_Respond_Control Get_io_Control()
        {
            return _io_Control;
        }
        public byte Get_listen_CoreId()
        {
            return _listen_CoreId;
        }
        public byte Get_respond_CoreId()
        {
            return _respond_CoreId;
        }
        public void Set_io_Control(IO_Listen_Respond_Control io_control)
        {
            _io_Control = io_control;
        }
        public void Set_listen_CoreId(byte listen_coreId)
        {
            _listen_CoreId = listen_coreId;
        }
        public void Set_respond_CoreId(byte respond_coreId)
        {
            _respond_CoreId = respond_coreId;
        }
    }
}
