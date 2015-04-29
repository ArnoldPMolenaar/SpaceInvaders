using Microsoft.Xna.Framework;
using SpaceInvaders.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.GameObjects.SpaceInvaderObjects
{
    public class InvaderBullet : GameObject
    {
        private const int SPEED = 5;
        public bool Hit;

        public InvaderBullet(Game game, Vector2 position) 
            : base(game, position)
        {
            Texture = AssetsManager.NormalBulletTexture;
            Rotation = 3.2f;
            Hit = false;
            AssetsManager.InvaderShotSoundEffect.Play();
        }

        public override void Update(GameTime gameTime)
        {
            Position = new Vector2(Position.X, Position.Y + SPEED);

            if (Position.Y >= Game1.ScreenHeight || Hit)
                Dispose(true);

            base.Update(gameTime);
        }
    }
}
