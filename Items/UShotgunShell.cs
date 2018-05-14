using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TerrarianThroneMod.Items
{
    public class UShotgunShell : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("UShotgunShell");
        }
        public override void SetDefaults()
        {
            projectile.width = 14;
            projectile.height = 30;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.hostile = false;
            projectile.ranged = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 1;
            projectile.penetrate = -1;
            projectile.timeLeft = 600;
            projectile.light = 0.5f;
            projectile.ignoreWater = false;
            projectile.tileCollide = true;
            projectile.extraUpdates = 1;
            projectile.alpha = 255;
            aiType = ProjectileID.Bullet;
        }

        public override void AI()
        {
            projectile.velocity *= 0.98f;  // reduce speed by 5%
            if (projectile.velocity.Length() < 0.8f) // if speed is less than 0.01f, kille the projectile
            {
                projectile.Kill();
            }

            projectile.frameCounter++; //Increases the counter for the frames
            if (projectile.frameCounter >= 6) //Detects if the counter is a certain number, since it is 6, it'll change a frame every 6 frames, the higher the number the longer it takes for frames to change
            {
                projectile.frameCounter = 0; //Set the frame counter back to 0
                projectile.frame = (projectile.frame + 1) % 6; //Sets the frame, note that the number (in this case 16) HAS To be the amount of frames the projectile has, or you'll get invisible frames
            }


        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.velocity.X = -oldVelocity.X / 1;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.velocity.Y = -oldVelocity.Y / 1;
            }

            Main.PlaySound(2, -1, -1, mod.GetSoundSlot(SoundType.Item, "Sounds/Item/SlugBounce"));
            //Main.PlaySound(2, (int)projectile.position.X, (int)projectile.position.Y, 10);

            return false;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            //Redraw the projectile with the color not influenced by light
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }

        public override void Kill(int timeLeft)
        {
            Player owner = Main.player[projectile.owner];
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y, mod.ProjectileType("Shelldeath"), 0, 0, Main.myPlayer);

        }
    }
}