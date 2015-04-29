using Microsoft.Xna.Framework;
using SpaceInvaders.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.GameObjects.ShipWeapon.Weapons
{
    public class NormalBullet : GameObject
    {
        private const int SPEED = 3;
        public bool Hit;

        public NormalBullet(Game game, Vector2 position)
            : base(game, position)
        {
            Texture = AssetsManager.NormalBulletTexture;
            Hit = false;
            AssetsManager.BulletSoundEffect.Play();
        }

        public override void Update(GameTime gameTime)
        {
            Position = new Vector2(Position.X, Position.Y - SPEED);

            if (Position.Y <= 0 || Hit)
                Dispose(true);

            base.Update(gameTime);
        }
    }
}
