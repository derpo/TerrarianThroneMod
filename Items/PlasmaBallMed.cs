using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrarianThroneMod.Items
{
    public class PlasmaBallMed : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("PlasmaBallMedium");
        }
        public override void SetDefaults()
        {
            projectile.width = 15;
            projectile.height = 28;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 600;
            projectile.light = 1f;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.extraUpdates = 1;
            projectile.alpha = 255;
            aiType = ProjectileID.Bullet;
        }

        public override void AI()
        {
            if (Main.rand.Next(2) == 0)
            {
                int dustnumber = Dust.NewDust(projectile.position, projectile.width, projectile.height, 74, 0f, 0f, 200, default(Color), 0.8f);
                Main.dust[dustnumber].velocity *= 0.3f;
            }
        }


        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Player owner = Main.player[projectile.owner];
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, mod.ProjectileType("PlasmaExplosion"), 50, 10, Main.myPlayer);

            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = -oldVelocity.X / 0;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = -oldVelocity.Y / 0;
            }

            Main.PlaySound(2, (int)projectile.Center.X, (int)projectile.Center.Y, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/PlasmaHit"));
            //Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);

            return false;
        }

        public override void Kill(int timeLeft)
         {
            Main.PlaySound(2, (int)projectile.Center.X, (int)projectile.Center.Y, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/PlasmaHit"));
            Player owner = Main.player[projectile.owner];
         Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, mod.ProjectileType("PlasmaBallSmall"), 20, 7, Main.myPlayer);

         }
    }
}