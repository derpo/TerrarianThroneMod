using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrarianThroneMod.Items
{
    public class SuperSlugger : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("SuperSlugger");
            Tooltip.SetDefault("Fires 5 strong, short-ranged slugs in a controlled spread.");
        }
        public override void SetDefaults()
        {
            item.damage = 10;
            item.noMelee = true;
            item.width = 42;
            item.height = 14;
            item.useTime = 60;
            item.useAnimation = 60;
            item.useStyle = 5;
            item.knockBack = 10;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/SluggerShot");
            item.autoReuse = false;
            item.useAmmo = mod.ItemType("SlugAmmo");
            item.ranged = true;
            item.shoot = 1;
            item.shootSpeed = 40;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            int numberProjectiles = 5;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(15)); // 30 degree spread.
                                                                                                                // If you want to randomize the speed to stagger the projectiles
                                                                                                                // float scale = 1f - (Main.rand.NextFloat() * .3f);
                                                                                                                // perturbedSpeed = perturbedSpeed * scale; 
                Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
            }
            return false; // return false because we don't want tmodloader to shoot projectile
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