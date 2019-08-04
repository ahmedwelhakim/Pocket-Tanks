using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.IO;
namespace Game
{
    public partial class GameForm : Form
    {
        private bool read;
        private bool write;
        private bool firstTurn = true;
        private GamePanel gp;
        public Thread t;
        private bool communicating = true;
        private TcpClient communicator;
        public StreamReader sr;
        public StreamWriter sw;
        IntroForm IntroForm;
        String[] powAngle;
        User user;

        public GameForm(IntroForm introform, User user)       //SinglePlayer Constructor
        {
            InitializeComponent();
            this.gp = new GamePanel(user);
            gp.gf = this;
            gp.introform = introform;
            Controls.Add(gp);
            gp.StartGame();
        }
        public GameForm(int myPortNumber, IntroForm introForm)//Host Constructor
        {
            InitializeComponent();
            this.IntroForm = introForm;
            this.gp = new GamePanel(User.Host);
            Controls.Add(gp);
            gp.StartGame();
            user = User.Host;
            initHost_Communication(myPortNumber);
            write = true;
            read = false;
        }
        public GameForm(String hostIP, int hostPortNumber, IntroForm introForm)      //Guest Constructor
        {
            InitializeComponent();
            this.IntroForm = introForm;
            gp = new GamePanel(User.Client);
            Controls.Add(gp);
            gp.StartGame();
            user = User.Client;
            initClient_Communication(hostIP, hostPortNumber);
            write = false;
            read = true;
        }

        private void initHost_Communication(int myPortNumber)
        {
            TcpListener listener = TcpListener.Create(myPortNumber);
            listener.Start();
            communicator = listener.AcceptTcpClient();
            Console.WriteLine("ClientACCEPTED");
            sr = new StreamReader(communicator.GetStream());
            sw = new StreamWriter(communicator.GetStream());
            t = new Thread(communicate);
            t.Start();
            listener.Stop();
        }

        private void initClient_Communication(String hostIP, int hostPortNumber)
        {
            communicator = new TcpClient(hostIP, hostPortNumber);
            sr = new StreamReader(communicator.GetStream());
            sw = new StreamWriter(communicator.GetStream());
            t = new Thread(communicate);
            t.Start();
        }

        private void communicate()
        {
            while (communicating)
            {               
                if (write)
                {
                    if ((gp.getPlayerAnglePower() != null))
                    {
                        Console.WriteLine("writing");
                        sw.WriteLine(gp.getPlayerAnglePower());
                        sw.Flush();
                        read = true;
                        write = false;
                    }
                    else if(gp.isGameEnd )
                    {
                        Console.WriteLine("writing GameEnded");
                        sw.WriteLine("GameEnded");
                        sw.Flush();
                        read = false;
                        write = false;
                        communicating = false;

                    }
                }
                if (read /*&& !(gp.Player_Health<=0)&&!(gp.Opponent_Health<=0)*/)
                {
                    Console.WriteLine("reading");
                    string request = sr.ReadLine();
                    Console.WriteLine("Request = "+request);
                    if (request != null && request!="GameEnded")
                    {
                        string[] tokens = request.Split(' ');
                        int angle = Convert.ToInt32(tokens[0]);
                        double power = Convert.ToDouble(tokens[1]);
                        gp.setOpponentAnglePower(angle, power);
                        read = false;
                        write = true;
                    }
                    else if(request=="GameEnded")
                    {
                        read = false;
                        write = false;
                        communicating = false;
                    }
                }
                
            }
            EndGame();
        }
        private void EndGame()
        {
            Console.WriteLine("Ending Game");
            sr.Close();
            sw.Close();
            communicator.Close();
            communicating = false;
            write = false;
            read = false;
            Console.WriteLine("GAME ENDED");
            this.Close();
            IntroForm.Show();
            Console.WriteLine("IntroForm Opened");
            Console.WriteLine("Aborting thread");
            t.Abort();
        }

    }
}
