
namespace Avril.ClientAssembly
{
    public class Concurrency_Control
    {

        public Concurrency_Control() 
        { 
        
        }

        public void SelectSet_Algorithm_Subset(Avril.ClientAssembly.Framework_Client obj, byte concurrent_coreId, byte ptr_praiseEventId)
        {
            switch (ptr_praiseEventId)
            {
                case 0:
                    obj.Get_client().Get_algorithms().Get_concurrency(concurrent_coreId).Set_algorithm_Subset(obj.Get_client().Get_algorithms().Get_user_Alg().Get_praise0_Algorithm());
                    break;

                case 1:
                    obj.Get_client().Get_algorithms().Get_concurrency(concurrent_coreId).Set_algorithm_Subset(obj.Get_client().Get_algorithms().Get_user_Alg().Get_praise1_Algorithm());
                    break;

                case 2:
                    //obj.Get_client().Get_algorithms().Get_concurrency(concurrent_coreId).Set_algorithm_Subset(obj.Get_client().Get_algorithms().Get_user_Alg().Get_praise2_Algorithm());
                    break;
            }
        }
    }
}
