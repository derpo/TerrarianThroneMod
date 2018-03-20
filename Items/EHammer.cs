using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrarianThroneMod.Items
{
    public class EHammer : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Energy Hammer");
            Tooltip.SetDefault("Deadly");
        }
        public override void SetDefaults()
        {
            item.damage = 70;
            item.noMelee = true;
            item.width = 54;
            item.height = 58;
            item.useTime = 40;
            item.useAnimation = 40;
            item.noUseGraphic = true;
            item.useStyle = 5;
            item.knockBack = 20;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/EHammerSwing");
            item.autoReuse = false;
            item.shoot = mod.ProjectileType("EHammerWave");
            item.shootSpeed = 30;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
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