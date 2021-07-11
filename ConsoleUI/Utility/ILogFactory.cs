using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Utility
{
    class ILogFactory
    {
        public ILog GetILog()
        {
            return new ILog();
        }
    }
}
