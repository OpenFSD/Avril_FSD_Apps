using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avril.ClientAssembly
{
    public class Algorithms
    {
        static private Avril.ClientAssembly.Concurrent[] concurrent;
        static private Avril.ClientAssembly.IO_Listen_Respond io_ListenRespond;
        static private Avril.ClientAssembly.Praise_Files.User_Alg user_Alg;

        public Algorithms(int numberOfCores) 
        {

            System.Console.WriteLine("Avril.ClientAssembly: Algorithms");//TEST
        }

        public void Initialise(int numberOfCores)
        {
            io_ListenRespond = new Avril.ClientAssembly.IO_Listen_Respond();
            while (io_ListenRespond == null) { /* wait untill class constructed */ }
            io_ListenRespond.InitialiseControl();

            concurrent = new Avril.ClientAssembly.Concurrent[2];//Number Of Cores - 2
            for (byte i = 0; i < (numberOfCores - 2); i++)
            {
                concurrent[i] = new Avril.ClientAssembly.Concurrent();
                while (concurrent[i] == null) { /* wait untill class constructed */ }
                concurrent[i].InitialiseControl();
            }
        }

        public Avril.ClientAssembly.Concurrent GetConcurrent(byte index)
        {
            return concurrent[index];
        }

        public Avril.ClientAssembly.IO_Listen_Respond GetIO_ListenRespond()
        {
            return io_ListenRespond;
        }
    }
}
