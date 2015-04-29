using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceInvaders.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.GameObjects.ShipWeapon.Weapons
{
    public class NormalWeapon : WeaponObject
    {
        private const int SHOOTINGDELAY = 100; //amount of seconds one shot cane be fired
        public List<NormalBullet> Bullets = new List<NormalBullet>();

        public NormalWeapon(Game game, Vector2 position) 
            : base(game, position)
        {
            texture = AssetsManager.NormalWeaponTexture;
            AmmoText = "Infinity";
            WeaponText = "Gun";
        }

        public override void Update(GameTime gameTime)
        {
            if (count % SHOOTINGDELAY == 0)
                shoot = true;

            count++;

            //collision detection
            for(int i = 0; i < Bullets.Count; i++)
            {
                if(Bullets[i].Hit || Bullets[i].Position.Y <= 0)
                    Bullets.RemoveAt(i);
            }

            base.Update(gameTime);
        }

        public override void Shoot()
        {
            if (shoot)
            {
                Bullets.Add(new NormalBullet(Game, Position));
                shoot = false;
            }
        }
    }
}
