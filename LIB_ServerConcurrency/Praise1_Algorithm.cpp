#include "pch.h"

#include <cstddef>

Avril_FSD::Praise1_Algorithm::Praise1_Algorithm()
{
}

Avril_FSD::Praise1_Algorithm::~Praise1_Algorithm()
{
}

void Avril_FSD::Praise1_Algorithm::Do_Praise(Avril_FSD::Framework_Server* obj, Avril_FSD::Player* player, Avril_FSD::Praise1_Input* in_SubSet, Avril_FSD::Praise1_Output* out_SubSet)
{
    if (player->Get_isFirstMouseMove())
    {
        std::vector<float> mousePosition = {in_SubSet->Get_mouse_X(), in_SubSet->Get_mouse_Y()};
        player->Set_mouse_Position(mousePosition);
        player->Set_isFirstMouseMove(false);
    }
    else
    {
        switch (player->Get_cameraSelector())
        {
        case false:
            if ((in_SubSet->Get_mouse_X() != (float)(obj->Get_Server_Assembly()->Get_Data()->Get_GameInstance()->Get_settings()->Get_screenSize_X() / 2))
                || (in_SubSet->Get_mouse_Y() != (float)(obj.Get_server().Get_data().Get_settings().Get_ScreenSize_Y() / 2)))
            {
                float sensitivity = _gameObjectFactory.Get_player().Get_sensitivity();
                float anglePerPixle = obj.Get_server().Get_data().Get_settings().Get_fov() / obj.Get_server().Get_data().Get_settings().Get_ScreenSize_Y();
                float deltaX = anglePerPixle * (mouseState.X - (obj.Get_server().Get_data().Get_settings().Get_ScreenSize_X() / 2));
                float deltaY = anglePerPixle * (mouseState.Y - (obj.Get_server().Get_data().Get_settings().Get_ScreenSize_Y() / 2));
                System.Console.WriteLine("TESTBENCH => deltaX = " + deltaX + "  deltaY = " + deltaY);

                _gameObjectFactory.Get_player().Get_CameraFP().Update_Yaw(deltaX);
                System.Console.WriteLine("yaw => " + _gameObjectFactory.Get_player().Get_CameraFP().Get_Yaw());
                _gameObjectFactory.Get_player().Get_CameraFP().Update_Pitch(deltaY);
                System.Console.WriteLine("pitch => " + _gameObjectFactory.Get_player().Get_CameraFP().Get_Pitch());

                Get_gameObjectFactory().Get_player().Get_CameraFP().UpdateVectors(_gameObjectFactory.Get_player().Get_CameraFP().Get_Pitch(), _gameObjectFactory.Get_player().Get_CameraFP().Get_Yaw());

                OpenTK.Input.Mouse.SetPosition((double)(obj.Get_server().Get_data().Get_settings().Get_ScreenSize_X() / 2), (double)(obj.Get_server().Get_data().Get_settings().Get_ScreenSize_Y() / 2));
            }
            break;

        case true:

            break;
        }
    }
    _lastMouseState = mouseState;
    Console.WriteLine("TESTBENCH => HandleMouse .. Done");
}