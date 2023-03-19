using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NinjaBall.Actors;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NinjaBall
{
    public class Game1 : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch _spriteBatch;

        public static int screenHeight;
        public static int screenWidth;
        public static Random random;

        Score score;
        private List<SpriteActor> _sprites;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Window.Title = "Ninja Ball 5";
            screenHeight = _graphics.PreferredBackBufferHeight;
            screenWidth = _graphics.PreferredBackBufferWidth;
            random= new Random();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var paddleTexture = Content.Load<Texture2D>("sprites/player");
            var ballTexture = Content.Load<Texture2D>("sprites/spr_ball_0");

            score = new Score(Content.Load<SpriteFont>("font"));

            _sprites = new List<SpriteActor>()
            {


                new Paddle(paddleTexture)
                {
                    position = new Vector2(20, (screenHeight / 2) - (paddleTexture.Height / 2)),
                    input = new Input()
                    {
                        up = Keys.Up,
                        down= Keys.Down,
                    }
                },
                new Ball(ballTexture)
                {
                    position = new Vector2((screenWidth / 2) - (ballTexture.Width / 2), (screenHeight / 2) - (ballTexture.Height / 2)),
                    score = score
                }
            };
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (var sprite in _sprites)
            {
                sprite.Update(gameTime, _sprites);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            foreach (var sprite in _sprites) { sprite.Draw(_spriteBatch); }

            score.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}