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
        Fire fire;
        Timer gameTimer;
        public GamePanel()
        {
            this.DoubleBuffered = true;
            this.Dock = DockStyle.Fill;
        }
        public void StartGame()
        {
            gameTimer = new Timer();
            gameTimer.Interval = 20;
            gameTimer.Tick += GameTimer_Tick;
            player = new Player(0, this.Height - Player.Height_Player);
            fire = new Fire(100, 260);

            //Adding the angle and power to shoot
            fire.ShootFire(60,new Power(80));
            gameTimer.Start();
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
            fire.Gravity(this);
            fire.Move();  
        }

        public void DrawGame(Graphics g)
        {
            player.Draw(g);
            fire.Draw(g);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawGame(e.Graphics);
        }
    }
}
