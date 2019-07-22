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
        Image fire_img;
        float gravity;
        float speedY;
        float speedX;
        float friction;
        float friction_coef;
     
        public Fire(float x,float y) 
            :base(x,y)
        {
            fire_img = Image.FromFile(@"Sprites\Fire.png");
            base.Height = fire_img.Height;
            base.Width = fire_img.Width;
            gravity = 2;
            friction_coef = -0.3f;
            friction = speedX * friction_coef;
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(fire_img, new PointF(X, Y));
        }
        public void Gravity(GamePanel gp)
        {
            if (Y < gp.Height-fire_img.Height)
            {
                speedY += gravity;
                if(Y+speedY> gp.Height - fire_img.Height)
                {
                    Y = gp.Height - fire_img.Height;
                }
            }
            if (Y >= gp.Height - fire_img.Height)
            {
                speedY = 0;
                speedX += friction;
                friction = speedX * friction_coef;
            }
        }
        public void Move()
        {
            X += speedX;
            Y += speedY;
        }

        /// <summary>
        /// This method take the angle in degree and the power to shoot the fire
        /// </summary>
        /// <param name="angle">Angle in degree</param>
        /// <param name="power">Power ranging from 0 to 100</param>
        public void ShootFire(int angle,Power power)
        {
            float speedMagnitude = power.getSpeedMagnitude();
            double rad_angle = angle * (Math.PI / 180.0);
            speedY = (float)(-speedMagnitude * Math.Sin(rad_angle));
            speedX = (float)(speedMagnitude * Math.Cos(rad_angle));
        }
    }
    class Power
    {
        protected double Power_Val { get; set; }
        private const float speed_val=40;
        public Power(double pow)
        {
            if (pow > 100)
            {
                this.Power_Val = 100;
            }
            else if (pow < 0)
            {
                this.Power_Val = 0;
            }
            else
            {
                this.Power_Val = pow;
            }
        }
        public float getSpeedMagnitude()
        {
            return (float)((Power_Val / 100) * speed_val);
        }
    }
}
