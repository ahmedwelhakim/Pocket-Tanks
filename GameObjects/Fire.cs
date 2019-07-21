using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects
{
    class Fire : GameObject
    {
        Image Fire_img;
        float gravity;
        float gravity_speed;
        bool isGravity;
        public Fire(int x,int y) 
            :base(x,y)
        {
            Fire_img = Image.FromFile(@"Sprites\Fire.png");
            gravity = 4;
            gravity_speed = 0.5F;
            isGravity = true;
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(Fire_img, new PointF(X, Y));
        }
        public void Gravity(GamePanel gp)
        {
            if (Y < gp.Height-Fire_img.Height)
            {
                Y += gravity;
                gravity += gravity_speed;
            }
            else
            {
                isGravity = false;
            }
            if(Y> gp.Height - Fire_img.Height)
            {
                Y = gp.Height - Fire_img.Height;
                isGravity = false;
            }
        }
        public void move()
        {
            if (isGravity)
            {
                X += 10;
                Y -= 10;
            }
        }
    }
}
