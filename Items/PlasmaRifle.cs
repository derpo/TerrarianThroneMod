using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrarianThroneMod.Items
{
    public class PlasmaRifle : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plasma Rifle");
            Tooltip.SetDefault("'Fires a ball of pure, explosive plasma.'");
        }
        public override void SetDefaults()
        {
            item.damage = 30;
            item.noMelee = true;
            item.width = 48;
            item.height = 20;
            item.useTime = 13;
            item.useAnimation = 13;
            item.useStyle = 5;
            item.knockBack = 7;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/PlasmaGunShot");
            item.autoReuse = true;
            item.useAmmo = mod.ItemType("EnergyAmmo");
            item.ranged = true;
            item.shoot = mod.ProjectileType("PlasmaBallBig");
            item.shootSpeed = 1;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, 0);
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(4));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            return true;
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