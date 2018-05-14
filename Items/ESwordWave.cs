using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrarianThroneMod.Items
{
    public class ESwordWave : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ESwordWave");
        }
        public override void SetDefaults()
        {
            projectile.width = 96;
            projectile.height = 94;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
            projectile.light = 1f;
            projectile.ignoreWater = false;
            projectile.tileCollide = false;
            projectile.extraUpdates = 1;
            projectile.alpha = 255;
            aiType = ProjectileID.Bullet;
            Main.projFrames[projectile.type] = 3;
        }



        public override void AI()
        {

            projectile.velocity *= 0.84f;  // reduce speed by 5%
            if (projectile.velocity.Length() < 0.01f) // if speed is less than 0.01f, kille the projectile
            {
                projectile.Kill();
            }

            projectile.frameCounter++; //Increases the counter for the frames
            if (projectile.frameCounter >= 15) //Detects if the counter is a certain number, since it is 6, it'll change a frame every 6 frames, the higher the number the longer it takes for frames to change
            {
                projectile.frameCounter = 0; //Set the frame counter back to 0
                projectile.frame = (projectile.frame + 1) % 3; //Sets the frame, note that the number (in this case 16) HAS To be the amount of frames the projectile has, or you'll get invisible frames
            }

        }
    }
}