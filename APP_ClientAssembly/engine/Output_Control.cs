using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avril.ClientAssembly.Outputs
{
    public class Output_Control
    {
        public Output_Control() 
        {

        }

        void SelectSetOutputSubset(Avril.ClientAssembly.Framework_Client obj, int praiseEventId)
        {
            switch (praiseEventId)
            {
                case 0:
                    obj.Get_Client().Get_Data().GetOutput_Instnace().GetBuffer_BackOutputDouble(obj).SetInputBufferSubSet(obj.Get_Client().Get_Data().GetUserI().GetPraise0_Input());
                    break;

                case 1:
                    obj.Get_Client().Get_Data().GetOutput_Instnace().GetBuffer_BackOutputDouble(obj).SetInputBufferSubSet(obj.Get_Client().Get_Data().GetUserI().GetPraise1_Input());
                    break;

                case 2:
                    obj.Get_Client().Get_Data().GetOutput_Instnace().GetBuffer_BackOutputDouble(obj).SetInputBufferSubSet(obj.Get_Client().Get_Data().GetUserI().GetPraise2_Input());
                    break;

            }
        }
    }
}
