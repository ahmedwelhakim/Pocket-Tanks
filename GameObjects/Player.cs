using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        public GamePanel gp;
        Label lbl = new Label();
        Pen pen;
        Pen dashed_pen;

        private Fire fire;
        protected int angle = 60; //angle of the shooted fire
        protected Power power;//power of shooted fire
        private bool turn = false;//the turn of this player to decide wether to shoot or not
        private bool fired = false;

        public Player(float x, float y, GamePanel gp) : base(x, y)
        {
            base.Height = Player_Image.Height;
            base.Width = Player_Image.Width;
            this.gp = gp;
            pen = new Pen(Color.FromArgb(80, 68, 22), 5);
            dashed_pen = new Pen(Color.SandyBrown, 2.7f);
            dashed_pen.DashStyle = DashStyle.Dot;
        }
        public void Start_Turn()
        {
            turn = true;
            fired = false;
            MouseManager.is_Left_Btn_Released = false;
            fire = new Fire((X + (Width_Player / 2) - 19), Y - 10, FireType.Single_Shot);
            Console.WriteLine("Turn Started");
        }
        public void End_Turn()
        {
            turn = false;
            MouseManager.is_Left_Btn_Released = false;
            fire = null;
            Console.WriteLine("Turn Ended");
            fired = false;
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
                Console.WriteLine("------------------------------------");

                gp.Controls.Remove(lbl);
                turn = false;
            }
        }
        public void Update(float ground_Y, double frame_no)
        {
            if (MouseManager.getMouseState(MouseButtons.Left) && turn)
            {
                gp.Controls.Add(lbl);
                Calc_Angle_Power();
                int power_val = (int)power.getPower_Val();
                lbl.Text = ("Angle: " + angle + "\nPower: " + power_val);
                lbl.AutoSize = true;
                lbl.Font = new Font(FontFamily.GenericMonospace, 15);
                lbl.Location = new Point((int)X, (int)Y - 70);
            }
            Shoot();
            if (fire != null && fired)
            {
                fire.Update(ground_Y, frame_no);
                if (fire.Y - fire.Height > ground_Y)
                {
                    fire.Y = ground_Y - this.Height;
                    fire.Explode(ground_Y - this.Height);
                }




                if (fire.isFinished)
                {
                    fire = null;
                }

            }

        }
        private void Calc_Angle_Power()
        {
            int startX = MouseManager.X;
            int startY = MouseManager.Y;
            int endX = gp.PointToClient(Cursor.Position).X;
            int endY = gp.PointToClient(Cursor.Position).Y;
            int distY = startY - endY;
            int distX = startX - endX;
            double dist_Magn = Math.Sqrt((distX * distX) + (distY * distY));
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

        private void DrawTankPipe(Graphics g)
        {
            const int len = 30;
            double angle_rad = angle * (Math.PI / 180.0);
            float x1 = X + Width_Player / 2;
            float y1 = Y;
            float x2 = x1 + (float)(len * Math.Cos(angle_rad));
            float y2 = y1 - (float)(len * Math.Sin(angle_rad));
            g.DrawLine(pen, new PointF(x1, y1), new PointF(x2, y2));
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(Player_Image, new PointF(X, Y));
            DrawTankPipe(g);
            if (fire != null && fired)
            {
                fire.Draw(g);
            }// Draw Fire 
            if (MouseManager.getMouseState(MouseButtons.Left) && turn)
            {
                int x1 = MouseManager.X;
                int y1 = MouseManager.Y;
                float x2 = gp.PointToClient(Cursor.Position).X;
                float y2 = gp.PointToClient(Cursor.Position).Y;
                g.DrawLine(dashed_pen, new PointF(x1, y1), new PointF(x2, y2));

            } // Draw dotted line when shooting fire

        }
        public String getAngleAndPower()
        {
            return (angle + " " + power.ToString());

        }

    }
}