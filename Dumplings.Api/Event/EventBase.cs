using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumplings.Api.Event
{
    public abstract class EventBase : IEvent
    {
        private bool _isCancelled = false;

        public bool IsCancelled { 
            get { return _isCancelled; } 
            set { _isCancelled = value; }
        }
    }
}
