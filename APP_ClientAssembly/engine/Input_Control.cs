
namespace Avril.ClientAssembly.Inputs
{
    public class Input_Control
    {
        public Input_Control()
        {

        }
/*
        public void LoadValuesInToInputSubset(
            ushort praiseEventId,
            float period
        )
        {
            Avril.ClientAssembly.Inputs.Input newSLot_Stack_InputAction = Avril.ClientAssembly.Framework.Get_client().Get_data().Get_input_Instnace().GetEmptyInput();
            newSLot_Stack_InputAction.SetPraiseEventId(praiseEventId);
            switch (praiseEventId)
            {
                case 0:

                    break;

                case 1:
                    Avril.ClientAssembly.Praise_Files.Praise1_Input desternation_Subset = (Avril.ClientAssembly.Praise_Files.Praise1_Input)Framework.Get_client().Get_data().Get_input_Instnace().Get_Transmit_InputBuffer().Get_InputBufferSubset();
                    Vector2 mouse = Framework.Get_client().Get_data().GetGame_Instance().GetPlayer(0).GetMousePos();
                    desternation_Subset.Set_Mouse_X(mouse.X);
                    desternation_Subset.Set_Mouse_Y(mouse.Y);
                    break;
            }
        }
*/
        public void SelectSetIntputSubset(Avril.ClientAssembly.Framework_Client obj, int praiseEventId)
        {
            switch (praiseEventId)
            {
                case 0:
                    obj.Get_client().Get_data().Get_input_Instnace().Get_FRONT_inputDoubleBuffer(obj).Set_praiseInputBuffer_Subset(obj.Get_client().Get_data().Get_user_I().GetPraise0_Input());
                    break;

                case 1:
                    obj.Get_client().Get_data().Get_input_Instnace().Get_FRONT_inputDoubleBuffer(obj).Set_praiseInputBuffer_Subset(obj.Get_client().Get_data().Get_user_I().GetPraise1_Input());
                    break;

		        case 2:
                    obj.Get_client().Get_data().Get_input_Instnace().Get_FRONT_inputDoubleBuffer(obj).Set_praiseInputBuffer_Subset(obj.Get_client().Get_data().Get_user_I().GetPraise2_Input());
                    break;
            }
		}
    }
}
