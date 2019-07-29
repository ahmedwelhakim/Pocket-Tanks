﻿using Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Game
{
    public class GamePanel : Panel
    {
        Player player;
        Timer gameTimer;
        public GamePanel()
        {
            
            this.DoubleBuffered = true;
            this.Dock = DockStyle.Fill;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseUp);
        }
        private void GameForm_MouseDown(object sender, MouseEventArgs e)
        {
            MouseManager.X = Cursor.Position.X;
            MouseManager.Y = Cursor.Position.Y;
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
            gameTimer.Interval = 20;
            gameTimer.Tick += GameTimer_Tick;
            player = new Player(50, this.Height - Player.Height_Player,this);
            player.Start_Turn();
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
            player.Update();
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
