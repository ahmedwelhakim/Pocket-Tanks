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
    public enum User
    {
        Host, Client
    }
    public class GamePanel : Panel
    {
        public GameForm gf { set; get; }
        public IntroForm introform { set; get; }
        public int Player_Health { get; set; }
        public int Opponent_Health { get; set; }
        public bool playerTurn = false;
        public bool opponentTurn = false;
        Player player;
        Player opponent;
        Timer gameTimer;
        double frame_no = 1;
        BricksBuilder br_build;
        User User;
        Random Random = new Random();
        Label player_health_lbl;
        Label opponent_health_lbl;
        Fire playerFire;
        Fire opponentFire;
        int latency = 50;
        public bool isGameEnd { get; set; }

        public GamePanel(User user)
        {
            this.DoubleBuffered = true;
            this.Dock = DockStyle.Fill;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseUp);
            this.User = user;

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
            br_build = new BricksBuilder(this, 2);
            if (User == User.Host)
            {
                player = new Player(50, br_build.Beginnig_Y - Player.Height_Player, this, PlayerType.MyPlayer);
                player.Start_Turn();
                opponent = new Player(this.Width - 150, br_build.Beginnig_Y - Player.Height_Player, this, PlayerType.Opponent);

                opponent_health_lbl = new Label();
                opponent_health_lbl.Location = new Point(this.Width - 330, 20);
                opponent_health_lbl.Text = ("Opponent Health: " + opponent.Health);
                opponent_health_lbl.AutoSize = true;
                opponent_health_lbl.Font = new Font(FontFamily.GenericMonospace, 15);

                player_health_lbl = new Label();
                player_health_lbl.Location = new Point(60, 20);
                player_health_lbl.Text = ("Player Health: " + player.Health);
                player_health_lbl.AutoSize = true;
                player_health_lbl.Font = new Font(FontFamily.GenericMonospace, 15);

                this.Controls.Add(player_health_lbl);
                this.Controls.Add(opponent_health_lbl);

                opponentFire = opponent.getShootedFire();
                playerFire = player.getShootedFire();
                Player_Health = player.Health;
                Opponent_Health = opponent.Health;
            }

            else if (User == User.Client)
            {
                opponent = new Player(50, br_build.Beginnig_Y - Player.Height_Player, this, PlayerType.Opponent);
                player = new Player(this.Width - 150, br_build.Beginnig_Y - Player.Height_Player, this, PlayerType.MyPlayer);
                opponent.Start_Turn();

                opponent_health_lbl = new Label();
                opponent_health_lbl.Location = new Point(this.Width - 330, 20);
                opponent_health_lbl.Text = ("Opponent Health: " + opponent.Health);
                opponent_health_lbl.AutoSize = true;
                opponent_health_lbl.Font = new Font(FontFamily.GenericMonospace, 15);

                player_health_lbl = new Label();
                player_health_lbl.Location = new Point(60, 20);
                player_health_lbl.Text = ("Player Health: " + player.Health);
                player_health_lbl.AutoSize = true;
                player_health_lbl.Font = new Font(FontFamily.GenericMonospace, 15);

                this.Controls.Add(player_health_lbl);
                this.Controls.Add(opponent_health_lbl);

                opponentFire = opponent.getShootedFire();
                playerFire = player.getShootedFire();
            }
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
            //try
           // {
                Player_Health = player.Health;
                Opponent_Health = opponent.Health;
                player.Update(br_build.Beginnig_Y, frame_no);
                opponent.Update(br_build.Beginnig_Y, frame_no);

                if (opponent.Health <= 0)
                {
                    if (playerFire == null)
                    {
                        EndGame();
                        if (MessageBox.Show("YOU WIN!") == DialogResult.OK)
                        {
                            isGameEnd = true;
                        }            
                    }

                }
                if (player.Health <= 0)
                {
                    if (opponentFire == null)
                    {
                        EndGame();
                        if(MessageBox.Show("YOU LOOSE!")==DialogResult.OK)
                        {
                            isGameEnd = true;
                        }
                    }
                }

                if (player.isTurnFinished())
                {
                    player.End_Turn();
                    opponent.Start_Turn();
                    //opponent.angle = Random.Next(111, 115);
                    //opponent.power = new Power(Random.Next(96, 100));
                    //opponent.angle = 113;
                    //opponent.power = new Power( 100);
                    // opponent.isPowerAngle_Recieved = true;
                    opponentTurn = true;
                    playerTurn = false;
                }
                if (opponent.isTurnFinished())
                {
                    opponent.End_Turn();
                    player.Start_Turn();
                    playerTurn = true;
                    opponentTurn = false;
                }

                opponent_health_lbl.Text = ("Opponent Health: " + opponent.Health);
                player_health_lbl.Text = ("Player Health: " + player.Health);

                //updating the fire of every player
                opponentFire = opponent.getShootedFire();
                playerFire = player.getShootedFire();

                //Check collisions of fire with tanks to lower health
                if (playerFire != null && latency >= 50)
                {
                    if (GameObject.checkCollision(opponent, playerFire))
                    {
                        opponent.Health -= 20;
                        latency = 0;
                    }

                }
                if (opponentFire != null && latency >= 50)
                {
                    if (GameObject.checkCollision(player, opponentFire))
                    {
                        player.Health -= 20;
                        latency = 0;
                    }

                }



                latency++;
                if (frame_no + 1 > 10000000000)
                {
                    frame_no = 1;
                }
                else
                {
                    frame_no++;
                }
           // }

           // catch (Exception e)
          //  {
           //     Console.WriteLine("GamePanel GameUpdate Exception: " + e.Message);
           // }
        }
        public void DrawGame(Graphics g)
        {
            try
            {
                br_build.draw(g);
                player.Draw(g);
                opponent.Draw(g);
                player.DrawFire(g);
                opponent.DrawFire(g);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawGame(e.Graphics);
        }
        public String getPlayerAnglePower()
        {
            if (player != null && player.fired && player.GetAngleAndPower() != null)
            {
                return player.GetAngleAndPower();
            }
            return null;
        }
        public void setOpponentAnglePower(int angle, double power)
        {
            if (opponent != null)
            {
                opponent.angle = angle;
                opponent.power = new Power(power);
                opponent.isPowerAngle_Recieved = true;
            }
        }      
    }

}
