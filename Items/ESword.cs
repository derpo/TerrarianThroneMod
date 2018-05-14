using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrarianThroneMod.Items
{
    public class ESword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Energy Sword");
            Tooltip.SetDefault("A sword made of pure radioactive energy");
        }
        public override void SetDefaults()
        {
            item.damage = 60;
            item.noMelee = true;
            item.width = 44;
            item.height = 46;
            item.useTime = 25;
            item.useAnimation = 25;
            item.noUseGraphic = false;
            item.useStyle = 1;
            item.crit += 36;
            item.knockBack = 4;
            item.value = 10000;
            item.rare = 2;
            item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/ESwordSwing");
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("ESwordWave");
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