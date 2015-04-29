using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.GameObjects.ShipWeapon.Weapons;
using SpaceInvaders.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.GameObjects.ShipWeapon
{
    public class Weapon
    {
        public WeaponState WeaponState { get; set; }
        public NormalWeapon NormalWeapon { get; set; }
        public RocketWeapon RocketWeapon { get; set; }
        public LaserWeapon LaserWeapon { get; set; }
        private IWeapon _currentWeapon { get; set; }
        public Vector2 Position { get; set; }
        private SpriteFont _font { get; set; }

        public Weapon(Game game, Vector2 position)
        {
            WeaponState = WeaponState.Normal;
            Position = position;

            RocketWeapon = new RocketWeapon(game, Position);
            LaserWeapon = new LaserWeapon(game, Position);
            NormalWeapon = new NormalWeapon(game, Position);
            _currentWeapon = NormalWeapon;
            _font = AssetsManager.Tahoma;
        }

        public void Update(GameTime gameTime)
        {
            switch (WeaponState)
            {
                case WeaponState.Rocket:
                    _currentWeapon = RocketWeapon;
                    RocketWeapon.Position = Position;
                    if (RocketWeapon.Ammo == 0)
                    {
                        WeaponState = WeaponState.Normal;
                        RocketWeapon.Ammo = RocketWeapon.AMMO;
                    }
                    break;
                case WeaponState.Laser:
                    _currentWeapon = LaserWeapon;
                    LaserWeapon.Position = Position;
                    if (LaserWeapon.Ammo == 0)
                    {
                        WeaponState = WeaponState.Normal;
                        LaserWeapon.Ammo = LaserWeapon.AMMO;
                    }
                    break;
                default:
                    _currentWeapon = NormalWeapon;
                    NormalWeapon.Position = Position;
                    break;
            }

            _currentWeapon.Update(gameTime);
        }

        public void Draw()
        {
            Game1.SpriteBatch.DrawString(_font, "Ammo: " + _currentWeapon.GetAmmo(), new Vector2(0, 0), Color.White);
            Game1.SpriteBatch.DrawString(_font, "Weapon: " + _currentWeapon.GetWeapon(), new Vector2((Game1.ScreenWidth / 2) / 2, 0), Color.White);
            _currentWeapon.Draw();
        }

        public void Shoot()
        {
            _currentWeapon.Shoot();
        }
    }
}
