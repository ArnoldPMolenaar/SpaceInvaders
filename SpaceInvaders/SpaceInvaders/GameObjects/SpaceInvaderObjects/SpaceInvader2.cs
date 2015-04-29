﻿using Microsoft.Xna.Framework;
using SpaceInvaders.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvaders.GameObjects.SpaceInvaderObjects
{
    public class SpaceInvader2 : SpaceInvaderObject
    {
        public SpaceInvader2(Game game, Vector2 position, Color color, bool hasWeapon) 
            : base(game, position, color, hasWeapon)
        {
            Texture = AssetsManager.SpaceInvader2Texture;
        }
    }
}
