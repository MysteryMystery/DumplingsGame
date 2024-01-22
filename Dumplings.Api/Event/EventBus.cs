using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumplings.Api.Event
{

    using System;
    using System.Collections.Generic;

    public class EventBus
    {
        private Dictionary<Type, List<Delegate>> _eventTable;

        public EventBus()
        {
            _eventTable = new Dictionary<Type, List<Delegate>>();
        }

        public void Subscribe<T>(Action<T> handler) where T : IEvent
        {
            Type type = typeof(T);
            if (!_eventTable.ContainsKey(type))
            {
                _eventTable[type] = new List<Delegate>();
            }
            _eventTable[type].Add(handler);
        }

        public void Unsubscribe<T>(Action<T> handler) where T : IEvent
        {
            Type type = typeof(T);
            if (_eventTable.ContainsKey(type))
            {
                _eventTable[type].Remove(handler);
            }
        }

        public void Publish<T>(T publishedEvent) where T : IEvent
        {
            Type type = typeof(T);
            if (_eventTable.ContainsKey(type))
            {
                foreach (Delegate handler in _eventTable[type])
                {
                    handler.DynamicInvoke(publishedEvent);
                }
            }
        }
    }

}
