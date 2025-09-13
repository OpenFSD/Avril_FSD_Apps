#include <array>
#ifdef LIBSERVERCONCURRENCY_EXPORTS
#define LIBSERVERCONCURRENCY_API __declspec(dllexport)
#else
#define LIBSERVERCONCURRENCY_API __declspec(dllimport)
#endif

namespace Avril_FSD
{
	// This class is exported from the dll
	class LIBSERVERCONCURRENCY_API CLIBServerConcurrency {
	public:
		CLIBServerConcurrency(void);
		// TODO: add your methods here.
		static void Flip_InBufferToWrite(Avril_FSD::Framework_Server* obj);
		static void Flip_OutBufferToWrite(Avril_FSD::Framework_Server* obj);
		static void* Initialise_Server_Assembly();
		static void Pop_Stack_Output(class Framework_Server* obj);
		static void Push_Stack_InputPraises(class Framework_Server* obj);
		static void Select_Set_Intput_Subset(class Framework_Server* obj, __int8 priaseEventId);

		static bool Get_flag_IsStackLoaded_Server_InputAction(class Framework_Server* obj);
		static bool Get_flag_IsStackLoaded_Server_OutputRecieve(class Framework_Server* obj);
		static bool Get_flag_ServerConcurrency_Initialised(class Framework_Server* obj);

		static Avril_FSD::LaunchEnableForConcurrentThreadsAt_SERVER_Framework* Get_program_ConcurrentQue_Server(Avril_FSD::Framework_Server* obj);
		static Avril_FSD::WriteEnableForThreadsAt_SERVERINPUTACTION_Framework* Get_program_WriteEnableStack_ServerInputAction(Avril_FSD::Framework_Server* obj);
		static Avril_FSD::WriteEnableForThreadsAt_SERVEROUTPUTRECIEVE_Framework* Get_program_WriteEnableStack_ServerOutputRecieve(Avril_FSD::Framework_Server* obj);

	// Praise Event Id
		static __int8 Get_PraiseEventId(class Framework_Server* obj);
		static void Set_PraiseEventId(class Framework_Server* obj, __int8 value);
		// Praise 0 Data
		static bool Get_Praise0_Input_IsPingActive(class Framework_Server* obj);
		static void Set_Praise0_Input_IsPingActive(class Framework_Server* obj, bool value);
		static bool Get_Praise0_Output_IsPingActive(class Framework_Server* obj);
		static void Set_Praise0_Output_IsPingActive(class Framework_Server* obj, bool value);
		// Praise 1 Data
		static float Get_Praise1_Input_mouseDelta_X(class Framework_Server* obj);
		static float Get_Praise1_Input_mouseDelta_Y(class Framework_Server* obj);
		static void Set_Praise1_Input_mouseDelta_X(class Framework_Server* obj, float value);
		static void Set_Praise1_Input_mouseDelta_Y(class Framework_Server* obj, float value);
		static Eigen::Vector3d Get_Praise1_Output_Player_Fowards(class Framework_Server* obj);
		static Eigen::Vector3d Get_Praise1_Output_Player_Up(class Framework_Server* obj);
		static Eigen::Vector3d Get_Praise1_Output_Player_Right(class Framework_Server* obj);
		static void Set_Praise1_Output_Player_Fowards(class Framework_Server* obj, Eigen::Vector3d value);
		static void Set_Praise1_Output_Player_Up(class Framework_Server* obj, Eigen::Vector3d value);
		static void Set_Praise1_Output_Player_Right(class Framework_Server* obj, Eigen::Vector3d value);
		// Praise 0 Data
	};
}

extern LIBSERVERCONCURRENCY_API int nLIBServerConcurrency;

LIBSERVERCONCURRENCY_API int fnLIBServerConcurrency(void);
