using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avril.ServerAssembly.Praise_Files
{
    public class User_O
    {
        static private Avril.ServerAssembly.UserOut.Praise0_Output praise0_Output;
        static private Avril.ServerAssembly.UserOut.Praise1_Output praise1_Output;

        public User_O()
        {
            praise0_Output = new Avril.ServerAssembly.UserOut.Praise0_Output();
            praise1_Output = new Avril.ServerAssembly.UserOut.Praise1_Output();
        }

        public Avril.ServerAssembly.UserOut.Praise0_Output GetPraise0_Outnput()
        {
            return praise0_Output;
        }

        public Avril.ServerAssembly.UserOut.Praise1_Output GetPraise1_Output()
        {
            return praise1_Output;
        }
    }
}
