using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.General
{
    public static class AssetsManager
    {
        public static Texture2D ShipTexture;
        public static Texture2D SpaceInvaderTexture;
        public static Texture2D SpaceInvader2Texture;
        public static Texture2D NormalBulletTexture;
        public static Texture2D NormalWeaponTexture;
        public static Texture2D RocketTexture;
        public static Texture2D RocketWeaponTexture;
        public static Texture2D RocketWeaponUpgradeTexture;
        public static Texture2D LaserBulletTexture;
        public static Texture2D LaserWeaponTexture;
        public static Texture2D LaserWeaponUpgradeTexture;

        public static Texture2D StarfieldBackground;

        public static SpriteFont CourierNew;
        public static SpriteFont Tahoma;

        public static SoundEffect UpgradeSoundEffect;
        public static SoundEffect BulletSoundEffect;
        public static SoundEffect LaserSoundEffect;
        public static SoundEffect RocketSoundEffect;
        public static SoundEffect InvaderShotSoundEffect;
        public static SoundEffect InvaderMoveSoundEffect;
        public static SoundEffect StartGame;
        public static SoundEffect GameOver;
        public static SoundEffect YouWin;

        public static void LoadContent(Game game)
        {
            ShipTexture = game.Content.Load<Texture2D>("Textures/Ship");
            SpaceInvaderTexture = game.Content.Load<Texture2D>("Textures/SpaceInvader");
            SpaceInvader2Texture = game.Content.Load<Texture2D>("Textures/SpaceInvader2");
            NormalBulletTexture = game.Content.Load<Texture2D>("Textures/NormalBullet");
            NormalWeaponTexture = game.Content.Load<Texture2D>("Textures/NormalWeapon");
            RocketTexture = game.Content.Load<Texture2D>("Textures/Rocket");
            RocketWeaponTexture = game.Content.Load<Texture2D>("Textures/RocketWeapon");
            RocketWeaponUpgradeTexture = game.Content.Load<Texture2D>("Textures/RocketWeaponUpgrade");
            LaserBulletTexture = game.Content.Load<Texture2D>("Textures/LaserBullet");
            LaserWeaponTexture = game.Content.Load<Texture2D>("Textures/LaserWeapon");
            LaserWeaponUpgradeTexture = game.Content.Load<Texture2D>("Textures/LaserWeaponUpgrade");

            StarfieldBackground = game.Content.Load<Texture2D>("Textures/Starfield");

            CourierNew = game.Content.Load<SpriteFont>("Fonts/CourierNew");
            Tahoma = game.Content.Load<SpriteFont>("Fonts/Tahoma");

            UpgradeSoundEffect = game.Content.Load<SoundEffect>("Sounds/Upgrade");
            BulletSoundEffect = game.Content.Load<SoundEffect>("Sounds/Bullet");
            LaserSoundEffect = game.Content.Load<SoundEffect>("Sounds/Laser");
            RocketSoundEffect = game.Content.Load<SoundEffect>("Sounds/Rocket");
            InvaderShotSoundEffect = game.Content.Load<SoundEffect>("Sounds/InvaderShot");
            InvaderMoveSoundEffect = game.Content.Load<SoundEffect>("Sounds/InvaderMove");
            StartGame = game.Content.Load<SoundEffect>("Sounds/StartGame");
            GameOver = game.Content.Load<SoundEffect>("Sounds/GameOver");
            YouWin = game.Content.Load<SoundEffect>("Sounds/YouWin");
        }
    }
}
