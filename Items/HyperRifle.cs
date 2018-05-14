using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrarianThroneMod.Items
{
    public class HyperRifle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hyper Rifle");
            Tooltip.SetDefault("Bullet storm.");
        }
        public override void SetDefaults()
        {
            item.damage =50;
            item.noMelee = true;
            item.width = 62;
            item.height = 30;
            item.useTime = 3;
            item.useAnimation = 16;
            item.reuseDelay = 1;
            item.useStyle = 5;
            item.knockBack = 2;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/HyperRifleShot");
            item.autoReuse = true;
            item.useAmmo = mod.ItemType("NTBulletAmmo");
            item.ranged = true;
            item.shoot = mod.ProjectileType("NTBullet");
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

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(2));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            return true;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, 0);
        }
    }
}