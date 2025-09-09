
namespace Avril.ServerAssembly
{
    public class Global
    {
        private byte numberOfCores;

        public Global()
        {
            numberOfCores = 2;
        }

        public byte Get_NumCores()
        {
            return numberOfCores;
        }
    }
}