using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrarianThroneMod.Items
{
    public class HeavyBolt : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("HeavyBolt");
        }
        public override void SetDefaults()
        {
            projectile.width = 11;
            projectile.height = 1;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.penetrate = 4;
            projectile.timeLeft = 600;
            projectile.light = 0;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.extraUpdates = 1;
            aiType = ProjectileID.Bullet;
        }

        public override void AI()
        {
            projectile.velocity *= 1.01f;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {

            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = -oldVelocity.X / 0;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = -oldVelocity.Y / 0;
            }
            Main.PlaySound(2, (int)projectile.Center.X, (int)projectile.Center.Y, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/BoltHit"));

            return false;
        }
    }
}
