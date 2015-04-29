using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.GameObjects.ShipWeapon.Weapons
{
    public class RocketWeapon : WeaponObject
    {
        private const int SHOOTINGDELAY = 100; //amount of seconds one shot cane be fired
        public const int AMMO = 5; //Amount of bullets the weapon cane shoot before its out
        public int Ammo;
        public List<RocketBullet> Bullets = new List<RocketBullet>();

        public RocketWeapon(Game game, Vector2 position) 
            : base(game, position)
        {
            texture = AssetsManager.RocketWeaponTexture;
            Ammo = AMMO;
            WeaponText = "RocketLauncher";
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
                Bullets.Add(new RocketBullet(Game, Position));
                Ammo--;
                shoot = false;
            }
        }
    }
}
