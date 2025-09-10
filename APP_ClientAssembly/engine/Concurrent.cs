
namespace Avril.ClientAssembly
{
    public class Concurrent
    {
        private Avril.ClientAssembly.Concurrent_Control _concurrent_Control;
        static private byte _concurrentCoreId;
        
        public Concurrent() 
        {
            Set_concurrent_Control(null);
            Set_concurrentCoreId(255);
        } 

        public void InitialiseControl()
        {
            Set_concurrent_Control(new Avril.ClientAssembly.Concurrent_Control());
            while (Get_concurrent_Control() == null) { }
        }

        public void Thread_Concurrent()
        {
            Avril.ClientAssembly.Framework_Client obj = Program.Get_framework_Client();
            bool done_once = true;
            while (obj.Get_client().Get_execute().Get_execute_Control().Get_flag_ThreadInitialised(Get_concurrentCoreId()) == true)
            {
                if (done_once == true)
                {
                    obj.Get_client().Get_execute().Get_execute_Control().Set_flag_ThreadInitialised(Get_concurrentCoreId(), false);
                    done_once = false;
                }
            }
            System.Console.WriteLine("Thread Initalised => Thread_Concurrent()");//TestBench
            while (obj.Get_client().Get_execute().Get_execute_Control().Get_flag_isInitialised_ClientApp() == true)
            {

            }
            System.Console.WriteLine("Thread Starting => Thread_Concurrent()");//TestBench
            while (obj.Get_client().Get_execute().Get_execute_Control().Get_flag_isInitialised_ClientApp() == false)
            {
                //todo
            }
        }
        public Avril.ClientAssembly.Concurrent_Control Get_concurrent_Control()
        {
            return _concurrent_Control;
        }
        private void Set_concurrent_Control(Avril.ClientAssembly.Concurrent_Control concurrent_Control)
        {
            _concurrent_Control = concurrent_Control;
        }
        static private byte Get_concurrentCoreId()
        {
            return (byte)(2 + _concurrentCoreId);
        }

        public void Set_concurrentCoreId(byte value)
        { 
            _concurrentCoreId = value; 
        }
    }
}
