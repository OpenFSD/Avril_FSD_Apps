
namespace Avril.ClientAssembly
{
    public class Concurrency
    {
        private Avril.ClientAssembly.Concurrency_Control _concurrencyControl;
        private Object _algorithm_Subset;

        public Concurrency() 
        {

        }

        public void Initialise_Control()
        {
            Set_Concurrent_Control(new Avril.ClientAssembly.Concurrency_Control());
            while (Get_concurrency_Control() == null) { }
        }


        public void Thread_Concurrency(Avril.ClientAssembly.Framework_Client obj, byte concurrent_coreId)
        {
            bool doneOnce = true;
            while (obj.Get_client().Get_execute().Get_execute_Control().Get_flag_ThreadInitialised(concurrent_coreId) == true)
            {
                if (doneOnce == true)
                {
                    obj.Get_client().Get_execute().Get_execute_Control().SetConditionCodeOfThisThreadedCore((byte)(concurrent_coreId + 2));
                    doneOnce = false;
                }

            }
            //std.cout << "Thread Initialised: ID=" << (concurrent_coreId + 2) << " => Thread_Concurrency()" << std.endl;//TestBench
            while (obj.Get_client().Get_execute().Get_execute_Control().Get_flag_SystemInitialised() == true)
            {

            }
            //std.cout << "Thread Starting " << (concurrent_coreId + 2) << " => Thread_Concurrency()" << std.endl;//TestBench
            while (obj.Get_client().Get_execute().Get_execute_Control().Get_flag_SystemInitialised() == false)
            {
                if (Avril_FSD.Library_For_LaunchEnableForConcurrentThreadsAt_CLIENT.Get_Flag_ConcurrentCoreState(obj.Get_client().Get_execute().Get_program_ConcurrentQue_C(), concurrent_coreId) == Avril_FSD.Library_For_LaunchEnableForConcurrentThreadsAt_CLIENT.Get_Flag_Idle(obj.Get_client().Get_execute().Get_program_ConcurrentQue_C()))
                {
                    Avril_FSD.Library_For_LaunchEnableForConcurrentThreadsAt_CLIENT.Set_State_ConcurrentCoreState(obj.Get_client().Get_execute().Get_program_ConcurrentQue_C(), concurrent_coreId, Avril_FSD.Library_For_LaunchEnableForConcurrentThreadsAt_CLIENT.Get_Flag_Active(obj.Get_client().Get_execute().Get_program_ConcurrentQue_C()));
                }
                if (obj.Get_client().Get_data().Get_data_Control().Get_flag_IsLoaded_Stack_OutputAction() == true)
                {
                    Avril_FSD.Library_For_WriteEnableForThreadsAt_CLIENTOUTPUTRECIEVE.Write_Start(obj.Get_client().Get_execute().Get_program_WriteQue_C_OR(), (byte)(concurrent_coreId + 2));
                    obj.Get_client().Get_data().Get_data_Control().Pop_Stack_OutputAction(obj.Get_client().Get_data().Get_buffer_Output_Reference_ForCore(concurrent_coreId), obj.Get_client().Get_data().Get_stack_Client_OutputRecieves());
                    obj.Get_client().Get_algorithms().Get_concurrency(concurrent_coreId).Get_concurrency_Control().SelectSet_Algorithm_Subset(obj, concurrent_coreId, obj.Get_client().Get_data().Get_buffer_Output_Reference_ForCore(concurrent_coreId).Get_praiseEventId());
                    obj.Get_client().Get_data().Get_buffer_Output_Reference_ForCore(concurrent_coreId).Get_output_Control().Select_Set_Output_Subset(obj, concurrent_coreId, obj.Get_client().Get_data().Get_buffer_Output_Reference_ForCore(concurrent_coreId).Get_praiseEventId());
                    obj.Get_client().Get_algorithms().Get_concurrency(concurrent_coreId).Do_Concurrent_Algorithm_For_PraiseEventId(
                        obj,
                        obj.Get_client().Get_data().Get_buffer_Output_Reference_ForCore(concurrent_coreId).Get_playerId(),
                        obj.Get_client().Get_data().Get_buffer_Output_Reference_ForCore(concurrent_coreId).Get_praiseEventId(),
                        obj.Get_client().Get_algorithms().Get_concurrency(concurrent_coreId).Get_algorithm_Subset(),
                        obj.Get_client().Get_data().Get_buffer_Output_Reference_ForCore(concurrent_coreId).Get_praiseOutputBuffer_Subset(),
                        obj.Get_client().Get_data().Get_gameInstance()                    //TODO write game data to game instance.
                    );
                    if (obj.Get_client().Get_data().Get_data_Control().Get_flag_IsLoaded_Stack_OutputAction() == true)
                    {
                        if (Avril_FSD.Library_For_LaunchEnableForConcurrentThreadsAt_CLIENT.Get_Flag_ConcurrentCoreState(obj.Get_client().Get_execute().Get_program_ConcurrentQue_C(), Avril_FSD.Library_For_LaunchEnableForConcurrentThreadsAt_CLIENT.Get_coreId_To_Launch(0)) == Avril_FSD.Library_For_LaunchEnableForConcurrentThreadsAt_CLIENT.Get_Flag_Idle(obj.Get_client().Get_execute().Get_program_ConcurrentQue_C()))
                        {
                            Avril_FSD.Library_For_LaunchEnableForConcurrentThreadsAt_CLIENT.Request_Wait_Launch(obj.Get_client().Get_execute().Get_program_ConcurrentQue_C(), Avril_FSD.Library_For_LaunchEnableForConcurrentThreadsAt_CLIENT.Get_coreId_To_Launch(0));
                        }
                    }
                    Avril_FSD.Library_For_WriteEnableForThreadsAt_CLIENTOUTPUTRECIEVE.Write_End(obj.Get_client().Get_execute().Get_program_WriteQue_C_OR(), (byte)(concurrent_coreId + 2));
                    Avril_FSD.Library_For_LaunchEnableForConcurrentThreadsAt_CLIENT.Thread_End(obj.Get_client().Get_execute().Get_program_ConcurrentQue_C(), concurrent_coreId);
                }
            }
        }

