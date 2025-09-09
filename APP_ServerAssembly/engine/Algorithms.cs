namespace Avril.ServerAssembly
{
    public class Algorithms
    {
        static private Avril.ServerAssembly.IO_ListenRespond io_ListenRespond;

        public Algorithms(byte numberOfCores)
        {
            System.Console.WriteLine("Avril.ServerAssembly: Algorithms");//TEST
        }

        public void Initialise(byte numberOfCores)
        {
            io_ListenRespond = new Avril.ServerAssembly.IO_ListenRespond();
            while (io_ListenRespond == null) { /* wait untill class constructed */ }
            io_ListenRespond.InitialiseControl();
        }

        public Avril.ServerAssembly.IO_ListenRespond GetIO_ListenRespond()
        {
            return io_ListenRespond;
        }
    }
}