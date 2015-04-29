using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.General
{
    public abstract class GameObject : DrawableGameComponent
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Color Color { get; set; }
        public float Rotation { get; set; }
        public Vector2 Origin { get; set; }
        public float Scale { get; set; }

        public Rectangle Bounds { get { return new Rectangle((int)Position.X, (int)Position.Y, (int)(Texture.Width * Scale), (int)(Texture.Height * Scale)); } }
        
        public GameObject(Game game, Vector2 position, Color? color = null, float scale = 1)
            : base(game)
        {
            Game.Components.Add(this);
            Position = position;
            Scale = scale;
            Color = color ?? Color.White;
        }

        public override void Initialize()
        {

            base.Initialize();
        }

        public override void Draw(GameTime gameTime)
        {
            Game1.SpriteBatch.Draw(Texture, Position, null, Color, Rotation, Origin, Scale, SpriteEffects.None, 0f);

            base.Draw(gameTime);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Game.Components.Remove(this);
            }

            base.Dispose(disposing);
        }
    }
}
