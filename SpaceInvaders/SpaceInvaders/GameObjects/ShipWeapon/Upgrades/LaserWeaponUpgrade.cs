using Microsoft.Xna.Framework;
using SpaceInvaders.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.GameObjects.ShipWeapon.Upgrades
{
    public class LaserWeaponUpgrade : GameObject
    {
        private const float ROTATIONSPEED = 0.1f;
        private const float MOVEMENTSPEED = 1;

        public LaserWeaponUpgrade(Game game, Vector2 position) 
            : base(game, position)
        {
            Texture = AssetsManager.LaserWeaponUpgradeTexture;
            Rotation = 0.1f;
            Origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
        }

        public override void Update(GameTime gameTime)
        {
            Rotation += ROTATIONSPEED;
            Position = new Vector2(Position.X, Position.Y + MOVEMENTSPEED);

            if (Position.Y >= Game1.ScreenHeight)
                Dispose(true);

            base.Update(gameTime);
        }

        public void DisposeFromList()
        {
            Dispose(true);
        }
    }
}
