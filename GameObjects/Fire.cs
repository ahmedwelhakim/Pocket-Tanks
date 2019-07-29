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
        public double Fire_Radius { get; }
     
        public Fire(float x,float y) 
            :base(x,y)
        {
            fire_img = Image.FromFile(@"Sprites\Fire.png");
            base.Height = fire_img.Height;
            base.Width = fire_img.Width;
            gravity = 2;
            //friction_coef = -0.3f;
            //friction = speedX * friction_coef;
            Fire_Radius = fire_img.Width / 2;
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(fire_img, new PointF(X, Y));
        }
        private void Gravity(GamePanel gp)
        {
            if (Y <= gp.Height-fire_img.Height)
            {
                speedY += gravity;
                if(Y+speedY> gp.Height - fire_img.Height)
                {
                    Y = gp.Height - fire_img.Height;
                }
            }
            if (Y > gp.Height - fire_img.Height)
            {
                speedY = 0;
                speedX = 0;
                Y = gp.Height - fire_img.Height;
               // friction = speedX * friction_coef;
            }
        }
        private void Move()
        {
            X += speedX;
            Y += speedY;
        }
        
        public void Update(GamePanel gp)
        {
            this.Move();
            this.Gravity(gp);
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

        public override string ToString()
        {
            return ("SpeedX= "+ speedX + " ----- SpeedY= "+ speedY + "\n" +
                "BallX: "+ X + "  ----- BallY: "+ Y );

        }
        public bool isColliding(Player p)
        {
            return (((this.Y-p.Y)<=p.Height )&& ((this.X - p.X) <= p.Width));
        }
    }
    class Power
    {
        protected double Power_Val { get; }
        private const float speed_val=50;
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
        public double getPower_Val()
        {
            return Power_Val;
        }
        public override string ToString()
        {
            return (""+Power_Val);
        }
    }
}
