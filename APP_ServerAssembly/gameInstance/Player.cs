using OpenTK;
using Avril.ServerAssembly.Graphics.Cameras;
using Avril.ServerAssembly.Graphics.GameObjects;
using Avril.ServerAssembly.Graphics.Renderables;

namespace Avril.ServerAssembly.GameInstance
{
    public class Player : AGameObject
    {
        private bool _isFirstMove;
        private bool _isFirstMouseMove;
        private Vector2 mousePos;
        private FirstPersonCamera _cameraFP;
        private ThirdPersonCamera _cameraTP;
        private float cameraSpeed;
        private float sensitivity;

        public Player(ARenderable model, Vector3 position, Vector3 direction, Vector3 rotation, float velocity)
            : base(model, position, direction, rotation, velocity)
        {
            _isFirstMove = true;
            _isFirstMouseMove = true;
            mousePos = new Vector2(0, 0);
            _cameraFP = null;
            _cameraTP = null;
            cameraSpeed = 1.5f;
            sensitivity = 1f;
        }
        public void Create_Cameras()
        {
            _cameraFP = new FirstPersonCamera(
                this
            );
            while (_cameraFP == null) { }

            _cameraTP = new ThirdPersonCamera(
                this
            );
            while (_cameraTP == null) { }
        }

        public FirstPersonCamera Get_CameraFP()
        {
            return _cameraFP;
        }
        public ThirdPersonCamera Get_CameraTP()
        {
            return _cameraTP;
        }

        public bool Get_isFirstMove()
        {
            return _isFirstMove;
        }
        public bool Get_isFirstMouseMove()
        {
            return _isFirstMouseMove;
        }
        public Vector2 Get_MousePos()
        {
            return mousePos;
        }

        public float Get_cameraSpeed()
        {
            return cameraSpeed;
        }

        public float Get_sensitivity()
        {
            return sensitivity;
        }



        public void Get_isFirstMove(bool value)
        {
            _isFirstMove = value;
        }
        public void Get_isFirstMouseMove(bool value)
        {
            _isFirstMouseMove = value;
        }

        public void Set_MousePos(Vector2 pos)
        {
            mousePos = pos;
        }


    }
}

