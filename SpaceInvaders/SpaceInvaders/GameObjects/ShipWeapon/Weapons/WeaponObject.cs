using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.GameObjects.ShipWeapon.Weapons
{
    public abstract class WeaponObject : DrawableGameComponent, IWeapon
    {
        protected Texture2D texture;
        protected Game game;
        protected bool shoot;
        protected int count;
        public string AmmoText;
        public string WeaponText;
        public Vector2 Position;

        public WeaponObject(Game game, Vector2 position) 
            : base(game)
        {
            Position = position;
            this.game = game;
            shoot = true;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public void Draw()
        {
            Game1.SpriteBatch.Draw(texture, Position, Color.White);
        }

        public abstract void Shoot();

        public string GetAmmo()
        {
            return AmmoText;
        }

        public string GetWeapon()
        {
            return WeaponText;
        }
    }
}
