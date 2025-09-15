namespace Avril_FSD.ServerAssembly
{
    static class Program
    {
        static private Avril.ServerAssembly.Framework_Server _framework_ServerAssembly = null;
        static private IntPtr _program_ServerConcurrency;

        static void Main()
        {
            System.Console.WriteLine("ENTERED => app entry point.");//TestBench
            _framework_ServerAssembly = new Avril.ServerAssembly.Framework_Server();
            while (_framework_ServerAssembly == null) { /* wait until class created */ }
            _framework_ServerAssembly.Initialise(_framework_ServerAssembly);
            System.Console.WriteLine("Created: Server App Architechture.");//TestBench
        }

        static public Avril.ServerAssembly.Framework_Server Get_framework_Server()
        {
            return _framework_ServerAssembly;
        }
    }
}