using Dumplings.Api.Event.Events;
using Dumplings.Api.Logic.Screen;
using Dumplings.Api.State;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D;
using Myra.Graphics2D.Brushes;
using Myra.Graphics2D.TextureAtlases;
using Myra.Graphics2D.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumplings.Core.Screens
{
    public class PlayGameScreen
    {
        private bool _isEnabled = false;
        private Desktop _desktop = new();

        private PlayGameScreenLogic _logic = new();

        public PlayGameScreen()
        {
            DumplingsGame.GetInstance().EventBus.Subscribe<GameStateChangedEvent>(this.OnGameStateChangedEvent);
            DumplingsGame.GetInstance().EventBus.Subscribe<LoadContentEvent>(this.OnGameLoadEvent);
            DumplingsGame.GetInstance().EventBus.Subscribe<GameDrawingEvent>(this.OnDrawEvent);
        }

        public void OnGameStateChangedEvent(GameStateChangedEvent e)
        {
            if (e.To == GameState.OFFLINE_PLAY)
                _isEnabled = true;
        }

        public void OnGameLoadEvent(LoadContentEvent e)
        {
            //if (!_isEnabled)
                //return;

            var grid = new Grid
            {
                ShowGridLines = true,
                ColumnSpacing = 8,
                RowSpacing = 8,
            };

            Texture2D background = DumplingsGame.GetInstance().Content.Load<Texture2D>("Background");
            grid.Background = new TextureRegion(background);

            // Set partitioning configuration
            grid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
            grid.RowsProportions.Add(new Proportion(ProportionType.Auto));

            grid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
            grid.RowsProportions.Add(new Proportion(ProportionType.Auto));

            grid.ColumnsProportions.Add(new Proportion(ProportionType.Auto));
            grid.RowsProportions.Add(new Proportion(ProportionType.Auto));

            // Add widgets

            // Dumplings Bag
            var dumplingBag = new TextureRegion(DumplingsGame.GetInstance().Content.Load<Texture2D>("DumplingBag"));
            Panel panel = new();
            panel.VerticalAlignment = VerticalAlignment.Center;
            panel.HorizontalAlignment = HorizontalAlignment.Center;
            panel.Background = dumplingBag;
            panel.Height = 160;
            panel.Width = 200;
            Grid.SetColumn(panel, 0);
            Grid.SetRow(panel, 0);
            grid.AddChild(panel);

            // centre tray
            var centreTray = new Panel();
            centreTray.Background = new TextureRegion(DumplingsGame.GetInstance().Content.Load<Texture2D>("DumplingTray"));
            centreTray.VerticalAlignment = VerticalAlignment.Center;
            centreTray.HorizontalAlignment = HorizontalAlignment.Center;
            centreTray.Height = 160;
            centreTray.Width = 200;
            Grid.SetRow(centreTray, 0);
            Grid.SetColumn(centreTray, 1);

            var label = new Label();
            label.Text = "Centre Dish";
            label.Background = new SolidBrush(Color.White);
            label.VerticalAlignment = VerticalAlignment.Center;
            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.TextColor = Color.Black;
            centreTray.AddChild(label);
            grid.AddChild(centreTray);

            // dice
            var dice = new Panel();
            dice.Background = new TextureRegion(DumplingsGame.GetInstance().Content.Load<Texture2D>("Dice"));
            dice.VerticalAlignment = VerticalAlignment.Center;
            dice.HorizontalAlignment = HorizontalAlignment.Center;
            dice.Height = 160;
            dice.Width = 200;
            Grid.SetRow(dice, 0);
            Grid.SetColumn(dice, 2);
            grid.AddChild(dice);

            // player boards
            var count = 0;
            foreach(var board in _logic.PlayerBoards)
            {
                var x = new VerticalSplitPane();
                x.Height = 160;
                x.Width = 250;

                var top = new Panel();
                top.Background = new SolidBrush(Color.Goldenrod);
                top.Height = 80;
                top.Width = 250;

                foreach (KeyValuePair<Api.DumplingType, int> dumpling in _logic.PlayerBoards[count].Dumplings)
                {
                    // put the unlinked dumplings onto board
                }

                x.AddChild(top);

                var bot = new Panel();
                bot.Background = new SolidBrush(Color.SlateGray);
                bot.Height = 80;
                bot.Width = 250;

                foreach (Api.DumplingType completedSet in _logic.PlayerBoards[count].CompletedSets)
                {
                    // put the completed sets onto the board
                }

                x.AddChild(bot);

                Grid.SetColumn(x, count < 3 ? count : 1);
                Grid.SetRow(x, count < 3 ? 1 : 2);
                grid.AddChild(x);
                count++;
            }

            _desktop.Root = grid;
        }

        public void OnDrawEvent(GameDrawingEvent e)
        {
            if (!_isEnabled)
                return;

            _desktop.Render();
        }
    }
}
