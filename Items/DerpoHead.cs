﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrarianThroneMod.Items   //We need this to basically indicate the folder where it is to be read from, so you the texture will load correctly
{
    [AutoloadEquip(EquipType.Head)]
    public class DerpoMask : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("'Great for impersonating some internet jackass!'");
        }
        public override void SetDefaults()
        {
            item.width = 22; //The size in width of the sprite in pixels.
            item.height = 28;   //The size in height of the sprite in pixels.
            item.rare = 9;    //The color the title of your item when hovering over it ingame
            item.vanity = true; //this defines if this item is vanity or not.
        }

        public override bool DrawHead()
        {
            return false;     //this make so the player head does not disappear when the vanity mask is equipped.  return false if you want to not show the player head.
        }
        public override void DrawHair(ref bool drawHair, ref bool drawAltHair)
        {
            drawHair = drawAltHair = false;  //this make so the player hair does not show when the vanity mask is equipped.  add true if you want to show the player hair.
        }
    }
}