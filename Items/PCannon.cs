using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrarianThroneMod.Items
{
    public class PCannon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plasma Cannon");
            Tooltip.SetDefault("'Just wait till you see the SPC...'");
        }
        public override void SetDefaults()
        {
            item.damage = 50;
            item.noMelee = true;
            item.width = 36;
            item.height = 22;
            item.useTime = 75;
            item.useAnimation = 75;
            item.useStyle = 5;
            item.knockBack = 7;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/PCannonShot");
            item.autoReuse = false;
            item.useAmmo = mod.ItemType("EnergyAmmo");
            item.ranged = true;
            item.shoot = mod.ProjectileType("PCannonBallBig");
            item.shootSpeed = 1;
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