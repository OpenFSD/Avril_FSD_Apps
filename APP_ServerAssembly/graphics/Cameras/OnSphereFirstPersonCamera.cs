using OpenTK;
using Avril.ServerAssembly.Graphics.GameObjects;
using Avril.ServerAssembly.GameInstance;

namespace Avril.ServerAssembly.Graphics.Cameras
{
    public class OnSphereFirstPersonCamera : ICamera
    {
        public Matrix4 LookAtMatrix { get; private set; }
        private Player _player;
        private Vector3 _offset;
        private Vector3 _position;
        private Vector3 _rotation;
        private float _pitch;
        private float _yaw;
        private Vector3 _fowards;
        private Vector3 _up;
        private Vector3 _right;
        private Vector3 _axisX;
        private Vector3 _axisY;
        private Vector3 _axisZ;

        public OnSphereFirstPersonCamera(Player player)
        {
            _player = player;
            _position = _player.Get_position();
            _rotation = _player.Get_Rotation();

            _pitch = 0;
            _yaw = 0;
        }

        public void ApplyMouseAtPlayerPosition(Player player, float deltaRadAroundUp, float deltaRadAroundRight)
        {




















        }

        public void AlignePlayerAtGlobalSurfacePosition(Player player, double dt)
        {
            System.Console.WriteLine("TESTBENCH => entered AlignePlayerAtGlobalSurfacePosition");
        }
        
        public void Update(double time, double delta)
        {
            LookAtMatrix = Matrix4.LookAt(
                new Vector3(_player.Get_position()) + _offset,
                new Vector3(_player.Get_position() + _fowards) + _offset,
                new Vector3(_player.Get_position() + _up) + _offset
            );
        }

        public Vector3 Trim_Rotation_To_Fundermental_Octive(Vector3 value)
        {
            float rot_X = value.X;
            if (rot_X > (float)(Math.PI / 180) * 360)
            {
                rot_X = (rot_X - (float)(Math.PI * 2));
            }
            if (rot_X <= (Math.PI / 180) * 0)
            {
                rot_X = (rot_X + (float)(Math.PI * 2));
            }
            float rot_Y = value.Y;
            if (rot_Y > (float)(Math.PI / 180) * 360)
            {
                rot_Y = (rot_Y - (float)(Math.PI * 2));
            }
            if (rot_Y <= (Math.PI / 180) * 0)
            {
                rot_Y = (rot_Y + (float)(Math.PI * 2));
            }
            float rot_Z = value.Z;
            if (rot_Z > (float)(Math.PI / 180) * 360)
            {
                rot_Z = (rot_Z - (float)(Math.PI * 2));
            }
            if (rot_Z <= (Math.PI / 180) * 0)
            {
                rot_Z = (rot_Z + (float)(Math.PI * 2));
            }
            return new Vector3(rot_X, rot_Y, rot_Z);
        }
        public void Update_Pitch(float deltaRadY)
        {
            Set_Pitch(Get_Pitch() + deltaRadY);
            if (Get_Pitch() > (float)(Math.PI / 180) * 85)
            {
                Set_Pitch((float)(Math.PI / 180) * 85);
            }
            if (Get_Pitch() <= (Math.PI / 180) * -85)
            {
                Set_Pitch((float)(Math.PI / 180) * -85);
            }
        }
        public void Update_Yaw(float deltaRadX)
        {
            Set_Yaw(Get_Yaw() + deltaRadX);
            if (Get_Yaw() > (float)(Math.PI / 180) * 180)
            {
                Set_Yaw(Get_Yaw() - (float)(Math.PI * 2));
            }
            if (Get_Yaw() <= (Math.PI / 180) * -180)
            {
                Set_Yaw(Get_Yaw() + (float)(Math.PI * 2));
            }
        }

        //get
        public Vector3 Get_offset()
        {
            return _offset;
        }
        public Vector3 Get_Position()
        {
            return _position;
        }
        public Vector3 Get_Rotation()
        {
            return _rotation;
        }
        public float Get_Pitch()
        {
            return _pitch;
        }
        public float Get_Yaw()
        {
            return _yaw;
        }
        public Vector3 Get_fowards()
        {
            return _fowards;
        }
        public Vector3 Get_up()
        {
            return _up;
        }
        public Vector3 Get_right()
        {
            return _right;
        }
        public Vector3 Get_axisX()
        {
            return _axisX;
        }
        public Vector3 Get_axisY()
        {
            return _axisY;
        }
        public Vector3 Get_axisZ()
        {
            return _axisZ;
        }

        //set
        public void Set_offset(Vector3 value)
        {
            _offset = value;
        }
        public void Set_Position(Vector3 value)
        {
            _position = value;
        }
        public void Set_Rotation(Vector3 value)
        {
            _rotation = value;
        }
        public void Set_Pitch(float value)
        {
            _pitch = value;
        }
        public void Set_Yaw(float value)
        {
            _yaw = value;
        }
        public void Set_fowards(Vector3 value)
        {
            _fowards = value;
        }
        public void Set_up(Vector3 value)
        {
            _up = value;
        }
        public void Set_right(Vector3 value)
        {
            _right = value;
        }
        public void Set_axisX(Vector3 value)
        {
            _axisX = value;
        }
        public void Set_axisY(Vector3 value)
        {
            _axisY = value;
        }
        public void Set_axisZ(Vector3 value)
        {
            _axisZ = value;
        }
    }
}