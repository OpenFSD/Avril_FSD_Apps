using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avril.ServerAssembly.Praise_Files
{
    public class Praise1_Algorithm
    {
        public Praise1_Algorithm() 
        { 
        
        }
        public void Do_Praise(Avril.ServerAssembly.Praise_Files.Praise1_Input in_SubSet, Avril.ServerAssembly.Praise_Files.Praise1_Output out_SubSet)
        {
/*
            if (_gameObjectFactory.Get_player().Get_IsFirstMouseMove()) // This bool variable is initially set to true.
            {
                _gameObjectFactory.Get_player().Set_MousePos(new Vector2(mouseState.X, mouseState.Y));
                _gameObjectFactory.Get_player().Set_IsFirstMouseMove(false);
            }
            else
            {



                switch (cameraSelector)
                {
                    case false:
                        if ((mouseState.X != (float)(obj.Get_server().Get_data().Get_settings().Get_ScreenSize_X() / 2))
                            || (mouseState.Y != (float)(obj.Get_server().Get_data().Get_settings().Get_ScreenSize_Y() / 2)))
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
*/
        }
    }
}
