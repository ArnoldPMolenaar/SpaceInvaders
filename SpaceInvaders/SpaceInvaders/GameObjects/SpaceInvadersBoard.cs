using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.GameObjects.SpaceInvaderObjects;
using Microsoft.Xna.Framework;
using SpaceInvaders.General;
using Microsoft.Xna.Framework.Audio;

namespace SpaceInvaders.GameObjects
{
    public class SpaceInvadersBoard
    {
        private const int NUMBEROFXINVADERS = 10;
        private const int NUMBEROFYINVADERS = 5;
        private const int SPACEBETWEEN = 10; //the actual space between two Invaders
        private const int MOVENOW = 20; //Every how many seconds you want to move invaders
        private const int STEP = 20; //By how many pixels you want to move it by each time

        private int _count; //Timer
        private bool _isDescending { get; set; }
        private bool _isRight { get; set; }
        private Random _rand;
        public bool GameOver;
        public List<SpaceInvaderObject> SpaceInvaderList;

        public SpaceInvadersBoard()
        {
            _isRight = true;
            _rand = new Random();
            GameOver = false;
            SpaceInvaderList = new List<SpaceInvaderObject>();
        }

        public void Initialize(Game game)
        {
            for (int x = 0; x < NUMBEROFXINVADERS; x++ )
            {
                for (int y = 0; y < NUMBEROFYINVADERS; y++)
                {
                    if (_rand.NextDouble() >= 0.5)
                    {
                        if (y % 2 == 0)
                            SpaceInvaderList.Add(new SpaceInvader1(game, new Vector2(x * (AssetsManager.SpaceInvaderTexture.Width + SPACEBETWEEN), y * (AssetsManager.SpaceInvaderTexture.Height + SPACEBETWEEN)), Color.White, true));
                        else
                            SpaceInvaderList.Add(new SpaceInvader2(game, new Vector2(x * (AssetsManager.SpaceInvader2Texture.Width + SPACEBETWEEN), y * (AssetsManager.SpaceInvader2Texture.Height + SPACEBETWEEN)), Color.White, true));
                    }
                    else
                    {
                        if (y % 2 == 0)
                            SpaceInvaderList.Add(new SpaceInvader1(game, new Vector2(x * (AssetsManager.SpaceInvaderTexture.Width + SPACEBETWEEN), y * (AssetsManager.SpaceInvaderTexture.Height + SPACEBETWEEN)), Color.White, false));
                        else
                            SpaceInvaderList.Add(new SpaceInvader2(game, new Vector2(x * (AssetsManager.SpaceInvader2Texture.Width + SPACEBETWEEN), y * (AssetsManager.SpaceInvader2Texture.Height + SPACEBETWEEN)), Color.White, false));
                    }
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            if (_count % MOVENOW == 0)
            {
                if (!_isDescending)
                {
                    foreach (SpaceInvaderObject SpaceInvader in SpaceInvaderList)
                    {
                        if (_isRight)
                            SpaceInvader.Position = new Vector2(SpaceInvader.Position.X + STEP, SpaceInvader.Position.Y);
                        else
                            SpaceInvader.Position = new Vector2(SpaceInvader.Position.X - STEP, SpaceInvader.Position.Y);

                        SpaceInvader.HitLeft = SpaceInvader.Position.X <= 0;
                        SpaceInvader.HitRight = SpaceInvader.Bounds.Right >= Game1.ScreenWidth;

                        if (SpaceInvader.HitLeft || SpaceInvader.HitRight)
                        {
                            _isDescending = true;
                        }
                    }
                }
                else
                {
                    AssetsManager.InvaderMoveSoundEffect.Play();
                    _isDescending = false;
                    foreach (SpaceInvaderObject SpaceInvader in SpaceInvaderList)
                    {
                        SpaceInvader.Position = new Vector2(SpaceInvader.Position.X, SpaceInvader.Position.Y + STEP);
                    }
                    _isRight = !_isRight;
                }
            }
            _count++;

            //collision detection
            for (int i = 0; i < SpaceInvaderList.Count; i++)
            {
                if (SpaceInvaderList[i].Hit || SpaceInvaderList[i].GameOver)
                    SpaceInvaderList.RemoveAt(i);
            }

            //SpaceInvaders Shooting
            foreach (SpaceInvaderObject SpaceInvader in SpaceInvaderList)
            {
                if (SpaceInvader.HasWeapon)
                {
                    if (Enumerable.Range((int)SpaceInvader.Position.X - 5, (int)SpaceInvader.Position.Y + 5).Contains((int)SpaceInvader.ShipPosition))
                    {
                        SpaceInvader.InvaderWeapon.Shoot();
                    }
                }

                if (GameOver)
                    SpaceInvader.GameOver = true;
            }
        }
    }
}
