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
        Image player_img;
        public Player(int x,int y)
            :base(x,y)
        {
            player_img = Image.FromFile(@"Sprites\Player.png");
        }
        public override void Draw(Graphics g)
        {
            g.DrawImage(player_img,new Point(X,Y));
        }
    }
}
