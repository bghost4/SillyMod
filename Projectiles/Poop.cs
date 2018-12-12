using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SillyMod.Projectiles
{
	public class Poop : ModProjectile
	{

    public override void SetDefaults()
        {
            projectile.width = 20;     
            projectile.height = 11;
            projectile.hostile = false;
            projectile.friendly = true;    
            projectile.melee = true;        
            projectile.tileCollide = true; 
            projectile.penetrate = 2;    
            projectile.timeLeft = 200; 
            projectile.light = 0.75f;  
            projectile.extraUpdates = 1;
            projectile.ignoreWater = true; 
            aiType = -1;
        }

		public override void AI() {
			//should set the rotation of the projectile to the velocity vector 
			projectile.rotation = projectile.velocity.ToRotation();
		}


public override bool OnTileCollide(Vector2 oldVelocity)
		{
			//If collide with tile, reduce the penetrate.
			//So the projectile can reflect at most 5 times
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
			else
			{
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
				Main.PlaySound(SoundID.Item10, projectile.position);
			}
			return false;
		}

    }

    

}