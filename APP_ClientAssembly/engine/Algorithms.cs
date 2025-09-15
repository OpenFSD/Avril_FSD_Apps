namespace Avril.ClientAssembly
{
    public class Algorithms
    {
        private Avril.ClientAssembly.IO_Listen_Respond _io_ListenRespond;
        private Avril.ClientAssembly.Concurrency[] _concurrency;
        private Avril.ClientAssembly.Praise_Files.User_Alg _user_Alg;

        public Algorithms(int numberOfCores) 
        {
            Set_user_Alg(new Praise_Files.User_Alg());
            while (Get_user_Alg() == null) { }
            System.Console.WriteLine("Avril.ClientAssembly: Algorithms");//TEST
        }

        public void Initialise(int numberOfCores)
        {
            Set_io_ListenRespond(new Avril.ClientAssembly.IO_Listen_Respond());
            while (Get_io_ListenRespond() == null) { }
            Get_io_ListenRespond().InitialiseControl();

            _concurrency = new Avril.ClientAssembly.Concurrency[numberOfCores - 2];
            for (byte index = 0; index < numberOfCores - 2; index++)
            {
                Set_concurrency(index, new Avril.ClientAssembly.Concurrency());
                while (Get_concurrency(index) == null) { }
                Get_concurrency(index).Initialise_Control();
            }
        }

        public Avril.ClientAssembly.IO_Listen_Respond Get_io_ListenRespond()
        {
            return _io_ListenRespond;
        }
        public Concurrency Get_concurrency(byte concurrenctCoreId)
        {
            return _concurrency[concurrenctCoreId];
        }
        public Praise_Files.User_Alg Get_user_Alg()
        {
            return _user_Alg;
        }

        private void Set_io_ListenRespond(Avril.ClientAssembly.IO_Listen_Respond value)
        {
            _io_ListenRespond = value;
        }
        private void Set_concurrency(byte concurrenctCoreId, Concurrency value)
        {
            _concurrency[concurrenctCoreId] = value;
        }
        private void Set_user_Alg(Praise_Files.User_Alg value)
        {
            _user_Alg = value;
        }
    }
}
