// LIB_ServerConcurrency.cpp : Defines the exported functions for the DLL.
//

#include "pch.h"
#include "framework.h"
#include "LIB_ServerConcurrency.h"

std::array<float, 3> _fowards;
std::array<float, 3> _up;
std::array<float, 3> _right;

bool _flag_isNewInputDataReady;
bool _flag_isNewOutputDataReady;
bool _flag_IsStackLoaded_Server_InputAction;
bool _flag_IsStackLoaded_Server_OutputRecieve;
bool _flag_IsInitialised_Avril_FSD_ServerAssembly;

// Praise Event Id
__int8 _PraiseEventId;

// Praise 0 Data
bool _Praise0_Input_IsPingActive;
bool _Praise0_Output_IsPingActive;

// Praise 1 Data
float _Praise1_Input_mouseDelta_X;
float _Praise1_Input_mouseDelta_Y;
std::array<float, 3> _Praise1_Output_Player_Fowards;
std::array<float, 3> _Praise1_Output_Player_Up;
std::array<float, 3> _Praise1_Output_Player_Right;

// This is an example of an exported variable
LIBSERVERCONCURRENCY_API int nLIBServerConcurrency=0;

// This is an example of an exported function.
LIBSERVERCONCURRENCY_API int fnLIBServerConcurrency(void)
{
    return 0;
}

void Avril_FSD::CLIBServerConcurrency::Flip_InBufferToWrite(Avril_FSD::Framework_Server* obj)
{
    obj->Get_Server_Assembly()->Get_Data()->Flip_Input_DoubleBuffer();
}

void Avril_FSD::CLIBServerConcurrency::Flip_OutBufferToWrite(Avril_FSD::Framework_Server* obj)
{
    obj->Get_Server_Assembly()->Get_Data()->Flip_Output_DoubleBuffer();
}
void* Avril_FSD::CLIBServerConcurrency::Initialise_Server_Assembly()
{
    Avril_FSD::Framework_Server* programId_ServerConcurrencyLibrary = new class Avril_FSD::Framework_Server();
    while (programId_ServerConcurrencyLibrary == NULL) {}
    programId_ServerConcurrencyLibrary->Initialise_Program(programId_ServerConcurrencyLibrary);
    return (void*)programId_ServerConcurrencyLibrary;
}
void Avril_FSD::CLIBServerConcurrency::Pop_Stack_Output(Avril_FSD::Framework_Server* obj)
{
    obj->Get_Server_Assembly()->Get_Data()->Get_Data_Control()->Pop_Stack_Output(obj);
}
void Avril_FSD::CLIBServerConcurrency::Push_Stack_InputPraises(Avril_FSD::Framework_Server* obj)
{
    obj->Get_Server_Assembly()->Get_Data()->Get_Data_Control()->Push_Stack_InputPraises(obj);
}
void Avril_FSD::CLIBServerConcurrency::Select_Set_Intput_Subset(Avril_FSD::Framework_Server* obj, __int8 priaseEventId)
{
    obj->Get_Server_Assembly()->Get_Data()->GetBuffer_InputFrontDouble()->Get_Input_Control()->SelectSet_Input_Subset(/obj, priaseEventId);
}

bool Avril_FSD::CLIBServerConcurrency::Get_flag_isNewInputDataReady(Avril_FSD::Framework_Server* obj)
{
    _flag_isNewInputDataReady = obj->Get_Server_Assembly()->Get_Data()->Get_Data_Control()->GetFlag_isNewInputDataReady();
    return _flag_isNewInputDataReady;
}
bool Avril_FSD::CLIBServerConcurrency::Get_flag_isNewOutputDataReady(Avril_FSD::Framework_Server* obj)
{
    _flag_isNewOutputDataReady = obj->Get_Server_Assembly()->Get_Data()->Get_Data_Control()->GetFlag_isNewOutputDataReady();
    return _flag_isNewOutputDataReady;
}
bool Avril_FSD::CLIBServerConcurrency::Get_flag_IsStackLoaded_Server_InputAction(Avril_FSD::Framework_Server* obj)
{
    _flag_IsStackLoaded_Server_InputAction = obj->Get_Server_Assembly()->Get_Data()->Get_Data_Control()->GetFlag_InputStackLoaded();
    return _flag_IsStackLoaded_Server_InputAction;
}
bool Avril_FSD::CLIBServerConcurrency::Get_flag_IsStackLoaded_Server_OutputRecieve(Avril_FSD::Framework_Server* obj)
{
    _flag_IsStackLoaded_Server_OutputRecieve = obj->Get_Server_Assembly()->Get_Data()->Get_Data_Control()->GetFlag_OutputStackLoaded();
    return _flag_IsStackLoaded_Server_OutputRecieve;
}
void Avril_FSD::CLIBServerConcurrency::Set_Flag_isNewInputDataReady(bool value)
{
    _flag_isNewInputDataReady = value;
}
void Avril_FSD::CLIBServerConcurrency::Set_flag_isNewOutputDataReady(bool value)
{
    _flag_isNewOutputDataReady = value;
}
bool Avril_FSD::CLIBServerConcurrency::Get_flag_ServerConcurrency_Initialised(Avril_FSD::Framework_Server* obj)
{
    _flag_IsInitialised_Avril_FSD_ServerAssembly = obj->Get_Server_Assembly()->Get_Execute()->Get_Control_Of_Execute()->GetFlag_SystemInitialised(obj);
    return _flag_IsInitialised_Avril_FSD_ServerAssembly;
}

