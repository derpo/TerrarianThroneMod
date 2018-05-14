using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrarianThroneMod.Items
{
    public class LPistol : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lightning Pistol");
            Tooltip.SetDefault("Lightning yo");
        }
        public override void SetDefaults()
        {
            item.damage = 20;
            item.noMelee = true;
            item.width = 28;
            item.height = 16;
            item.useTime = 60;
            item.useAnimation = 60;
            item.useStyle = 5;
            item.knockBack = 7;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/BoltShot");
            item.autoReuse = false;
            item.useAmmo = mod.ItemType("EnergyAmmo");
            item.ranged = true;
            item.shoot = mod.ProjectileType("OctopusArm");
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