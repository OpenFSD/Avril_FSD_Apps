
using Avril.ClientAssembly.Praise_Files;

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
            //std::cout << "Thread Initialised: ID=" << (concurrent_coreId + 2) << " => Thread_Concurrency()" << std::endl;//TestBench
            while (obj.Get_client().Get_execute().Get_execute_Control().Get_flag_SystemInitialised() == true)
            {

            }
            //std::cout << "Thread Starting " << (concurrent_coreId + 2) << " => Thread_Concurrency()" << std::endl;//TestBench
            while (obj.Get_client().Get_execute().Get_execute_Control().Get_flag_SystemInitialised() == false)
            {
                if (Avril_FSD.Library_For_LaunchEnableForConcurrentThreadsAt_CLIENT.Get_Flag_ConcurrentCoreState(obj.Get_client().Get_execute().Get_program_ConcurrentQue_C(), concurrent_coreId) == Avril_FSD.Library_For_LaunchEnableForConcurrentThreadsAt_CLIENT.Get_Flag_Idle(obj.Get_client().Get_execute().Get_program_ConcurrentQue_C()))
                {
                    Avril_FSD.Library_For_LaunchEnableForConcurrentThreadsAt_CLIENT.Set_State_ConcurrentCoreState(obj.Get_client().Get_execute().Get_program_ConcurrentQue_C(), concurrent_coreId, Avril_FSD.Library_For_LaunchEnableForConcurrentThreadsAt_CLIENT.Get_Flag_Active(obj.Get_client().Get_execute().Get_program_ConcurrentQue_C()));
                }
                if (obj.Get_client().Get_data().Get_data_Control().Get_flag_IsLoaded_Stack_OutputAction() == true)
                {
                    Avril_FSD.Library_For_WriteEnableForThreadsAt_CLIENTOUTPUTRECIEVE.Write_Start(obj.Get_client().Get_execute().Get_program_WriteQue_C_OR(), (byte)(concurrent_coreId + 2));
                    obj.Get_client().Get_data().Get_data_Control().Pop_Stack_OutputRecieve(obj.Get_client().Get_data().Get_output_Instnace().Get_FRONT_outputDoubleBuffer(obj), obj.Get_client().Get_data().Get_stack_Client_OutputRecieves());
                    obj.Get_client().Get_algorithms().Get_concurrency(concurrent_coreId).Get_concurrency_Control().SelectSet_Algorithm_Subset(obj, obj.Get_client().Get_data().Get_InputRefferenceOfCore(concurrent_coreId).GetPraiseEventId(), concurrent_coreId);
                    obj.Get_client().Get_data().Get_OutputRefferenceOfCore(concurrent_coreId).Get_control_Of_Output().SelectSet_Output_Subset(obj, obj.Get_client().Get_data().Get_OutputRefferenceOfCore(concurrent_coreId).Get_out_praiseEventId(), concurrent_coreId);
                    Avril_FSD::Library_WriteEnableForThreadsAt_SERVERINPUTACTION::Write_End(obj.Get_client().Get_execute().Get_Program_WriteEnable_ServerInputAction(), concurrent_coreId + 1);
                    obj.Get_client().Get_Algorithms().Get_Concurrent(concurrent_coreId).Do_Concurrent_Algorithm_For_PraiseEventId(
                        obj,
                        obj.Get_client().Get_data().Get_InputRefferenceOfCore(concurrent_coreId).Get_playerId(),
                        obj.Get_client().Get_data().Get_InputRefferenceOfCore(concurrent_coreId).GetPraiseEventId(),
                        obj.Get_client().Get_Algorithms().Get_Concurrent(concurrent_coreId).Get_Algorithm_Subset(),
                        obj.Get_client().Get_data().Get_InputRefferenceOfCore(concurrent_coreId).Get_InputBuffer_Subset(),
                        obj.Get_client().Get_data().Get_OutputRefferenceOfCore(concurrent_coreId).Get_praiseOutputBuffer_Subset()
                    );
                    Avril_FSD::Library_WriteEnableForThreadsAt_SERVEROUTPUTRECIEVE::Write_Start(obj.Get_client().Get_execute().Get_Program_WriteEnable_ServerOutputRecieve(), concurrent_coreId + 1);
                    obj.Get_client().Get_data().Get_data_Control().Push_Stack_Output(obj, concurrent_coreId);
                    if (obj.Get_client().Get_data().Get_data_Control().Get_flag_IsStackLoaded_Server_OutputRecieve() == true)
                    {
                        if (Avril_FSD::CLIBLaunchEnableForConcurrentThreadsAtSERVER::Get_Flag_ConcurrentCoreState(obj.Get_client().Get_execute().Get_Program_ConcurrentQue_Server(), Avril_FSD::CLIBLaunchEnableForConcurrentThreadsAtSERVER::Get_coreId_To_Launch(0)) == Avril_FSD::CLIBLaunchEnableForConcurrentThreadsAtSERVER::Get_Flag_Idle(obj.Get_client().Get_execute().Get_Program_ConcurrentQue_Server()))
                        {
                            Avril_FSD::CLIBLaunchEnableForConcurrentThreadsAtSERVER::Request_Wait_Launch(obj.Get_client().Get_execute().Get_Program_ConcurrentQue_Server(), Avril_FSD::CLIBLaunchEnableForConcurrentThreadsAtSERVER::Get_coreId_To_Launch(0));
                        }
                    }
                    Avril_FSD::Library_WriteEnableForThreadsAt_SERVEROUTPUTRECIEVE::Write_End(obj.Get_client().Get_execute().Get_Program_WriteEnable_ServerOutputRecieve(), concurrent_coreId + 1);
                    Avril_FSD::CLIBLaunchEnableForConcurrentThreadsAtSERVER::Thread_End(obj.Get_client().Get_execute().Get_Program_ConcurrentQue_Server(), concurrent_coreId);
                }
            }
        }

        public void Do_Concurrent_Algorithm_For_PraiseEventId(
            Avril_FSD::Framework_Server* obj,
            char playerId,
            __int8 ptr_praiseEventId,
            Object* ptr_Algorithm_Subset,
            Object* ptr_Input_Subset,
            Object* ptr_Output_Subset
        )
        {
            Avril_FSD::Praise0_Algorithm* ptr_Algorithm_Subset_Praise0 = NULL;
            Avril_FSD::Praise0_Input* ptr_Input_Subset_Praise0 = NULL;
            Avril_FSD::Praise0_Output* ptr_Output_Subset_Praise0 = NULL;
            Avril_FSD::Praise1_Algorithm* ptr_Algorithm_Subset_Praise1 = NULL;
            Avril_FSD::Praise1_Input* ptr_Input_Subset_Praise1 = NULL;
            Avril_FSD::Praise1_Output* ptr_Output_Subset_Praise1 = NULL;
            Avril_FSD::Praise2_Algorithm* ptr_Algorithm_Subset_Praise2 = NULL;
            Avril_FSD::Praise2_Input* ptr_Input_Subset_Praise2 = NULL;
            Avril_FSD::Praise2_Output* ptr_Output_Subset_Praise2 = NULL;
            switch (ptr_praiseEventId)
            {
                case 0:
                    ptr_Algorithm_Subset_Praise0 = reinterpret_cast<Avril_FSD::Praise0_Algorithm*>(ptr_Algorithm_Subset);
                    ptr_Input_Subset_Praise0 = reinterpret_cast<Avril_FSD::Praise0_Input*>(ptr_Input_Subset);
                    ptr_Output_Subset_Praise0 = reinterpret_cast<Avril_FSD::Praise0_Output*>(ptr_Output_Subset);
                    ptr_Algorithm_Subset_Praise0.Do_Praise(
                        ptr_Input_Subset_Praise0,
                        ptr_Output_Subset_Praise0
                    );
                    break;

                case 1:
                    ptr_Algorithm_Subset_Praise1 = reinterpret_cast<Avril_FSD::Praise1_Algorithm*>(ptr_Algorithm_Subset);
                    ptr_Input_Subset_Praise1 = reinterpret_cast<Avril_FSD::Praise1_Input*>(ptr_Input_Subset);
                    ptr_Output_Subset_Praise1 = reinterpret_cast<Avril_FSD::Praise1_Output*>(ptr_Output_Subset);
                    ptr_Algorithm_Subset_Praise1.Do_Praise(obj, playerId, ptr_Input_Subset_Praise1, ptr_Output_Subset_Praise1);
                    break;

                case 2:
                    ptr_Algorithm_Subset_Praise2 = reinterpret_cast<Avril_FSD::Praise2_Algorithm*>(ptr_Algorithm_Subset);
                    ptr_Input_Subset_Praise2 = reinterpret_cast<Avril_FSD::Praise2_Input*>(ptr_Input_Subset);
                    ptr_Output_Subset_Praise2 = reinterpret_cast<Avril_FSD::Praise2_Output*>(ptr_Output_Subset);
                    ptr_Algorithm_Subset_Praise2.Do_Praise(
                        ptr_Input_Subset_Praise2,
                        ptr_Output_Subset_Praise2
                    );
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
        public void Set_algorithm_Subset(Praise0_Algorithm praise0_Algorithm)
        {
            _algorithm_Subset = (Object)praise0_Algorithm;
        }
        public void Set_algorithm_Subset(Praise1_Algorithm praise1_Algorithm)
        {
            _algorithm_Subset = (Object)praise1_Algorithm;
        }
        public void Set_algorithm_Subset(Praise2_Algorithm praise2_Algorithm)
        {
            _algorithm_Subset = (Object)praise2_Algorithm;
        }
    }
}
