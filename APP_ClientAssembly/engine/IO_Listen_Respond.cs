
namespace Avril.ClientAssembly
{ 
    public class IO_Listen_Respond
    {
        static private byte listen_CoreId;
        static private byte respond_CoreId;
        static private Avril.ClientAssembly.IO_Listen_Respond_Control io_Control;

        public IO_Listen_Respond() 
        {
            listen_CoreId = 255;
            respond_CoreId = 255;
            io_Control = null;
        }
        public void InitialiseControl()
        {
            io_Control = new Avril.ClientAssembly.IO_Listen_Respond_Control();
            while (io_Control == null) { /* Wait while is created */ }
        }

        public void Thread_Input_Listen(Avril.ClientAssembly.Framework_Client obj)
        {
            listen_CoreId = 0;
            bool done_once = true;
            while (Framework_Client.Get__Client().Get_Execute().GetExecute_Control().GetFlag_ThreadInitialised(listen_CoreId) == true)
            {
                if (done_once == true)
                {
                    Framework_Client.Get__Client().Get_Execute().GetExecute_Control().SetFlag_ThreadInitialised(listen_CoreId, false);
                    done_once = false;
                }
            }
            System.Console.WriteLine("Thread Initalised => Thread_Input_Listen()");//TestBench
            while (Framework_Client.Get__Client().Get_Execute().GetExecute_Control().GetFlag_Client_App_Initialised() == true)
            {

            }
            System.Console.WriteLine("Thread Starting => Thread_Input_Listen()");//TestBench
            while (Framework_Client.Get__Client().Get_Execute().GetExecute_Control().GetFlag_Client_App_Initialised() == false)
            {
                //Networking.CopyPayloadFromMessage();//todo
            }
        }

        public void Thread_Output_Respond()
        {
            respond_CoreId = 1;
            bool done_once = true;
            while (Framework_Client.Get__Client().Get_Execute().GetExecute_Control().GetFlag_ThreadInitialised(respond_CoreId) == true)
            {
                if (done_once == true)
                {
                    Framework_Client.Get__Client().Get_Execute().GetExecute_Control().SetFlag_ThreadInitialised(respond_CoreId, false);
                    done_once = false;
                }
            }
            System.Console.WriteLine("Thread Initalised => Thread_Output_Respond()");//TestBench
            while (Framework_Client.Get__Client().Get_Execute().GetExecute_Control().GetFlag_Client_App_Initialised() == true)
            {

            }
            System.Console.WriteLine("Thread Starting => Thread_Output_Respond()");//TestBench
            while (Framework_Client.Get__Client().Get_Execute().GetExecute_Control().GetFlag_Client_App_Initialised() == false)
            {
                //Networking.CreateAndSendNewMessage();//todo
            }
        }
        public Avril.ClientAssembly.IO_Listen_Respond_Control GetIO_Control()
        {
            return io_Control;
        }
    }
}
