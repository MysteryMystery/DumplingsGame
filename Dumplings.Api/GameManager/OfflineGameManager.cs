using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumplings.Api.GameManager
{
    public class OfflineGameManager
    {
        private List<PlayerBoard> _boards = new List<PlayerBoard>();
        private int _activePlayer = 0;

        public OfflineGameManager(int numPlayers = 4)
        {
            for (int i = 0; i < numPlayers; i++)
                _boards.Add(new());
        }

        public void OnTurnStartedEvent()
        {
            // roll the dice
        }

        public void OnDiceRolledEvent()
        {
            // player and next play select the dice
        }

        public void OnDiceSelectedEvent()
        {
            // enact the dice
        }

        public void OnTurnEndEvent()
        {
            // increment counter
            _activePlayer++;
            if (_activePlayer > _boards.Count-1)
                _activePlayer = 0;
        }
    }
}
