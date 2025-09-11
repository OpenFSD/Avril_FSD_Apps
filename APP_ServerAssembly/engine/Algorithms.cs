namespace Avril.ServerAssembly
{
    public class Algorithms
    {
        private Avril.ServerAssembly.Concurrent[] _concurrent;
        private Avril.ServerAssembly.IO_Listen_Respond _io_ListenRespond;
        private Avril.ServerAssembly.Praise_Files.User_Alg _user_Alg;

        public Algorithms(int numberOfCores) 
        {
            Set_user_Alg(new Praise_Files.User_Alg());
            while (Get_user_Alg() == null) { }
            System.Console.WriteLine("Avril.ServerAssembly: Algorithms");//TEST
        }

        public void Initialise(int numberOfCores)
        {
            Set_io_ListenRespond(new Avril.ServerAssembly.IO_Listen_Respond());
            while (Get_io_ListenRespond() == null) { }
            Get_io_ListenRespond().InitialiseControl();

            Set_concurrent(new Avril.ServerAssembly.Concurrent[2]);//Number Of Cores - 2

        }

        public Avril.ServerAssembly.Concurrent Get_concurrent(byte concurrentCoreId)
        {
            return _concurrent[concurrentCoreId];
        }

        public Avril.ServerAssembly.IO_Listen_Respond Get_io_ListenRespond()
        {
            return _io_ListenRespond;
        }

        public Praise_Files.User_Alg Get_user_Alg()
        {
            return _user_Alg;
        }

        private void Set_concurrent(Avril.ServerAssembly.Concurrent[] value)
        {
            _concurrent = value;
            for (byte i = 0; i < _concurrent.Length; i++)
            {
                _concurrent[i] = new Avril.ServerAssembly.Concurrent();
                while (_concurrent[i] == null) { }
                _concurrent[i].InitialiseControl();
            }
        }
        private void Set_io_ListenRespond(Avril.ServerAssembly.IO_Listen_Respond value)
        {
            _io_ListenRespond = value;
        }
        private void Set_user_Alg(Praise_Files.User_Alg value)
        {
            _user_Alg = value;
        }
    }
}
