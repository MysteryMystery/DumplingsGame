using Dumplings.Api;
using Dumplings.Api.Event;
using Dumplings.Api.Event.Events;
using Dumplings.Api.State;
using Dumplings.Core.Screens;
using Dumplings.Core.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Myra;
using Myra.Graphics2D.UI;

namespace Dumplings.Core
{
    public class DumplingsGame : Game
    {
        private static DumplingsGame _instance;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private EventBus _eventBus;

        private GameStateChangedEvent _previousStateChange;

        public DumplingsGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _instance = this;
        }

        public static DumplingsGame GetInstance() => _instance;

        public EventBus EventBus => _eventBus;

        private void publishGameState(GameState state)
        {
            var n = new GameStateChangedEvent(_previousStateChange?.To, state);
            _eventBus.Publish(n);
        }

        protected override void Initialize()
        {
            MyraEnvironment.Game = this;

            // TODO: Add your initialization logic here
            _eventBus = new();
            _eventBus.Subscribe<GameStateChangedEvent>(e => _previousStateChange = e);
            _eventBus.Subscribe<GameCloseEvent>(e => { if (!e.IsCancelled) Exit(); });

            publishGameState(GameState.INITIALISING);

            // screens
            var menuScreen = new MenuScreen();
            var offlinePlay = new PlayGameScreen();
            var gameTimer = new GameTimer();

            _eventBus.Publish(new GameInitialisingEvent());

            publishGameState(GameState.MAIN_MENU);

            base.Initialize();
        }

        protected override void LoadContent()
        { 
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _eventBus.Publish(new LoadContentEvent(this));


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                _eventBus.Publish(new GameCloseEvent());

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGray);

            // TODO: Add your drawing code here

            _eventBus.Publish(new GameDrawingEvent(gameTime));

            base.Draw(gameTime);
        }
    }
}