using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocketTanks
{
    class player : GameObject
    {
        private static int score = 0; //each tank starts with a score of zero
        private static int moves = 5;  //each tank starts a new game with 5 available moves 
        static Image Player_Image = Image.FromFile(@"resourcesnew\Tank1\Tank1.png");
        public static float Width_Player = Player_Image.Width;
        public static float Height_Player = Player_Image.Height;        

        public player(float x,float y):base(x,y)
        {
            base.Height = Player_Image.Height;
            base.Width = Player_Image.Width;
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
        
        public int get_Remaining_Moves(player p)
        {
            return moves;
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(Player_Image, new PointF(X, Y));
        }
    }
}
