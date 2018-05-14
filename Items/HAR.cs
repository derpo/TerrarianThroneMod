using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrarianThroneMod.Items
{
    public class HAR : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Heavy Assault Rifle");
            Tooltip.SetDefault("Fires a 3-round burst of heavy bullets.");
        }
        public override void SetDefaults()
        {
            item.damage = 35;
            item.noMelee = true;
            item.width = 58;
            item.height = 24;
            item.useTime = 4;
            item.useAnimation = 12;
            item.reuseDelay = 1;
            item.useStyle = 5;
            item.knockBack = 2;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/HARShot");
            item.autoReuse = false;
            item.useAmmo = mod.ItemType("NTBulletAmmo");
            item.ranged = true;
            item.shoot = mod.ProjectileType("HeavyBullet");
            item.shootSpeed = 10;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, 0);
        }
    }
}