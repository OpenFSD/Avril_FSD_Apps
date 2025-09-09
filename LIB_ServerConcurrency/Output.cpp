#include "pch.h"
#include <cstddef>

Avril_FSD::Output_Control* ptr_control_Of_Output = NULL;
__int8 out_PraiseEventId = 255;
Avril_FSD::Object* ptr_praiseOutputBuffer_Subset = NULL;

Avril_FSD::Output::Output()
{
    SetPraiseEventId(__int8(255));
}

Avril_FSD::Output::~Output()
{
    delete ptr_control_Of_Output;
    delete ptr_praiseOutputBuffer_Subset;
}

void Avril_FSD::Output::Initialise_Control()
{
    Set_control_Of_Output(new class Avril_FSD::Output_Control());
    while (Get_Control_Of_Output() == nullptr) { /* wait untill created */ }
}

Avril_FSD::Output_Control* Avril_FSD::Output::Get_Control_Of_Output()
{
    return ptr_control_Of_Output;
}

Avril_FSD::Object* Avril_FSD::Output::Get_OutputBuffer_Subset()
{
    return ptr_praiseOutputBuffer_Subset;
}

__int8 Avril_FSD::Output::GetPraiseEventId()
{
    return out_PraiseEventId;
}

void Avril_FSD::Output::SetPraiseEventId(__int8 value)
{
    out_PraiseEventId = value;
}

void Avril_FSD::Output::Set_OutputBuffer_Subset(Avril_FSD::Praise0_Output* praise0_value)
{
    ptr_praiseOutputBuffer_Subset = reinterpret_cast<Avril_FSD::Object*>(praise0_value);
}
void Avril_FSD::Output::Set_OutputBuffer_Subset(Avril_FSD::Praise1_Output* praise0_value)
{
    ptr_praiseOutputBuffer_Subset = reinterpret_cast<Avril_FSD::Object*>(praise0_value);
}
void Avril_FSD::Output::Set_OutputBuffer_Subset(Avril_FSD::Praise2_Output* praise0_value)
{
    ptr_praiseOutputBuffer_Subset = reinterpret_cast<Avril_FSD::Object*>(praise0_value);
}
void Avril_FSD::Output::Set_control_Of_Output(Avril_FSD::Output_Control* output_Control)
{

}