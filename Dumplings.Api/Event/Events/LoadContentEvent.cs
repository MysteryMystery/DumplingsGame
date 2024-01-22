using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Myra.Graphics2D.UI;

namespace Dumplings.Api.Event.Events
{
    public class LoadContentEvent : EventBase
    {
        private Game _game;

        public LoadContentEvent(Game game)
        {
            _game = game;
        }

        public Game Game => _game;
    }
}
