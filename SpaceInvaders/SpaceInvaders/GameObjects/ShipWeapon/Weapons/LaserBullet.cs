using Microsoft.Xna.Framework;
using SpaceInvaders.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.GameObjects.ShipWeapon.Weapons
{
    public class LaserBullet : GameObject
    {
        private const int SPEED = 4;
        public bool Hit;

        public LaserBullet(Game game, Vector2 position)
            :base(game, position)
        {
            Texture = AssetsManager.LaserBulletTexture;
            Hit = false;
            AssetsManager.LaserSoundEffect.Play();
        }

        public override void Update(GameTime gameTime)
        {
            Position = new Vector2(Position.X, Position.Y - SPEED);

            if (Position.Y <= 0 || Hit)
                Dispose(true);

            base.Update(gameTime);
        }

        public void DisposeFromList()
        {
            Dispose(true);
        }
    }
}
