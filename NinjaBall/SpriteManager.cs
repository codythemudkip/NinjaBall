using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaBall
{
    public class SpriteManager
    {
        private float _transitionTime;

        public int Index { get; set; }
        public int[] Sequence { get; set; }
        public int TileX { get; set; }
        public int TileY { get; set; }
        public int Time { get; set; }
        public bool Continuious { get; set; }
        public Texture2D Texture { get; set; }

        public Point TileSize { get; set; }

        public SpriteManager() { }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Draw(spriteBatch, Color.White);
        }

        private Point GetMaxFrames(int width, int height)
        {
            return new Point(width/TileX, width/TileY);
        }
    }
}
