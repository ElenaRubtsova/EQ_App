using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing_Nancyfx_wnc
{
    public class EQAgentOptions
    {
        public string DispatcherAddress { set; get; }
        public Guid GUID { set; get; }

        public int DispatcherTimeout { set; get; }
        public EQAgentOptions()
        {
            DispatcherTimeout = 20;
        }
    }
}
