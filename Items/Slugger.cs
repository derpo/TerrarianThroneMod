using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrarianThroneMod.Items
{
	public class Slugger : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slugger");
			Tooltip.SetDefault("Fires a strong, short-ranged slug.");
		}
		public override void SetDefaults()
		{
			item.damage = 50;
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
            item.shoot = mod.ProjectileType("Slug");
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

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(7));
            speedX = perturbedSpeed.X;
            speedY = perturbedSpeed.Y;
            return true;
        }
    }
}
