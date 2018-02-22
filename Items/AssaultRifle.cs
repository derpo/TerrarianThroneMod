using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrarianThroneMod.Items
{
    public class AssaultRifle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Assault Rifle");
            Tooltip.SetDefault("Fires a 3-round burst of bullets.");
        }
        public override void SetDefaults()
        {
            item.damage = 10;
            item.noMelee = true;
            item.width = 52;
            item.height = 22;
            item.useTime = 4;
            item.useAnimation = 12;
            item.reuseDelay = 5;
            item.useStyle = 5;
            item.knockBack = 1;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/AssaultRifleShot");
            item.autoReuse = false;
            item.useAmmo = AmmoID.Bullet;
            item.ranged = true;
            item.shoot = 1;
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