using Microsoft.Xna.Framework;
using SpaceInvaders.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.GameObjects.SpaceInvaderObjects
{
    public class SpaceInvaderObject : GameObject
    {
        public enum TDictonary { Left, Right, Down }; //movements
        public bool HitRight { get; set; }
        public bool HitLeft { get; set; }
        public bool Hit { get; set; }
        public float ShipPosition;
        public bool HasWeapon;
        public bool GameOver;
        public InvaderWeapon InvaderWeapon;

        public SpaceInvaderObject(Game game, Vector2 position, Color color, bool hasWeapon)
            : base(game, position, color)
        {
            Hit = false;
            GameOver = false;
            HasWeapon = hasWeapon;
            if (HasWeapon)
                InvaderWeapon = new InvaderWeapon(game, new Vector2(position.X, position.Y));
        }

        public override void Update(GameTime gameTime)
        {
            if (HasWeapon)
            {
                InvaderWeapon.Update(gameTime);
                InvaderWeapon.Position = Position;
            }

            if (Hit)
                Dispose(true);

            if (GameOver)
                Dispose(true);

            base.Update(gameTime);
        }

        public void UpdateShipPosition(float shipPosition)
        {
            ShipPosition = shipPosition;
        }
    }
}
