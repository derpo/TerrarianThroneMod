using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrarianThroneMod.Items
{
    public class HeavyCrossbow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heavy Crossbow");
            Tooltip.SetDefault("Fires an extra powerful heavy bolt.");
        }
        public override void SetDefaults()
        {
            item.damage = 50;
            item.noMelee = true;
            item.width = 48;
            item.height = 22;
            item.useTime = 65;
            item.useAnimation = 65;
            item.useStyle = 5;
            item.knockBack = 10;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/BoltShot");
            item.autoReuse = false;
            item.useAmmo = mod.ItemType("BoltAmmo");
            item.ranged = true;
            item.shoot = mod.ProjectileType("HeavyBolt");
            item.shootSpeed = 30;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, 0);
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