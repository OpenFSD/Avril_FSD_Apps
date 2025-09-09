// The following ifdef block is the standard way of creating macros which make exporting
// from a DLL simpler. All files within this DLL are compiled with the LIBSERVERCONCURRENCY_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see
// LIBSERVERCONCURRENCY_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
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
		static void* Initialise_Server_Assembly();
		static bool Get_Flag_isNewInputDataReady(class Framework_Server* obj);
		static bool Get_flag_isNewOutputDataReady(class Framework_Server* obj);
		static bool Get_Flag_IsStackLoaded_Server_InputAction(class Framework_Server* obj);
		static bool Get_Flag_IsStackLoaded_Server_OutputRecieve(class Framework_Server* obj);
		static bool GetFlag_ServerConcurrency_Initialised(class Framework_Server* obj);
		static void Pop_Stack_Output(class Framework_Server* obj);
		static void Push_Stack_InputPraises(class Framework_Server* obj);
		//static void Set_Flag_isNewInputDataReady(bool value);
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
		static std::array<float, 3> Get_Praise1_Output_Player_Fowards(class Framework_Server* obj);
		static std::array<float, 3> Get_Praise1_Output_Player_Up(class Framework_Server* obj);
		static std::array<float, 3> Get_Praise1_Output_Player_Right(class Framework_Server* obj);
		static void Set_Praise1_Output_Player_Fowards(class Framework_Server* obj, std::array<float, 3> value);
		static void Set_Praise1_Output_Player_Up(class Framework_Server* obj, std::array<float, 3> value);
		static void Set_Praise1_Output_Player_Right(class Framework_Server* obj, std::array<float, 3> value);
		// Praise 0 Data
	};
}

extern LIBSERVERCONCURRENCY_API int nLIBServerConcurrency;

LIBSERVERCONCURRENCY_API int fnLIBServerConcurrency(void);
