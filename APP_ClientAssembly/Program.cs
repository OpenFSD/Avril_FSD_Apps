// Client Assembly
namespace Avril.ClientAssembly
{
    class Program
    {
        private static Avril.ClientAssembly.Framework_Client framework = null;

        static void Main(string[] args)
        {
            framework = new Avril.ClientAssembly.Framework_Client();
            while (framework == null) { /* wait untill is created */ }
            framework.Initialise(framework);

            System.Console.WriteLine("Avril.ClientAssembly START");//TEST
            while (true)
            {

            }
        }
    }
}
