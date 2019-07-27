using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.GameObjects
{
    class Player : GameObject
    {
        private static int moves = 5;  //each tank starts a new game with 5 available moves 
        static Image Player_Image = Image.FromFile(@"resourcesnew\Tank1\Tank1.png");
        public static float Width_Player = Player_Image.Width;
        public static float Height_Player = Player_Image.Height;
        public  GamePanel gp;
        Label lbl = new Label();

        private Fire fire;
        protected int angle; //angle of the shooted fire
        protected Power power;//power of shooted fire
        private bool turn = false;//the turn of this player to decide wether to shoot or not
        private bool fired = false;
        public Player(float x,float y,GamePanel gp):base(x,y)
        {
            base.Height = Player_Image.Height;
            base.Width = Player_Image.Width;
            this.gp = gp;
            
        }
        public void Start_Turn()
        {
            turn = true;
            MouseManager.is_Left_Btn_Released = false;
            fire = new Fire((X + (Width_Player / 2)), Y+10);
        }
        public void Shoot()
        {
            if (turn && MouseManager.is_Left_Btn_Released && fire != null)
            {
                fire.ShootFire(angle, power);
                fired = true;
                Console.WriteLine("FIRED");
                Console.WriteLine("Angele: {0}     Power: {1}", angle, power);
                MouseManager.is_Left_Btn_Released = false;
                Console.WriteLine(fire);

                gp.Controls.Remove(lbl);
                //  turn = false;
            }
        }
        public void Update()
        {
            if(MouseManager.getMouseState(MouseButtons.Left) && turn)
            {
                gp.Controls.Add(lbl);
                Calc_Angle_Power();
                int power_val = (int)power.getPower_Val();
                lbl.Text = ("Angle: "+angle+"\nPower: "+power_val);
                lbl.AutoSize = true;
                lbl.Font = new Font(FontFamily.GenericMonospace, 15);
                lbl.Location= new Point((int)X,(int)Y-70);
                
                
            }
            Shoot();
            if (fire!=null&& fired)
            {
                fire.Update(gp);
               
            }
        }
        private void Calc_Angle_Power()
        {
            int startX = MouseManager.X;
            int startY = MouseManager.Y;
            int endX = Cursor.Position.X;
            int endY = Cursor.Position.Y;
            int distY = startY - endY;
            int distX = startX - endX;
            double dist_Magn = Math.Sqrt((distX * distX )+ (distY * distY));
            const int Max_Dist = 200;
            double angle_degree = Math.Atan2(-distY, distX) * (180.0 / Math.PI);
            angle = (int)angle_degree;
            power = new Power((dist_Magn / Max_Dist) * 100);
        }
        public void Move_Right(Player p)
        {
            if (moves > 0)
            {
                p.X += 10;
                moves--;
            }
        }
        public void Move_Left(Player p)
        {
            if (moves > 0)
            {
                p.X -= 10;
                moves--;
            }
        }   
        public int get_Remaining_Moves(Player p)
        {
            return moves;
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(Player_Image, new PointF(X, Y));
            if (fire != null &&fired)
            {
                fire.Draw(g);
            }
        }
    }
}
