using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceInvaders.GameObjects.ShipWeapon.Upgrades;

namespace SpaceInvaders.GameObjects.ShipWeapon
{
    public class Upgrade
    {
        private const int SPAWNTIME = 1000; //Each SPAWNTIME a upgrade will show and move down
        private Vector2 _position;
        private Random _rand;
        private Game _game;
        private int _count;
        private int _randNumb;

        public bool GameOver;
        public List<LaserWeaponUpgrade> LaserUpgrades = new List<LaserWeaponUpgrade>();
        public List<RocketWeaponUpgrade> RocketUpgrades = new List<RocketWeaponUpgrade>();

        public Upgrade(Game game, Vector2 position)
        {
            _game = game;
            _position = position;
            _rand = new Random();
            GameOver = false;
        }

        public void Update(GameTime gameTime)
        {
            if(_count % SPAWNTIME == 0)
            {
                _randNumb = _rand.Next(100, (Game1.ScreenWidth - 100));

                if (_rand.NextDouble() >= 0.5)
                {
                    LaserUpgrades.Add(new LaserWeaponUpgrade(_game, new Vector2(_randNumb, _position.Y)));
                }
                else
                {
                    RocketUpgrades.Add(new RocketWeaponUpgrade(_game, new Vector2(_randNumb, _position.Y)));
                }
            }

            _count++;

            foreach (LaserWeaponUpgrade LaserUpgrade in LaserUpgrades)
            {
                if (GameOver)
                    LaserUpgrade.DisposeFromList();
            }

            foreach (RocketWeaponUpgrade RocketUpgrade in RocketUpgrades)
            {
                if (GameOver)
                    RocketUpgrade.DisposeFromList();
            }
        }
    }
}