__int8 Avril_FSD::CLIBServerConcurrency::Get_PraiseEventId(Avril_FSD::Framework_Server* obj)
{
    _PraiseEventId = obj->Get_Server_Assembly()->Get_Data()->GetBuffer_OutputBackDouble()->GetPraiseEventId();
    return _PraiseEventId;
}
void Avril_FSD::CLIBServerConcurrency::Set_PraiseEventId(Avril_FSD::Framework_Server* obj, __int8 value)
{
    obj->Get_Server_Assembly()->Get_Data()->GetBuffer_InputBackDouble()->Set_in_praiseEventId(value);
}
//
bool Avril_FSD::CLIBServerConcurrency::Get_Praise0_Input_IsPingActive(Avril_FSD::Framework_Server* obj)
{
    _Praise0_Input_IsPingActive = obj->Get_Server_Assembly()->Get_Data()->Get_User_I()->Get_Praise0_Input()->Get_ping_Active();
    return _Praise0_Input_IsPingActive;
}
void Avril_FSD::CLIBServerConcurrency::Set_Praise0_Input_IsPingActive(Avril_FSD::Framework_Server* obj, bool value)
{
    obj->Get_Server_Assembly()->Get_Data()->Get_User_I()->Get_Praise0_Input()->Set_ping_Active(value);
}
bool Avril_FSD::CLIBServerConcurrency::Get_Praise0_Output_IsPingActive(Avril_FSD::Framework_Server* obj)
{
    _Praise0_Output_IsPingActive = obj->Get_Server_Assembly()->Get_Data()->Get_User_O()->Get_Praise0_Output()->Get_ping_Active();
    return _Praise0_Output_IsPingActive;
}
void Avril_FSD::CLIBServerConcurrency::Set_Praise0_Output_IsPingActive(Avril_FSD::Framework_Server* obj, bool value)
{
    obj->Get_Server_Assembly()->Get_Data()->Get_User_O()->Get_Praise0_Output()->Set_ping_Active(value);
}
//
float Avril_FSD::CLIBServerConcurrency::Get_Praise1_Input_mouseDelta_X(Avril_FSD::Framework_Server* obj)
{
    _Praise1_Input_mouseDelta_X = obj->Get_Server_Assembly()->Get_Data()->Get_User_I()->Get_Praise1_Input()->Get_mouse_delta_X();
    return _Praise1_Input_mouseDelta_X;
}
void Avril_FSD::CLIBServerConcurrency::Set_Praise1_Input_mouseDelta_X(Avril_FSD::Framework_Server* obj, float value)
{
    obj->Get_Server_Assembly()->Get_Data()->Get_User_I()->Get_Praise1_Input()->Set_mouse_delta_X(value);
}
float Avril_FSD::CLIBServerConcurrency::Get_Praise1_Input_mouseDelta_Y(Avril_FSD::Framework_Server* obj)
{
    _Praise1_Input_mouseDelta_Y = obj->Get_Server_Assembly()->Get_Data()->Get_User_I()->Get_Praise1_Input()->Get_mouse_delta_Y();
    return _Praise1_Input_mouseDelta_Y;
}
void Avril_FSD::CLIBServerConcurrency::Set_Praise1_Input_mouseDelta_Y(Avril_FSD::Framework_Server* obj, float value)
{
    obj->Get_Server_Assembly()->Get_Data()->Get_User_I()->Get_Praise1_Input()->Set_mouse_delta_Y(value);
}

std::array<float, 3> Avril_FSD::CLIBServerConcurrency::Get_Praise1_Output_Player_Fowards(Avril_FSD::Framework_Server* obj)
{
    _Praise1_Output_Player_Fowards = std::array<float, 3> {_fowards.at(0), _fowards.at(1), _fowards.at(2)};
    return _Praise1_Output_Player_Fowards;
}
std::array<float, 3> Avril_FSD::CLIBServerConcurrency::Get_Praise1_Output_Player_Up(Avril_FSD::Framework_Server* obj)
{
    _Praise1_Output_Player_Up = std::array<float, 3> {_up.at(0), _up.at(1), _up.at(2)};
    return _Praise1_Output_Player_Up;
}
std::array<float, 3> Avril_FSD::CLIBServerConcurrency::Get_Praise1_Output_Player_Right(Avril_FSD::Framework_Server* obj)
{
    _Praise1_Output_Player_Right = std::array<float, 3> {_right.at(0), _right.at(1), _right.at(2)};
    return _Praise1_Output_Player_Right;
}
void Avril_FSD::CLIBServerConcurrency::Set_Praise1_Output_Player_Fowards(Avril_FSD::Framework_Server* obj, std::array<float, 3> value)
{
    obj->Get_Server_Assembly()->Get_Data()->Get_User_O()->Get_Praise1_Output()->SetFowards(value);
}
void Avril_FSD::CLIBServerConcurrency::Set_Praise1_Output_Player_Up(Avril_FSD::Framework_Server* obj, std::array<float, 3> value)
{
    obj->Get_Server_Assembly()->Get_Data()->Get_User_O()->Get_Praise1_Output()->SetUp(value);
}
void Avril_FSD::CLIBServerConcurrency::Set_Praise1_Output_Player_Right(Avril_FSD::Framework_Server* obj, std::array<float, 3> value)
{
    obj->Get_Server_Assembly()->Get_Data()->Get_User_O()->Get_Praise1_Output()->SetUp(value);
}

// This is the constructor of a class that has been exported.
Avril_FSD::CLIBServerConcurrency::CLIBServerConcurrency()
{
    return;
}


