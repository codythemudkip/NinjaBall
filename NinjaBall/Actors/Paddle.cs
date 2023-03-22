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
    public class Paddle : SpriteActor
    {
        private int skin = 0;

        public Paddle(Texture2D texture) 
            : base(texture)
        {
            speed = 5f;
            set_skin(skin);
        }

        public override void Update(GameTime gameTime, List<SpriteActor> sprites)
        {
            set_skin(skin);
            if (input == null)
                throw new Exception("Please give a value to 'Input' ");

            if (Keyboard.GetState().IsKeyDown(input.up)) { velocity.Y = -speed; }
            else if (Keyboard.GetState().IsKeyDown(input.down)) { velocity.Y = speed; }

            position += velocity;

            position.Y = MathHelper.Clamp(position.Y, 0, Game1.screenHeight - texture.Height);

            velocity = Vector2.Zero;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public void set_skin(int skin)
        { 
            if (this.skin == skin) return;
            this.skin = skin;
            destinationRect = new Rectangle(skin * 16, 0, 16, 64);
        }
    }
}
