using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_1_5_Summative
{

    enum Screen 
    {
        Intro, 
        Start,
        Travel,
        Outro
    }


    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        MouseState mouseState, prevMouseState;

        Screen screen;

        Texture2D delorianTexture, introTexture, mallTexture, hillValleyTexture, outroTexture, travelTexture;

        Rectangle delorianRect, window;

        SoundEffect introOutroSound, gameSound;

        SoundEffectInstance introOutroInstance, gameSoundInstance;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0, 0, 800, 600);

            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            delorianTexture = Content.Load<Texture2D>("delorian");

            mallTexture = Content.Load<Texture2D>("parkingLot");

            hillValleyTexture = Content.Load<Texture2D>("hillValley");

            outroTexture = Content.Load<Texture2D>("outro");

            travelTexture = Content.Load<Texture2D>("galaxy");

            introTexture = Content.Load<Texture2D>("intro");

            introOutroSound = Content.Load<SoundEffect>("mainTheme");

            gameSound = Content.Load<SoundEffect>("bttfJingle");

            introOutroInstance = introOutroSound.CreateInstance();

            gameSoundInstance = gameSound.CreateInstance();
            
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            prevMouseState = mouseState;

            mouseState = Mouse.GetState();
            
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
