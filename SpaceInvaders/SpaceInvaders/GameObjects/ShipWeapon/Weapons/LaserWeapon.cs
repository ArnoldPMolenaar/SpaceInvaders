using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.GameObjects.ShipWeapon.Weapons
{
    public class LaserWeapon : WeaponObject
    {
        private const int SHOOTINGDELAY = 50; //amount of seconds one shot cane be fired
        public const int AMMO = 5; //Amount of bullets the weapon cane shoot before its out
        public int Ammo;
        public List<LaserBullet> Bullets = new List<LaserBullet>();

        public LaserWeapon(Game game, Vector2 position) 
            : base(game, position)
        {
            texture = AssetsManager.LaserWeaponTexture;
            Ammo = AMMO;
            WeaponText = "Laser";
        }

        public override void Update(GameTime gameTime)
        {
            AmmoText = Ammo.ToString();

            if (count % SHOOTINGDELAY == 0)
                shoot = true;

            count++;

            //collision detection
            for (int i = 0; i < Bullets.Count; i++)
            {
                if (Bullets[i].Hit || Bullets[i].Position.Y <= 0)
                    Bullets.RemoveAt(i);
            }

            base.Update(gameTime);
        }

        public override void Shoot()
        {
            if (shoot)
            {
                Bullets.Add(new LaserBullet(Game, Position));
                Ammo--;
                shoot = false;
            }
        }
    }
}
