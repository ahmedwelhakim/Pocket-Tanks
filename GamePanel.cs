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
        Timer gameTimer;
        double frame_no=1;
        BricksBuilder br_build;
        public GamePanel()
        {
            this.DoubleBuffered = true;
            this.Dock = DockStyle.Fill;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseUp);
        }
        private void GameForm_MouseDown(object sender, MouseEventArgs e)
        {
            MouseManager.X = PointToClient(Cursor.Position).X;
            MouseManager.Y = PointToClient(Cursor.Position).Y;
            MouseManager.setMouseState(e.Button, true);
        }
        private void GameForm_MouseUp(object sender, MouseEventArgs e)
        {
            MouseManager.setMouseState(e.Button, false);
            if (e.Button == MouseButtons.Left)
            {
                MouseManager.is_Left_Btn_Released = true;
            }
        }
        public void StartGame()
        {
            gameTimer = new Timer();
            gameTimer.Interval = 30;
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Start();
            br_build = new BricksBuilder(this,2);
            player = new Player(50, br_build.Beginnig_Y - Player.Height_Player, this);
            player.Start_Turn();
        }
        public void EndGame()
        {
            gameTimer.Stop();
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            updateGame();       
            Invalidate();
        }
        private void updateGame()
        {
            player.Update(frame_no);
            

            if (frame_no + 1 > 10000000000)
            {
                frame_no = 1;
            }
            else
            {
                frame_no++;
            }
        }
        public void DrawGame(Graphics g)
        {
            br_build.draw(g);
            player.Draw(g);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawGame(e.Graphics);
        }
    }
}
