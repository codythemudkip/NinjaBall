using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaBall.Actors
{
    public class Ball : SpriteActor
    {
        private float _timer = 0f; // Incrementing speed over time
        private Vector2? _startPosition = null;
        private float? _startSpeed;
        private bool _isPlaying;

        public Score score;
        public int speedIncrementSpan = 10; // how often speed increments

        public Ball(Texture2D texture)
            : base(texture)
        {
            speed = 3f;
        }

        public override void Update(GameTime gameTime, List<SpriteActor> sprites)
        {
            if (_startPosition == null)
            {
                _startPosition = position;
                _startSpeed = speed;

                Restart();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space)) { _isPlaying = true; }

            if (!_isPlaying) { return; }

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > speedIncrementSpan)
            {
                speed++;
                _timer = 0;
            }

            foreach (var sprite in sprites)
            {
                if (sprite == this) { continue; }

                if (this.velocity.X > 0 && this.IsTouchingLeft(sprite)) { this.velocity.X = -this.velocity.X; }
                if (this.velocity.X < 0 && this.IsTouchingRight(sprite)) { this.velocity.X = -this.velocity.X; }
                if (this.velocity.Y > 0 && this.IsTouchingTop(sprite)) { this.velocity.Y = -this.velocity.Y; }
                if (this.velocity.Y < 0 && this.IsTouchingBottom(sprite)) { this.velocity.Y = -this.velocity.Y; }
            }

            if (position.Y <= 0 || position.Y + texture.Height >= Game1.screenHeight)
                velocity.Y = -velocity.Y;

            if (position.X <= 0)
            {
                score.score++;
                Restart();
            }

            if (position.X > Game1.screenWidth)
            {
                score.score++;
                RandomDirection();
                //Restart();
            }

            position += velocity * speed;
        }

        public void RandomDirection()
        {
            var direction = Game1.random.Next(0, 4);

            switch (direction)
            {
                case 0:
                    velocity = new Vector2(-0.5f, 0.5f);
                    break;
                case 1:
                    velocity = new Vector2(-0.5f, -1);
                    break;
                case 2:
                    velocity = new Vector2(-1, -1);
                    break;
                case 3:
                    velocity = new Vector2(-1, 0.5f);
                    break;
            }
        }

        public void Restart()
        {
            RandomDirection();

            position = (Vector2)_startPosition;
            speed = (float)_startSpeed;
            _timer = 0;
            _isPlaying = false;
        }
    }
}
