#pragma once
#include <vector>

namespace Avril_FSD
{
    class Data_Control
    {
    public:
        Data_Control();
        virtual ~Data_Control();
        void Pop_Stack_InputPraises(class Framework_Server* obj, __int8 concurrentCoreId);
        void Pop_Stack_Output(class Framework_Server* obj);
        void Push_Stack_InputPraises(class Framework_Server* obj);
        void Push_Stack_Output(class Framework_Server* obj, __int8 concurrentCoreId);
        
        bool Get_flag_IsStackLoaded_Server_InputAction();
        bool Get_flag_IsStackLoaded_Server_OutputRecieve();
        //bool GetFlag_isNewInputDataReady();
       // bool GetFlag_isNewOutputDataReady();

    protected:

    private:
        void Set_flag_IsStackLoaded_Server_InputAction(bool value);
        void Set_flag_IsStackLoaded_Server_OutputRecieve(bool value);
    };
}