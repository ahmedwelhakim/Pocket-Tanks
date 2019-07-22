using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketTanks
{
    class Tank : GameObject
    {
        private static int score = 0; //each tank starts with a score of zero
        private static int moves = 5;  //each tank starts a new game with 5 available moves 
        static Image Tank_Image = Image.FromFile(@"resourcesnew\Tank1\Tank1.png");
        public static float Width_Tank = Tank_Image.Width;
        public static float Height_Tank = Tank_Image.Height;

        public Tank(float x,float y):base(x,y)
        {
            base.Height = Tank_Image.Height;
            base.Width = Tank_Image.Width;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(Tank_Image, new PointF(X, Y));
        }

        public void Move_Right(Tank t)
        {
            if (moves > 0)
            {
                t.X += 10;
                moves--;
            }
        }

        public void Move_Left(Tank t)
        {
            if (moves > 0)
            {
                t.X -= 10;
                moves--;
            }
        }               
    }
}
