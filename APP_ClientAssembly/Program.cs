namespace Avril.ClientAssembly
{
    class Program
    {
        static private Avril.ClientAssembly.Framework_Client framework = null;

        static void Main(string[] args)
        {
            framework = new Avril.ClientAssembly.Framework_Client();
            while (framework == null) { /* wait untill is created */ }
            framework.Initialise(framework);

            while (true) { }
        }

        static public Avril.ClientAssembly.Framework_Client Get_framework_Client()
        {
            return framework;
        }
    }
}
