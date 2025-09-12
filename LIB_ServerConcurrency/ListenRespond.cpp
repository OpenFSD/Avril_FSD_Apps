#include "pch.h"
#include "ListenRespond.h"
#include <iostream>
#include "include/LIB_LaunchEnableForConcurrentThreadsAt_SERVER/LaunchEnableForConcurrentThreadsAt_SERVER_Framework.h"
#include "include/LIB_WriteEnableForThreadsAt_SERVERINPUTACTION/WriteEnableForThreadsAt_SERVERINPUTACTION_Framework.h".
#include "include/LIB_WriteEnableForThreadsAt_SERVEROUTPUTRECIEVE/WriteEnableForThreadsAt_SERVEROUTPUTRECIEVE_Framework.h"
__int8 _thisThreadCoreId;

Avril_FSD::ListenRespond::ListenRespond()
{
	_thisThreadCoreId = 0;
}

Avril_FSD::ListenRespond::~ListenRespond()
{
}
void Avril_FSD::ListenRespond::IO_ListenRespond(Avril_FSD::Framework_Server* obj)
{
    bool doneOnce = true;
    while (obj->Get_Server_Assembly()->Get_Execute()->Get_Control_Of_Execute()->GetFlag_ThreadInitialised(Get_thisThreadCoreId()) == true)
    {
        if (doneOnce == true)
        {
            obj->Get_Server_Assembly()->Get_Execute()->Get_Control_Of_Execute()->SetConditionCodeOfThisThreadedCore(Get_thisThreadCoreId());
            doneOnce = false;
        }
    }
    std::cout << "Thread Initialised => IO_ListenRespond()" << std::endl;//TestBench
    while (obj->Get_Server_Assembly()->Get_Execute()->Get_Control_Of_Execute()->GetFlag_SystemInitialised(obj) == true)
    {

    }
    std::cout << "Thread Starting => IO_ListenRespond()" << std::endl;//TestBench
    while (obj->Get_Server_Assembly()->Get_Execute()->Get_Control_Of_Execute()->GetFlag_SystemInitialised(obj) == false)
    {
        ThreadForListen(obj);
        ThreadForRespond(obj);
    }
}
void Avril_FSD::ListenRespond::ThreadForListen(Avril_FSD::Framework_Server* obj)
{
    if (obj->Get_Server_Assembly()->Get_Data()->Get_Data_Control()->GetFlag_InputStackLoaded())
    {
        Avril_FSD::Library_WriteEnableForThreadsAt_SERVERINPUTACTION::Write_Start(obj->Get_Server_Assembly()->Get_Execute()->Get_Program_WriteEnable_ServerInputAction(), Get_thisThreadCoreId());
        if (Avril_FSD::CLIBLaunchEnableForConcurrentThreadsAtSERVER::Get_Flag_ConcurrentCoreState(obj->Get_Server_Assembly()->Get_Execute()->Get_Program_ConcurrentQue_Server(), Avril_FSD::CLIBLaunchEnableForConcurrentThreadsAtSERVER::Get_coreId_To_Launch(0)) == false);
        {
            Avril_FSD::CLIBLaunchEnableForConcurrentThreadsAtSERVER::Request_Wait_Launch(obj->Get_Server_Assembly()->Get_Execute()->Get_Program_ConcurrentQue_Server(), Get_thisThreadCoreId());
        }
        Avril_FSD::Library_WriteEnableForThreadsAt_SERVERINPUTACTION::Write_End(obj->Get_Server_Assembly()->Get_Execute()->Get_Program_WriteEnable_ServerInputAction(), Get_thisThreadCoreId());
    }
}
void Avril_FSD::ListenRespond::ThreadForRespond(Avril_FSD::Framework_Server* obj)
{
    if (obj->Get_Server_Assembly()->Get_Data()->Get_Data_Control()->GetFlag_OutputStackLoaded())
    {
        Avril_FSD::Library_WriteEnableForThreadsAt_SERVEROUTPUTRECIEVE::Write_Start(obj->Get_Server_Assembly()->Get_Execute()->Get_Program_WriteEnable_ServerOutputRecieve(), Get_thisThreadCoreId());
        obj->Get_Server_Assembly()->Get_Data()->Get_Data_Control()->Pop_Stack_Output(obj);
        obj->Get_Server_Assembly()->Get_Data()->Flip_Output_DoubleBuffer();
        obj->Get_Server_Assembly()->Get_Data()->Get_Data_Control()->SetFlag_isNewOutputDataReady(true);
        Avril_FSD::Library_WriteEnableForThreadsAt_SERVEROUTPUTRECIEVE::Write_End(obj->Get_Server_Assembly()->Get_Execute()->Get_Program_WriteEnable_ServerOutputRecieve(), Get_thisThreadCoreId());
    }
}
__int8 Avril_FSD::ListenRespond::Get_thisThreadCoreId()
{
    return _thisThreadCoreId;
}
void Avril_FSD::ListenRespond::Set_listen_CoreId(__int8 thisThreadCoreId)
{
	_thisThreadCoreId = thisThreadCoreId;
}