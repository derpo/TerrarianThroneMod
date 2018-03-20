using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrarianThroneMod.Items
{
    public class Shelldeath : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shelldeath");
        }
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 34;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.penetrate = 1;
            projectile.timeLeft = 25;
            projectile.light = 0f;
            projectile.ignoreWater = false;
            projectile.tileCollide = false;
            projectile.extraUpdates = 1;
            projectile.alpha = 255;
            aiType = ProjectileID.Bullet;
            Main.projFrames[projectile.type] = 5;
        }



        public override void AI()
        {
            projectile.frameCounter++; //Increases the counter for the frames
            if (projectile.frameCounter >= 6) //Detects if the counter is a certain number, since it is 6, it'll change a frame every 6 frames, the higher the number the longer it takes for frames to change
            {
                projectile.frameCounter = 0; //Set the frame counter back to 0
                projectile.frame = (projectile.frame + 1) % 6; //Sets the frame, note that the number (in this case 16) HAS To be the amount of frames the projectile has, or you'll get invisible frames
            }

        }
    }
}