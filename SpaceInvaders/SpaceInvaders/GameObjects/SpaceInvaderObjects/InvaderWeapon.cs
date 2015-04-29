using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.GameObjects.SpaceInvaderObjects
{
    public class InvaderWeapon
    {
        private const int TIMER = 10; //shooting time delay
        private readonly Vector2 PROBABILITY = new Vector2(0, 100); // between 0 and 3 is 25% shooting chance, between 0 and 1 is 50% shooting chance

        private float _timer = 10;
        private bool _shoot;
        private Game _game;
        private Random _rand;
        public Vector2 Position;
        public List<InvaderBullet> Bullets { get; set; }

        public InvaderWeapon(Game game, Vector2 position)
        {
            _game = game;
            Position = position;
            Bullets = new List<InvaderBullet>();
            _shoot = false;
            _rand = new Random();
        }

        public void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _timer -= elapsed;

            if (_timer < 0)
            {
                _shoot = true;
                _timer = TIMER;
            }

            for (int i = 0; i < Bullets.Count; i++)
            {
                if (Bullets[i].Position.Y >= Game1.ScreenHeight || Bullets[i].Hit)
                    Bullets.RemoveAt(i);
            }
        }

        public void Shoot()
        {
            int n;

            if (_shoot)
            {
                n = _rand.Next((int)PROBABILITY.X, (int)PROBABILITY.Y);
                if (n == 0)
                {
                    Bullets.Add(new InvaderBullet(_game, Position));
                    _shoot = false;
                }
            }
        }
    }
}
