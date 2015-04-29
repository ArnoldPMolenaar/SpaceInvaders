using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.GameObjects.ShipWeapon.Weapons
{
    interface IWeapon
    {
        void Shoot();
        void Draw();
        void Update(GameTime gameTime);
        string GetAmmo();
        string GetWeapon();
    }
}
