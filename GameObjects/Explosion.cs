using System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects
{
    class Explosion : GameObject
    {
        private Image Explosion_img;
        private Fire bullet;
        private Player p;

        public Explosion(float x,float y,Fire bullet,Player p)
            :base(x,y)
        {
            Explosion_img = Image.FromFile(@"resourcesnew/explosions/nuke_explosion/explosion29.png");
            base.Height = Explosion_img.Height;
            base.Width = Explosion_img.Width;
            this.bullet = bullet;
            this.p = p;
        }

        
        public override void Draw(Graphics g) 
        {
            if(bullet.isColliding(p))
                g.DrawImage(Explosion_img, new PointF(X, Y)); 

        }
        
    }
}
