using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SpaceInvaders.General;
using SpaceInvaders.GameObjects.ShipWeapon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceInvaders.GameObjects
{
    public class Ship : GameObject
    {
        private const float SPEED = 2;
        private const int LIVES = 5;

        private SpriteFont _font;
        public Weapon Weapon;
        public float ShipPosition;
        public int Lives;
        public bool GameOver;

        public Ship(Game game, Vector2 position, Color color)
            : base(game, position, color)
        {
            Texture = AssetsManager.ShipTexture;
            _font = AssetsManager.Tahoma;
            Weapon = new Weapon(game, Position);
            Lives = LIVES;
            GameOver = false;
        }

        public override void Update(GameTime gameTime)
        {
            ShipPosition = Position.X + (Texture.Width / 2);
            Weapon.Position = Position;
            Weapon.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if(Bounds.Right <= Game1.ScreenWidth)
                    Position = new Vector2(Position.X + SPEED, Position.Y);
                else
                    Position = new Vector2(Position.X, Position.Y);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if (Position.X >= 0)
                    Position = new Vector2(Position.X - SPEED, Position.Y);
                else
                    Position = new Vector2(Position.X, Position.Y);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Weapon.Shoot();
            }

            if (GameOver)
                Dispose(true);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Game1.SpriteBatch.DrawString(_font, "Lives: " + Lives.ToString(), new Vector2(Game1.ScreenWidth / 2, 0), Color.White);
            Weapon.Draw();
            base.Draw(gameTime);
        }
    }
}
