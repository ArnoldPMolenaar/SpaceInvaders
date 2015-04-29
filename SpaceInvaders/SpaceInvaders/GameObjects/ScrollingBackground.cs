using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.GameObjects
{
    class ScrollingBackground
    {
        private Texture2D _texture;
        private int _screenWidth;
        private int _screenHeight;
        private Vector2 _screenPosition, _origin, _textureResize;

        public ScrollingBackground(int screenWidth, int screenHeight, Texture2D texture)
        {
            _texture = texture;
            _screenHeight = screenHeight;
            _screenWidth = screenWidth;

            _origin = new Vector2(_texture.Width / 2, 0);
            _screenPosition = new Vector2(_screenWidth / 2, _screenHeight / 2);
            _textureResize = new Vector2(0, _texture.Height);
        }

        public void Update(float DeltaY)
        {
            _screenPosition.Y += DeltaY;
            _screenPosition.Y = _screenPosition.Y % _texture.Height;
        }

        public void Draw()
        {
            if (_screenPosition.Y < _screenHeight)
                Game1.SpriteBatch.Draw(_texture, _screenPosition, null, Color.White, 0, _origin, 1, SpriteEffects.None, 0f);

            Game1.SpriteBatch.Draw(_texture, _screenPosition - _textureResize, null, Color.White, 0 ,_origin, 1, SpriteEffects.None, 0f);
        }
    }
}
