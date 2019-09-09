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
    public enum Mode
    {
        Single, Multi
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
        //Label player_health_lbl;
        //Label opponent_health_lbl;
        Label turn_lbl;
        Fire playerFire;
        Fire opponentFire;
        Brush black_brush;
        Brush green_brush;
        Pen healthBar_pen = new Pen(Color.Black, 3);
        int Player_R;// = (int)(255 *(1- player_health_percent));
        int Player_G;//= (int)(255* (player_health_percent));
        int Opponent_R;//= (int)(255 * (1 - opp_health_percent));
        int Opponent_G;//= (int)(255 * (opp_health_percent));
        double latency = 50;
        Mode mode;
        public bool isGameEnd { get; set; }

        public GamePanel(User user, Mode mode)
        {
            this.DoubleBuffered = true;
            this.Dock = DockStyle.Fill;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GameForm_MouseUp);
            this.User = user;
            this.mode = mode;
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
            black_brush = new SolidBrush(Color.FromArgb(240, 10, 10, 10));
            //black_brush = Brushes.Black;
            green_brush = new SolidBrush(Color.FromArgb(255, 0, 230, 10));
            //green_brush = Brushes.Green;
            healthBar_pen = new Pen(Color.Black, 2.3f);
            turn_lbl = new Label()
            {
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.None,
                Font = new Font(FontFamily.GenericSerif, 20),

            };
            turn_lbl.SizeChanged += Turn_lbl_SizeChanged;
            turn_lbl.Location = new Point(this.Width / 2 - turn_lbl.Width / 2, 30);
            this.Controls.Add(turn_lbl);
            if (User == User.Host)
            {
                player = new Player(50, br_build.Beginnig_Y, this, PlayerType.MyPlayer);
                player.Start_Turn();
                opponent = new Player(this.Width - player.Width - 50, br_build.Beginnig_Y, this, PlayerType.Opponent);
                playerTurn = true;

                opponentFire = opponent.getShootedFire();
                playerFire = player.getShootedFire();
                Player_Health = player.Health;
                Opponent_Health = opponent.Health;
            }

            else if (User == User.Client)
            {
                opponent = new Player(50, br_build.Beginnig_Y, this, PlayerType.Opponent);
                player = new Player(this.Width - opponent.Width - 50, br_build.Beginnig_Y, this, PlayerType.MyPlayer);
                opponent.Start_Turn();

                opponentFire = opponent.getShootedFire();
                playerFire = player.getShootedFire();
            }
        }

        private void Turn_lbl_SizeChanged(object sender, EventArgs e)
        {
            turn_lbl.Left = this.ClientSize.Width / 2 - turn_lbl.Size.Width / 2;
        }

        public void EndGame()
        {         
                isGameEnd = true;
                if (mode == Mode.Single)
                {         
                    gf.Close();
                    introform.Show();
                }
        }
        private void GameTimer_Tick(object sender, EventArgs e)
        {
            updateGame();
            Invalidate();
        }
        private void updateGame()
        {
            try
            {
                Player_Health = player.Health;
                Opponent_Health = opponent.Health;
                player.Update(br_build.Beginnig_Y, frame_no);
                opponent.Update(br_build.Beginnig_Y, frame_no);

                if (opponent.Health <= 0)
                {
                    if (playerFire == null)
                    {
                        gameTimer.Stop();
                        if (MessageBox.Show("YOU WIN!") == DialogResult.OK)
                        {
                            EndGame();
                            isGameEnd = true;
                        }

                    }

                }
                if (player.Health <= 0)
                {
                    if (opponentFire == null)
                    {
                        gameTimer.Stop();
                        if (MessageBox.Show("YOU LOOSE!") == DialogResult.OK)
                        {

                            EndGame();
                            isGameEnd = true;
                        }
                    }
                }
                if (playerTurn)
                {
                    if (player.Health <= 0 || opponent.Health <= 0)
                    {
                        turn_lbl.Text = "Game Ended";
                    }
                    else
                    {
                        turn_lbl.Text = "Your Turn!";
                    }
                }
                else
                {
                    if (player.Health <= 0 || opponent.Health <= 0)
                    {
                        turn_lbl.Text = "Game Ended";
                    }
                    else
                    {
                        turn_lbl.Text = "Opponent Turn";
                    }
                }
                if (player.isTurnFinished())
                {
                    player.End_Turn();
                    opponent.Start_Turn();
                    if (mode == Mode.Single)
                    {
                        float distance = opponent.X - player.X;
                        opponent.angle = Random.Next(107, 168);

                        for (int i = 40; i <= 100; i+=3)
                        {
                            float fire_x = Physics.Range(opponent.angle, new Power(i).getSpeedMagnitude(), opponent);
                            if (i == 100)
                            {
                                opponent.power = new Power(100);
                            }
                            else if (fire_x - player.X - player.Width <= 10)
                            {
                                opponent.power = new Power(i);
                                i = 110;
                            }
                        }
                        opponent.isPowerAngle_Recieved = true;
                    }
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

                //opponent_health_lbl.Text = ("Opponent Health: " + opponent.Health);
                //player_health_lbl.Text = ("Player Health: " + player.Health);

                //updating the fire of every player
                opponentFire = opponent.getShootedFire();
                playerFire = player.getShootedFire();

                //Check collisions of fire with tanks to lower health
                if (playerFire != null && latency >= 50 && playerFire.explosion != null)
                {
                    if (GameObject.checkCollision(opponent, playerFire.explosion))
                    {
                        if(playerFire.getFireType()==FireType.Cutter)
                        {
                            opponent.Health -= 20;
                        }
                        else
                        {
                            opponent.Health -= 10;
                        }
                        if (opponent.Health < 0)
                        {
                            opponent.Health = 0;
                        }
                        latency = 0;
                    }

                }
                if (opponentFire != null && latency >= 50 && opponentFire.explosion != null)
                {
                    if (GameObject.checkCollision(player, opponentFire.explosion))
                    {
                        if (opponentFire.getFireType() == FireType.Cutter)
                        {
                            player.Health -= 20;
                        }
                        else
                        {
                            player.Health -= 10;
                        }
                        if(player.Health<0)
                        {
                            player.Health = 0;
                        }
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
            }

            catch (Exception e)
            {
                Console.WriteLine("GamePanel GameUpdate Exception: " + e.Message);
            }
        }
        public void DrawGame(Graphics g)
        {
            try
            {
                br_build.draw(g);
                DrawHealthBar(g);
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
        private void CalcHealthBarColor()
        {
            if (opponent.Health >= 50)
            {
                Opponent_G = 200;
                Opponent_R = (int)(255 * (1 - (opponent.Health - 50) / 50.0));
            }
            else
            {
                Opponent_G = (int)(255 * Math.Pow((opponent.Health / 50.0), 2.2));
                Opponent_R = 255;
            }

            if (player.Health >= 50)
            {
                Player_G = 200;
                Player_R = (int)(255 * (1 - (player.Health - 50) / 50.0));
            }
            else
            {
                Player_G = (int)(255 * Math.Pow((player.Health / 50.0), 2.2));
                Player_R = 255;
            }

        }
        private void DrawHealthBar(Graphics g)
        {
            CalcHealthBarColor();

            g.FillRectangle(black_brush, new RectangleF(player.X, player.Y - 50, player.Width, 12));
            g.FillRectangle(new SolidBrush(Color.FromArgb(Player_R,Player_G,0)), new RectangleF(player.X, player.Y - 50, player.Width * (player.Health / 100.0F), 12));
            g.DrawRectangle(healthBar_pen, new Rectangle((int)player.X, (int)player.Y - 50, (int)player.Width, 12));

            g.FillRectangle(black_brush, new RectangleF(opponent.X, opponent.Y - 50, opponent.Width, 12));
            g.FillRectangle(new SolidBrush(Color.FromArgb(Opponent_R,Opponent_G,0)), new RectangleF(opponent.X, opponent.Y - 50, opponent.Width * (opponent.Health / 100.0F), 12));
            g.DrawRectangle(healthBar_pen, new Rectangle((int)opponent.X, (int)opponent.Y - 50, (int)opponent.Width, 12));

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
