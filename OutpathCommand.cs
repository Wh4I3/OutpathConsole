using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutpathConsole
{
    public abstract class OutpathCommand
    {
        public virtual string CommandName => "";
        public virtual string CommandDesc => "";
        
        public virtual string Command(string input)
        {
            return "";
        }
    }
}
