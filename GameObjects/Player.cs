using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Game.GameObjects
{
    class Player : GameObject
    {
        static Image player_img = Image.FromFile(@"Sprites\Player.png");
        public static float Width_Player=player_img.Width;
        public static float Height_Player = player_img.Height;
        public Player(float x,float y)
            :base(x,y)
        {
            
            base.Height = player_img.Height;
            base.Width = player_img.Width;
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(player_img,new PointF(X,Y));
        }
    }
}
