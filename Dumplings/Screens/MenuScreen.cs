using Dumplings.Api.Event.Events;
using Dumplings.Api.State;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D;
using Myra.Graphics2D.TextureAtlases;
using Myra.Graphics2D.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumplings.Core.Screens
{
    public class MenuScreen
    {
        private bool _isEnabled = false;
        private Desktop _desktop;

        public MenuScreen() {
            DumplingsGame.GetInstance().EventBus.Subscribe<GameStateChangedEvent>(this.OnGameStateChangedEvent);
            DumplingsGame.GetInstance().EventBus.Subscribe<LoadContentEvent>(this.OnGameLoadEvent);
            DumplingsGame.GetInstance().EventBus.Subscribe<GameDrawingEvent>(this.OnDrawEvent);
        }

        public void OnGameStateChangedEvent(GameStateChangedEvent e)
        {
            if (e.To == GameState.MAIN_MENU)
                _isEnabled = true;
        }

        public void OnGameLoadEvent(LoadContentEvent e)
        {
            if (!_isEnabled)
                return;

            var grid = new Grid
            {
                ShowGridLines = true,
                ColumnSpacing = 8,
                RowSpacing = 8,
            };

            Texture2D background = DumplingsGame.GetInstance().Content.Load<Texture2D>("Background");
            grid.Background = new TextureRegion(background);

            // Set partitioning configuration
            grid.ColumnsProportions.Add(new Proportion(ProportionType.Fill));
            grid.RowsProportions.Add(new Proportion(ProportionType.Fill));

            // Add widgets
            var playButton = new TextButton();
            playButton.Text = "Play";
            playButton.Height = 60;
            playButton.Width = 120;
            playButton.VerticalAlignment = VerticalAlignment.Center;
            playButton.HorizontalAlignment = HorizontalAlignment.Center;
            playButton.Click += (sender, args) => DumplingsGame.GetInstance().EventBus.Publish(new GameStateChangedEvent(null, GameState.OFFLINE_PLAY));
            grid.Widgets.Add(playButton);

            var exitButton = new TextButton();
            exitButton.Text = "Quit";
            Grid.SetRow(exitButton, 1);
            exitButton.Height = 60;
            exitButton.Width = 120;
            exitButton.VerticalAlignment = VerticalAlignment.Center;
            exitButton.HorizontalAlignment = HorizontalAlignment.Center;
            exitButton.Click += (sender, args) => DumplingsGame.GetInstance().EventBus.Publish(new GameCloseEvent());
            grid.Widgets.Add(exitButton);

            Desktop desktop = new Desktop();
            desktop.Root = grid;

            _desktop = desktop;
        }

        public void OnDrawEvent(GameDrawingEvent e)
        {
            if (!_isEnabled)
                return;

            _desktop.Render();
        }
    }
}
