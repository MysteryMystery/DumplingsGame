using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumplings.Api
{
    public class Dumpling
    {
        private DumplingType _dumplingType;

        public Dumpling(DumplingType type)
        {
            this._dumplingType = type;
        }

        public DumplingType DumplingType
        {
            get => _dumplingType; 
        }
    }
}
