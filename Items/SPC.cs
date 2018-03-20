using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrarianThroneMod.Items
{
    public class SPC : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Super Plasma Cannon");
            Tooltip.SetDefault("'Comin' in big.'");
        }
        public override void SetDefaults()
        {
            item.damage = 100;
            item.noMelee = true;
            item.width = 46;
            item.height = 34;
            item.useTime = 180;
            item.useAnimation = 180;
            item.useStyle = 5;
            item.knockBack = 7;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SPCShot");
            item.autoReuse = false;
            item.useAmmo = mod.ItemType("EnergyAmmo");
            item.ranged = true;
            item.shoot = mod.ProjectileType("SPCBallBig");
            item.shootSpeed = 0.2f;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(2, 0);
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