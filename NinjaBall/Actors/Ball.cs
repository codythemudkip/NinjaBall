using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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

                var direction = Game1.random.Next(0, 4);

                switch (direction)
                {
                    case 0:
                        velocity = new Vector2(1, 1);
                        break;
                    case 1:
                        velocity = new Vector2(1, -1);
                        break;
                    case 2:
                        velocity = new Vector2(-1, -1);
                        break;
                    case 3:
                        velocity = new Vector2(1, 1);
                        break;
                }

                position = (Vector2)_startPosition;
                speed = (float)_startSpeed;
                _timer = 0;
                _isPlaying = false;
            }
        }

    }
}
