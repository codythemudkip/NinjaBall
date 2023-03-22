using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaBall
{
    public class Score
    {
        public int score;

        private SpriteFont _font;

        public Score(SpriteFont font)
        {
            _font = font;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var _scoreText = "Score: " + score.ToString();
            spriteBatch.DrawString(_font, _scoreText, new Vector2(320, 70), Color.Red);
        }
    }
}
