using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumplings.Api.Event.Events
{
    public class GameDrawingEvent : EventBase
    {
        private GameTime _gameTime;

        public GameDrawingEvent(GameTime time) {
            this._gameTime = time;
        }

        public GameTime GameTime => _gameTime;
    }
}
