using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas_Law_Computation
{
    delegate void initialize_interface();
    class Event_Object
    {
        public event initialize_interface initialize_interface_event;

        public void initialize_user_interface()
        {
            if(initialize_interface_event!=null)
            {
                initialize_interface_event();
            }
        }

    }
}
