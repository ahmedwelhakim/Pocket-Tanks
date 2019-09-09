using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Game.GameObjects
{
    class Fire : GameObject
    {
        Image Drawed_img;
        List<Image> imgs;
        float speedY;
        float speedX;
        int img_indx;
        FireType fireType;
        public bool IsCollided { get; set; }
        public bool isFinished = false;
        public Explosion explosion { get; set; }
        //SoundPlayer exp;
        
        
        public double Fire_Radius { get; }
        public Fire(float x, float y, FireType fireType)
            : base(x, y)
        {
            Fire_Img fim = new Fire_Img(fireType);
            imgs = fim.get_fire_imgs();
            Drawed_img = imgs[0];
            base.Height = Drawed_img.Height;
            base.Width = Drawed_img.Width;          
            Fire_Radius = Drawed_img.Width / 2;
            img_indx = 0;
            this.fireType = fireType;
            
           
        }
        public override void Draw(Graphics g)
        {
            if (!IsCollided)
            {
                g.DrawImage(Drawed_img, new PointF(X, Y));
            }
            if (explosion != null && IsCollided)
            {
                
                explosion.Draw(g);
                
               

            }
        }
        private void Gravity(float ground_Y)
        {
            if (Y < ground_Y - Drawed_img.Height)
            {
                speedY += Physics.gravity;
                if (Y + speedY > ground_Y - Drawed_img.Height)
                {
                    Y = ground_Y - this.Height;
                }
            }
            if (Y >= ground_Y - this.Height)
            {
                speedY = 0;
                speedX = 0;
                Y = ground_Y - this.Height;
                Explode(Y);

            }
        }
        public FireType getFireType()
        {
            return fireType;
        }
        private void Move()
        {
            X += speedX;
            Y += speedY;

        }
       
        public void Explode(float y)
        {
            
            


            if (!IsCollided)
            {
                SoundPlayer exp = new SoundPlayer(@"resourcesnew\audio\expmedium2.wav");
                exp.Play();
                if (fireType == FireType.Cutter)
                {
                    explosion = new Explosion(X, y + 10, ExplosionType.nuke);
                }
                else
                {
                    explosion = new Explosion(X, y + 5, ExplosionType.small);
                }

              
            }
            IsCollided = true;
        }

        public void Update(float ground_Y, double frame_no)
        {
            this.Move();
            this.Gravity(ground_Y);
            if (frame_no % 2 == 0)
            {
                if (img_indx < imgs.Count - 1)
                {
                    img_indx++;
                }
                else
                {
                    img_indx = 0;
                }
                Drawed_img = imgs[img_indx];
            }

            if (explosion != null && IsCollided)
            {
                explosion.StartExplosion(frame_no);
                if (explosion.isFinished == true)
                {
                    explosion = null;
                    isFinished = true;
                 
                }
            }
        }
        /// <summary>
        /// This method take the angle in degree and the power to shoot the fire
        /// </summary>
        /// <param name="angle">Angle in degree</param>
        /// <param name="power">Power ranging from 0 to 100</param>
        public void ShootFire(int angle, Power power)
        {
            float speedMagnitude = power.getSpeedMagnitude();
            double rad_angle = angle * (Math.PI / 180.0);
            speedY = (float)(-speedMagnitude * Math.Sin(rad_angle));
            speedX = (float)(speedMagnitude * Math.Cos(rad_angle));
        }

        public override string ToString()
        {
            return ("SpeedX= " + speedX + " ----- SpeedY= " + speedY + "\n" +
                "BallX: " + X + "  ----- BallY: " + Y);

        }
        public bool isColliding(Player p)
        {
            return (((this.Y - p.Y) <= p.Height) && ((this.X - p.X) <= p.Width));
        }
        
       
    }
    public class Power
    {
        protected double Power_Val { get; }
        private const float speed_val = 36;
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
            return ("" + Power_Val);
        }
    }
    enum FireType
    {
        Cutter, Single_Shot
    }
    class Fire_Img
    {
        private List<Image> imgs = new List<Image>();
        public Fire_Img(FireType fireType)
        {
            if (fireType == FireType.Cutter)
            {
                for (int i = 0; i < 4; i++)
                {
                    int n = i + 1;
                    imgs.Add(Image.FromFile(@"resourcesnew/weapons/cutter/cutter" + n + ".png"));
                }
            }
            else if (fireType == FireType.Single_Shot)
            {
                for (int i = 0; i < 3; i++)
                {
                    int n = i + 1;
                    imgs.Add(Image.FromFile(@"resourcesnew/weapons/single_shot/single_shot_" + n + ".png"));
                }
            }
        }
        public List<Image> get_fire_imgs()
        {
            return imgs;
        }
    }


}
