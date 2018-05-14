using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrarianThroneMod.Items
{
    public class UPC : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ultra Plasma Cannon");
            Tooltip.SetDefault("World Destroyer");
        }
        public override void SetDefaults()
        {
            item.damage = 1000;
            item.noMelee = true;
            item.width = 68;
            item.height = 38;
            item.useTime = 250;
            item.useAnimation = 250;
            item.useStyle = 5;
            item.knockBack =20;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/UPCShot");
            item.autoReuse = false;
            item.useAmmo = mod.ItemType("EnergyAmmo");
            item.ranged = true;
            item.shoot = mod.ProjectileType("UPCBallBig");
            item.shootSpeed = 0.2f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-10, -2);
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