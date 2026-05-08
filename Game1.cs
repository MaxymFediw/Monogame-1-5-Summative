using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.CompilerServices;

namespace Monogame_1_5_Summative
{

    enum Screen 
    {
        Intro, 
        Start,
        Travel, //make the background look like its moving somehow.
        Outro,
        Done
    }


    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        

        MouseState mouseState, prevMouseState;

        Screen screen;

        Texture2D delorianTexture, sideDelorianTexture, delorianWingsTexture, introTexture, martyTexture, mallTexture, hillValleyTexture, outroTexture, travelTexture;

        Rectangle delorianRect, travelRect2, sideDelorianRect, delorianWingRect, martyRect, window, travelRect;

        SoundEffect introOutroSound, gameSound, jbGoode, backInTime;

        SoundEffectInstance introOutroInstance, backInTimeInstance, gameSoundInstance, jbGoodeInstance;

        SpriteFont textFont;
        
        int timer, stop;
        
        Vector2 travelSpeed;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            this.Window.Title = "";
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0, 0, 800, 600); 

            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            delorianRect = new Rectangle(246, 217, 430, 380);  
                                                    //width, height
            sideDelorianRect = new Rectangle(-250, 220, 500, 201);

            delorianWingRect = new Rectangle(100, 450, 200, 157);

            martyRect = new Rectangle(243, 486, 100, 150);

            travelRect = new Rectangle(0, 0, 1600, 600);

            travelSpeed = new Vector2(6, 0);

            travelRect2 = new Rectangle(1600, 0, 1600, 600);

            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            delorianTexture = Content.Load<Texture2D>("delorian");

            mallTexture = Content.Load<Texture2D>("parkingLot");

            hillValleyTexture = Content.Load<Texture2D>("hillValley");

            sideDelorianTexture = Content.Load<Texture2D>("sideDelorian");

            outroTexture = Content.Load<Texture2D>("outro");

            travelTexture = Content.Load<Texture2D>("galaxy");

            introTexture = Content.Load<Texture2D>("intro");

            introOutroSound = Content.Load<SoundEffect>("mainTheme");

            gameSound = Content.Load<SoundEffect>("bttfJingle");

            textFont = Content.Load<SpriteFont>("textFont");

            introOutroInstance = introOutroSound.CreateInstance();

            gameSoundInstance = gameSound.CreateInstance();

            jbGoode = Content.Load<SoundEffect>("johnnyBGoode");

            jbGoodeInstance = jbGoode.CreateInstance();

            delorianWingsTexture = Content.Load<Texture2D>("delorianWings");

            martyTexture = Content.Load<Texture2D>("martyMcFly");

            backInTime = Content.Load<SoundEffect>("Back In Time");

            backInTimeInstance = backInTime.CreateInstance();

            
            
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            prevMouseState = mouseState;

            mouseState = Mouse.GetState();

            this.Window.Title = mouseState.Position.ToString();
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                {
                    screen = Screen.Start;
                }
            }

            else if (screen == Screen.Start)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                {
                    screen = Screen.Travel;
                }
            }

            else if (screen == Screen.Travel)
            {
                timer += 1;
                travelRect.X -= 10;
                sideDelorianRect.X += 1;
                travelRect2.X -= 10;
                //travelSpeed.X *= 1;

                //travelRect.X -= (int)travelSpeed.X;

                //travelRect2.X -= (int)travelSpeed.X;

                if (timer >= 600)
                {
                    screen = Screen.Outro;
                    sideDelorianRect.X =-250;
                }
            }

            else if (screen == Screen.Outro) 
            {
                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released) 
                {
                   

                    screen = Screen.Done;
                }
            }
            else if (screen == Screen.Done)
            {
                sideDelorianRect.X += 1;
                stop += 1;
                //if (stop >= 600)
                //{ 
                //    Exit();
                //}
            }



                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            if (screen == Screen.Intro) 
            {
                _spriteBatch.Draw(introTexture, window, Color.White);
                _spriteBatch.DrawString(textFont, ("Back To The Future-The Game\n\n Maxym F. \n\n Click To Continue"), new Vector2(20, 20), Color.Red);

                introOutroInstance.Play();
                
            }

            if (screen == Screen.Start) 
            {
                introOutroInstance.Stop();

                _spriteBatch.Draw(mallTexture, window, Color.White);
                _spriteBatch.DrawString(textFont, ("Click To Go Back In Time!"), new Vector2 (20, 20), Color.Red);

                _spriteBatch.Draw(delorianTexture, delorianRect, Color.White);

                gameSoundInstance.Play();
            }

            if (screen == Screen.Travel)
            {
                
                gameSoundInstance.Stop();
                
                _spriteBatch.Draw(travelTexture, travelRect, Color.White);
              
                if (travelRect.X == -1600) 
                {
                    travelRect.X = travelRect2.Right;
                }

                if (travelRect2.X == -1600)
                {
                    travelRect2.X = travelRect.Right;
                }

                    _spriteBatch.Draw(travelTexture, travelRect, Color.White);
                _spriteBatch.Draw(travelTexture, travelRect2, Color.White);
                

                _spriteBatch.Draw(sideDelorianTexture, sideDelorianRect, Color.White);
                
                _spriteBatch.DrawString(textFont, (""), new Vector2(20, 20), Color.Red);
                
                introOutroInstance.Play();
            }

            if (screen == Screen.Outro) 
            {

                introOutroInstance.Stop();

                _spriteBatch.Draw(hillValleyTexture, window, Color.White);
                _spriteBatch.DrawString(textFont, ("Oh my God, Doc-Im in 1955! \n\n Click To Go Back Home"), new Vector2(20, 20), Color.Red);

                _spriteBatch.Draw(delorianWingsTexture, delorianWingRect, Color.White);
                _spriteBatch.Draw(martyTexture, martyRect, Color.White);

                jbGoodeInstance.Play();
            }

            if (screen == Screen.Done) 
            {
                jbGoodeInstance.Stop();

                _spriteBatch.Draw(mallTexture, window, Color.White);
                _spriteBatch.Draw(sideDelorianTexture, sideDelorianRect, Color.White);

                _spriteBatch.DrawString(textFont, ("The End"), new Vector2(20, 20), Color.Red);

                backInTimeInstance.Play();
            }

            _spriteBatch.End();
           
            base.Draw(gameTime);
        }
    }
}
