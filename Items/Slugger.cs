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
