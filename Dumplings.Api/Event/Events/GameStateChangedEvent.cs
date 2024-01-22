using Dumplings.Api.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumplings.Api.Event.Events
{
    public class GameStateChangedEvent : EventBase
    {
        private GameState? _from;
        private GameState _to;

        public GameStateChangedEvent(GameState? from, GameState to) {
            _from = from;
            _to = to;
        }

        public GameState? From => _from;

        public GameState To => _to;
    }
}
