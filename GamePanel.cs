using Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    class GamePanel : Panel
    {
        Player player;

        public GamePanel()
        {
            this.DoubleBuffered = true;
            this.Dock = DockStyle.Fill;
            player = new Player(50, 50);
            
        }
        public void DrawGame(Graphics g)
        {
            player.Draw(g);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawGame(e.Graphics);
        }
    }
}
