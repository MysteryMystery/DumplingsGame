using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumplings.Api.Logic.Screen
{
    public class PlayGameScreenLogic
    {
        private int _numPlayers;
        private List<PlayerBoard> _playerBoards = new();
        private DumplingBag _bag;

        public PlayGameScreenLogic(int numPlayers = 4)
        {
            this._numPlayers = numPlayers;
            for (int i = 0; i< numPlayers; i++)
            {
                _playerBoards.Add(new PlayerBoard());
            }

            this._bag = new();
        }

        public Tuple<SmallDice, MediumDice, LargeDice> RollDice()
        {
            throw new NotImplementedException();
        }

        public List<PlayerBoard> PlayerBoards => _playerBoards;

        public DumplingBag DumplingBag => _bag;
    }
}
