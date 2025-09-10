namespace Avril.ClientAssembly
{
    public class Client
    {
        private Avril.ClientAssembly.Algorithms _algorithms;
        private Avril.ClientAssembly.Data _data;
        private Avril.ClientAssembly.Execute _execute;
        private Avril.ClientAssembly.Global _global;

        public Client() 
        {
            Set_global(new Avril.ClientAssembly.Global());
            while (Get_global() == null) { }

            Set_algorithms(new Avril.ClientAssembly.Algorithms(Get_global().Get_numberOfCores()));
            while (Get_algorithms() == null) { }

            Set_data(new Avril.ClientAssembly.Data());
            while (Get_data() == null) { }
            Get_data().InitialiseControl();

            Set_execute(new Avril.ClientAssembly.Execute(Get_global().Get_numberOfCores()));
            while (Get_execute() == null) { }
            Get_execute().Initialise_Control(Get_global().Get_numberOfCores(), Get_global());

        }

        public Avril.ClientAssembly.Algorithms Get_algorithms()
        {
            return _algorithms;
        }
        public Avril.ClientAssembly.Data Get_data()
        {
            return _data;
        }
        public Avril.ClientAssembly.Execute Get_execute()
        {
            return _execute;
        }

        public Avril.ClientAssembly.Global Get_global()
        {
            return _global;
        }
        private void Set_algorithms(Avril.ClientAssembly.Algorithms value)
        {
            _algorithms = value;
        }
        private void Set_data(Avril.ClientAssembly.Data value)
        {
            _data = value;
        }
        private void Set_execute(Avril.ClientAssembly.Execute value)
        {
            _execute = value;
        }
        private void Set_global(Avril.ClientAssembly.Global value)
        {
            _global = value;
        }
    }
}