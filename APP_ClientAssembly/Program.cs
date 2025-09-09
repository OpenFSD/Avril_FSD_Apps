
namespace Avril_FSD.ServerAssembly
{
    static class Program
    {
        private static Avril_FSD.ServerAssembly.Framework framework_ServerAssembly = null;

        static void Main()

        {
            System.Console.WriteLine("ENTERED => app entry point.");//TestBench

            framework_ServerAssembly = new Avril_FSD.ServerAssembly.Framework();
            while (framework_ServerAssembly == null) { /* wait until class created */ }
            System.Console.WriteLine("Created: Client App Architechture.");//TestBench

            while (true)
            {

            }
        }

    }
}