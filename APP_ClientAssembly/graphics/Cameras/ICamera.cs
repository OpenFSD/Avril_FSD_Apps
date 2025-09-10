using OpenTK;

namespace Avril.ClientAssembly.Graphics.Cameras
{
    public interface ICamera
    {
        Matrix4 LookAtMatrix { get; }
        void Update(double time, double delta);
    }
}