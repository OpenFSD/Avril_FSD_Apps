using OpenTK;

namespace Avril.ClientAssembly.Praise_Files
{
    public class Praise1_Output
    {
        Vector3 _fowards;
        Vector3 _right;
        Vector3 _up;

        public Praise1_Output() 
        { 
        
        }

        public Vector3 Get_fowards()
        {
            return _fowards;
        }
        public Vector3 Get_right()
        {
            return _fowards;
        }
        public Vector3 Get_up()
        {
            return _fowards;
        }

        public void Set_fowards(Vector3 fowards)
        {
            _fowards = fowards;
        }
        public void Set_right(Vector3 right)
        {
            _right = right;
        }   
        public void Set_up(Vector3 up)
        {
            _up = up;
        }
    }
}
