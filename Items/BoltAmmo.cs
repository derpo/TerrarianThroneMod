﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrarianThroneMod.Items
{
    public class BoltAmmo : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bolt");
        }
        public override void SetDefaults()
        {
            item.damage = 15;
            item.ranged = true;
            item.width = 18;
            item.height = 24;
            item.maxStack = 999;
            item.consumable = false;
            item.knockBack = 7;
            item.value = 10000;
            item.rare = 2;
            //item.shoot = mod.ProjectileType("Bolt");
            item.shootSpeed = 5;
            item.ammo = mod.ItemType("BoltAmmo");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}