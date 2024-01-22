using Dumplings.Api.Event.Events;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.Brushes;
using Myra.Graphics2D.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Dumplings.Core.Sprites
{
    public class GameTimer
    {
        private Desktop _desktop = new();
        private Label _timerWidget;

        public GameTimer()
        {
            DumplingsGame.GetInstance().EventBus.Subscribe<LoadContentEvent>(this.OnLoadContentEvent);
            DumplingsGame.GetInstance().EventBus.Subscribe<GameDrawingEvent>(this.OnDrawEvent);
        }

        public void OnLoadContentEvent(LoadContentEvent e)
        {
            _timerWidget = new Label();
            _timerWidget.ZIndex = 9999;
            _timerWidget.Text = "Game Timer";
            _timerWidget.VerticalAlignment = VerticalAlignment.Top;
            _timerWidget.HorizontalAlignment = HorizontalAlignment.Left;
            _timerWidget.Background = new SolidBrush(Color.Black);
            _timerWidget.TextColor = Color.PaleVioletRed;

            _desktop.Root = _timerWidget;
        }


        private void OnDrawEvent(GameDrawingEvent e)
        {

            var gt = e.GameTime;
            _timerWidget.Text = gt.TotalGameTime.ToString("hh\\:mm\\:ss");

            _desktop.Render();
        }
    }
}
