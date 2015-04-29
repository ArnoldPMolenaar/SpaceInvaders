#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using SpaceInvaders.General;
using SpaceInvaders.GameObjects;
using SpaceInvaders.GameObjects.ShipWeapon;
using SpaceInvaders.GameObjects.ShipWeapon.Upgrades;
using SpaceInvaders.GameObjects.ShipWeapon.Weapons;
using SpaceInvaders.GameObjects.SpaceInvaderObjects;
#endregion

namespace SpaceInvaders
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public static SpriteBatch SpriteBatch;
        public static int ScreenWidth;
        public static int ScreenHeight;
        private ScrollingBackground _scrollingBackground;
        private SpaceInvadersBoard _spaceInvadersBoard;
        private Ship _ship;
        private Upgrade _upgrade;
        private bool _gameOver;
        private bool _playGameOver;
        private bool _playYouWin;
        private bool _play;
        private SpriteFont _font;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 1270;
            graphics.PreferredBackBufferHeight = 600;

            //Changes the settings that you just applied
            graphics.ApplyChanges();
            ScreenWidth = this.graphics.PreferredBackBufferWidth;
            ScreenHeight = this.graphics.PreferredBackBufferHeight;

            // Additional code to reposition the game window
            Type type = typeof(OpenTKGameWindow);
            System.Reflection.FieldInfo field = type.GetField("window", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            (field.GetValue(Window) as OpenTK.GameWindow).X = 0;
            (field.GetValue(Window) as OpenTK.GameWindow).Y = 0;
        }

        protected override void Initialize()
        {
            AssetsManager.LoadContent(this);
            _scrollingBackground = new ScrollingBackground(ScreenWidth, ScreenHeight, AssetsManager.StarfieldBackground);
            _spaceInvadersBoard = new SpaceInvadersBoard();
            _spaceInvadersBoard.Initialize(this);
            _ship = new Ship(this, new Vector2((ScreenWidth / 2) + (AssetsManager.ShipTexture.Width / 2), ScreenHeight - 100), Color.White);
            _upgrade = new Upgrade(this, new Vector2(0, 0));
            _gameOver = false;
            _playGameOver = false;
            _playYouWin = false;
            _play = true;
            _font = AssetsManager.Tahoma;
            AssetsManager.StartGame.Play();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _scrollingBackground.Update(elapsed * 100);

            if(_gameOver && !_playGameOver)
            {
                _upgrade.GameOver = true;
                _ship.GameOver = true;
                _spaceInvadersBoard.GameOver = true;
                _playGameOver = true;
            }

            if (_playGameOver && _play)
            {
                AssetsManager.GameOver.Play();
                _playGameOver = false;
                _play = false;
            }
            else if (_playYouWin && _play)
            {
                AssetsManager.YouWin.Play();
                _playYouWin = false;
                _play = false;
            }

            if (_spaceInvadersBoard.SpaceInvaderList.Count <= 0)
                _playYouWin = true;

            _spaceInvadersBoard.Update(gameTime);
            _ship.Update(gameTime);
            _upgrade.Update(gameTime);

            foreach(SpaceInvaderObject SpaceInvader in _spaceInvadersBoard.SpaceInvaderList)
            {
                SpaceInvader.UpdateShipPosition(_ship.ShipPosition);

                //Invader hits ship
                if(SpaceInvader.HasWeapon)
                {
                    foreach (InvaderBullet Bullet in SpaceInvader.InvaderWeapon.Bullets)
                    {
                        if (CheckCollision(Bullet, _ship))
                        {
                            Bullet.Hit = true;
                            _ship.Lives--;
                        }
                    }
                }

                //Game Over
                if(CheckCollision(_ship, SpaceInvader) || _ship.Lives <= 0)
                {
                    _gameOver = true;
                }
            }

            for (int i = 0; i < _upgrade.LaserUpgrades.Count; i++)
            {
                if (CheckCollision(_upgrade.LaserUpgrades[i], _ship))
                {
                    _ship.Weapon.WeaponState = WeaponState.Laser;
                    AssetsManager.UpgradeSoundEffect.Play();
                    _upgrade.LaserUpgrades[i].DisposeFromList();
                    _upgrade.LaserUpgrades.RemoveAt(i);
                }
            }

            for (int i = 0; i < _upgrade.RocketUpgrades.Count; i++)
            {
                if (CheckCollision(_upgrade.RocketUpgrades[i], _ship))
                {
                    _ship.Weapon.WeaponState = WeaponState.Rocket;
                    AssetsManager.UpgradeSoundEffect.Play();
                    _upgrade.RocketUpgrades[i].DisposeFromList();
                    _upgrade.RocketUpgrades.RemoveAt(i);
                }
            }

            if (_ship.Weapon.WeaponState == WeaponState.Normal)
            {
                foreach (NormalBullet Bullet in _ship.Weapon.NormalWeapon.Bullets)
                {
                    foreach(SpaceInvaderObject SpaceInvader in _spaceInvadersBoard.SpaceInvaderList)
                    {
                        if (CheckCollision(Bullet, SpaceInvader))
                        {
                            SpaceInvader.Hit = true;
                            Bullet.Hit = true;
                        }
                    }
                }
            }
            else if (_ship.Weapon.WeaponState == WeaponState.Rocket)
            {
                foreach (RocketBullet Bullet in _ship.Weapon.RocketWeapon.Bullets)
                {
                    foreach (SpaceInvaderObject SpaceInvader in _spaceInvadersBoard.SpaceInvaderList)
                    {
                        if (CheckCollision(Bullet, SpaceInvader))
                        {
                            SpaceInvader.Hit = true;
                            Bullet.Hit = true;
                        }
                    }
                }
            }
            else if (_ship.Weapon.WeaponState == WeaponState.Laser)
            {
                foreach (LaserBullet Bullet in _ship.Weapon.LaserWeapon.Bullets)
                {
                    foreach (SpaceInvaderObject SpaceInvader in _spaceInvadersBoard.SpaceInvaderList)
                    {
                        if (CheckCollision(Bullet, SpaceInvader))
                        {
                            SpaceInvader.Hit = true;
                            Bullet.Hit = true;
                        }
                    }
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin();
            _scrollingBackground.Draw();

            if (_gameOver)
                SpriteBatch.DrawString(_font, "!!### Game Over ###!!", new Vector2(ScreenWidth / 3, ScreenHeight / 3), Color.Red, 0f, new Vector2(0, 0), new Vector2(2, 2), SpriteEffects.None, 0f);
            else if (_spaceInvadersBoard.SpaceInvaderList.Count <= 0)
                SpriteBatch.DrawString(_font, "!!### You Win ###!!", new Vector2(ScreenWidth / 3, ScreenHeight / 3), Color.Green, 0f, new Vector2(0, 0), new Vector2(2, 2), SpriteEffects.None, 0f);

            base.Draw(gameTime);
            SpriteBatch.End();
        }

        public bool CheckCollision(GameObject obj1, GameObject obj2)
        {
            if (obj1.Position.X >= obj2.Position.X &&
                obj1.Position.X < obj2.Position.X + obj2.Texture.Width &&
                obj1.Position.Y >= obj2.Position.Y &&
                obj1.Position.Y < obj2.Position.Y + obj2.Texture.Height)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
