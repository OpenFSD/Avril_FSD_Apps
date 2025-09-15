
namespace Avril.ClientAssembly.Praise_Files
{
    public class Praise0_Algorithm
    {
        public Praise0_Algorithm() 
        { 
        
        }
        public void Do_Praise(Avril.ClientAssembly.Game_Instance gameInstance, byte playerId, Avril.ClientAssembly.Praise_Files.Praise0_Output in_SubSet)
        {
            if(in_SubSet.GetFlag_IsPingActive() == true) Console.WriteLine("ping sent and ecieved.");
        }
    }
}
