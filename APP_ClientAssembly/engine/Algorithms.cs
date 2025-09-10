namespace Avril.ClientAssembly
{
    public class Algorithms
    {
        private Avril.ClientAssembly.Concurrent[] _concurrent;
        private Avril.ClientAssembly.IO_Listen_Respond _io_ListenRespond;
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

            Set_concurrent(new Avril.ClientAssembly.Concurrent[2]);//Number Of Cores - 2

        }

        public Avril.ClientAssembly.Concurrent Get_concurrent(byte concurrentCoreId)
        {
            return _concurrent[concurrentCoreId];
        }

        public Avril.ClientAssembly.IO_Listen_Respond Get_io_ListenRespond()
        {
            return _io_ListenRespond;
        }

        public Praise_Files.User_Alg Get_user_Alg()
        {
            return _user_Alg;
        }

        private void Set_concurrent(Avril.ClientAssembly.Concurrent[] value)
        {
            _concurrent = value;
            for (byte i = 0; i < _concurrent.Length; i++)
            {
                _concurrent[i] = new Avril.ClientAssembly.Concurrent();
                while (_concurrent[i] == null) { }
                _concurrent[i].InitialiseControl();
            }
        }
        private void Set_io_ListenRespond(Avril.ClientAssembly.IO_Listen_Respond value)
        {
            _io_ListenRespond = value;
        }
        private void Set_user_Alg(Praise_Files.User_Alg value)
        {
            _user_Alg = value;
        }
    }
}
