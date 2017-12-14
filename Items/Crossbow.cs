using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrarianThroneMod.Items
{
    public class Crossbow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crossbow");
            Tooltip.SetDefault("Fires a deadly bolt at high speeds.");
        }
        public override void SetDefaults()
        {
            item.damage = 20;
            item.noMelee = true;
            item.width = 44;
            item.height = 18;
            item.useTime = 60;
            item.useAnimation = 60;
            item.useStyle = 5;
            item.knockBack = 7;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/BoltShot");
            item.autoReuse = false;
            item.useAmmo = mod.ItemType("BoltAmmo");
            item.ranged = true;
            item.shoot = 1;
            item.shootSpeed = 30;
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