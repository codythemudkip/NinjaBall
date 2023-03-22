using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaBall.Actors
{
    public class SpriteActor
    {
        protected Texture2D texture;
        public Vector2 position;
        public Vector2 velocity;
        public float speed;
        public Input input;

        public Rectangle sourceRect = new Rectangle();
        public Rectangle destinationRect= new Rectangle();

        public Rectangle rectangle
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, destinationRect.Width, destinationRect.Height);
            }
        }

        public SpriteActor(Texture2D texture)
        {
            this.texture = texture;
            sourceRect = new Rectangle(0,0, texture.Width, texture.Height);
            destinationRect = sourceRect;
        }

        public SpriteActor(Texture2D texture, Rectangle sourceRectangle, Rectangle destinationRectangle)
        {
            this.texture = texture;
            this.sourceRect = sourceRectangle;
            this.destinationRect = destinationRectangle;
        }

        public SpriteActor(Texture2D texture, float x, float y, float speed) 
        { 
            this.texture = texture;
            this.position = new Vector2(x, y);
            
        }

        public SpriteActor() 
        {
            
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, destinationRect, Color.White);
            //spriteBatch.Draw(texture, destinationRect, sourceRect, Color.White);
        }

        public virtual void Update(GameTime gameTime, List<SpriteActor> sprites) { }

        #region Collision
        protected bool IsTouchingLeft(SpriteActor sprite)
        {
            return this.rectangle.Right + this.velocity.X > sprite.rectangle.Left &&
                   this.rectangle.Left < sprite.rectangle.Left &&
                   this.rectangle.Bottom > sprite.rectangle.Top &&
                   this.rectangle.Top < sprite.rectangle.Bottom;
        }

        protected bool IsTouchingRight(SpriteActor sprite)
        {
            return this.rectangle.Left + this.velocity.X < sprite.rectangle.Right &&
              this.rectangle.Right > sprite.rectangle.Right &&
              this.rectangle.Bottom > sprite.rectangle.Top &&
              this.rectangle.Top < sprite.rectangle.Bottom;
        }

        protected bool IsTouchingTop(SpriteActor sprite)
        {
            return this.rectangle.Bottom + this.velocity.Y > sprite.rectangle.Top &&
              this.rectangle.Top < sprite.rectangle.Top &&
              this.rectangle.Right > sprite.rectangle.Left &&
              this.rectangle.Left < sprite.rectangle.Right;
        }

        protected bool IsTouchingBottom(SpriteActor sprite)
        {
            return this.rectangle.Top + this.velocity.Y < sprite.rectangle.Bottom &&
              this.rectangle.Bottom > sprite.rectangle.Bottom &&
              this.rectangle.Right > sprite.rectangle.Left &&
              this.rectangle.Left < sprite.rectangle.Right;
        }

        #endregion
    }
}
