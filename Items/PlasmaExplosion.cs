using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrarianThroneMod.Items
{
    public class PlasmaExplosion : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("PlasmaExplosion");
        }
        public override void SetDefaults()
        {
            projectile.width = 80;
            projectile.height = 80;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.penetrate = 99;
            projectile.timeLeft = 60;
            projectile.light = 0.5f;
            projectile.ignoreWater = false;
            projectile.tileCollide = false;
            projectile.extraUpdates = 1;
            projectile.alpha = 255;
            aiType = ProjectileID.Bullet;
            Main.projFrames[projectile.type] = 7;
        }

        public override void AI()
        {

            projectile.frameCounter++; //Increases the counter for the frames
            if (projectile.frameCounter >= 8) //Detects if the counter is a certain number, since it is 6, it'll change a frame every 6 frames, the higher the number the longer it takes for frames to change
            {
                projectile.frameCounter = 0; //Set the frame counter back to 0
                projectile.frame = (projectile.frame + 1) % 6; //Sets the frame, note that the number (in this case 16) HAS To be the amount of frames the projectile has, or you'll get invisible frames
            }
            if (Main.rand.Next(2) == 0)
            {
                int dustnumber = Dust.NewDust(projectile.position, projectile.width, projectile.height, 74, 0f, 0f, 200, default(Color), 0.8f);
                Main.dust[dustnumber].velocity *= 0.3f;
            }
        }


        public override void Kill(int timeLeft)
        {
            Main.PlaySound(2, (int)projectile.Center.X, (int)projectile.Center.Y, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/PlasmaHit"));
            //Player owner = Main.player[projectile.owner];
            //Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, mod.ProjectileType("PlasmaBallMed"), 20, 7, Main.myPlayer);

        }
    }
}