        private void Do_Concurrent_Algorithm_For_PraiseEventId(Avril.ClientAssembly.Framework_Client obj, byte playerId, byte praiseEventId, Object algorithm_Subset, Object input_Subset, Game_Instance gameInstance)
        {
            Avril.ClientAssembly.Praise_Files.Praise0_Algorithm algorithm_Subset_Praise0 = null;
            Avril.ClientAssembly.Praise_Files.Praise0_Input input_Subset_Praise0 = null;
            Avril.ClientAssembly.Praise_Files.Praise0_Output output_Subset_Praise0 = null;
            Avril.ClientAssembly.Praise_Files.Praise1_Algorithm algorithm_Subset_Praise1 = null;
            Avril.ClientAssembly.Praise_Files.Praise1_Input input_Subset_Praise1 = null;
            Avril.ClientAssembly.Praise_Files.Praise1_Output output_Subset_Praise1 = null;
            Avril.ClientAssembly.Praise_Files.Praise2_Algorithm algorithm_Subset_Praise2 = null;
            Avril.ClientAssembly.Praise_Files.Praise2_Input input_Subset_Praise2 = null;
            Avril.ClientAssembly.Praise_Files.Praise2_Output output_Subset_Praise2 = null;

            switch (praiseEventId)
            {
// USER IMPLEMENTAION - ABCDE
                case (byte)0:
                    algorithm_Subset_Praise0 = (Avril.ClientAssembly.Praise_Files.Praise0_Algorithm)(algorithm_Subset);
                    output_Subset_Praise0 = (Avril.ClientAssembly.Praise_Files.Praise0_Output)(input_Subset);
                    algorithm_Subset_Praise0.Do_Praise(gameInstance, playerId, output_Subset_Praise0);
                    break;

                case (byte)1:
                    algorithm_Subset_Praise1 = (Avril.ClientAssembly.Praise_Files.Praise1_Algorithm)(algorithm_Subset);
                    output_Subset_Praise1 = (Avril.ClientAssembly.Praise_Files.Praise1_Output)(input_Subset);
                    
                    algorithm_Subset_Praise1.Do_Praise(gameInstance, playerId, output_Subset_Praise1);
                    break;

                case (byte)2:

                    break;
            }
        }

        public Avril.ClientAssembly.Concurrency_Control Get_concurrency_Control()
        {
            return _concurrencyControl;
        }
        public Object Get_algorithm_Subset()
        {
            return _algorithm_Subset;
        }

        public void Set_Concurrent_Control(Concurrency_Control concurrent_Control)
        {
            _concurrencyControl = concurrent_Control;
        }

        // USER IMPLEMENTATION - ABCDE
        public void Set_algorithm_Subset(Avril.ClientAssembly.Praise_Files.Praise0_Algorithm praise0_Algorithm)
        {
            _algorithm_Subset = (Object)praise0_Algorithm;
        }
        public void Set_algorithm_Subset(Avril.ClientAssembly.Praise_Files.Praise1_Algorithm praise1_Algorithm)
        {
            _algorithm_Subset = (Object)praise1_Algorithm;
        }
        public void Set_algorithm_Subset(Avril.ClientAssembly.Praise_Files.Praise2_Algorithm praise2_Algorithm)
        {
            _algorithm_Subset = (Object)praise2_Algorithm;
        }
    }
}
