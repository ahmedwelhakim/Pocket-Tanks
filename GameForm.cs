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
        private GamePanel gp;
        public Thread t;
        private bool communicating=true;
        private TcpClient communicator;
        public  StreamReader sr;
        public  StreamWriter sw;
        String [] powAngle;

        public GameForm()       //SinglePlayer Constructor
        {
            InitializeComponent();
            this.gp = new GamePanel();
            Controls.Add(gp);
            gp.StartGame();
        }

        public GameForm(int myPortNumber,GamePanel gp)         //Host Constructor
        {
            InitializeComponent();
            this.gp = gp;
            Controls.Add(gp);
            gp.StartGame();

            initHost_Communication(myPortNumber);
        }

        public GameForm(String hostIP,int hostPortNumber,GamePanel gp)      //Guest Constructor
        {
            InitializeComponent();
            this.gp = gp;
            Controls.Add(gp);
            gp.StartGame();

            initClient_Communication(hostIP, hostPortNumber);
        }

        private void initHost_Communication(int myPortNumber)
        {
            TcpListener listener = TcpListener.Create(myPortNumber);
            listener.Start();
            communicator = listener.AcceptTcpClient();
            sr = new StreamReader(communicator.GetStream());
            sw = new StreamWriter(communicator.GetStream());
            t = new Thread(communicate);
            t.Start();
            listener.Stop();
        }

        private void initClient_Communication(String hostIP,int hostPortNumber)
        {
            communicator = new TcpClient(hostIP, hostPortNumber);
            sr = new StreamReader(communicator.GetStream());
            sw = new StreamWriter(communicator.GetStream());
            t = new Thread(communicate);
            t.Start();
        }
        
        private void communicate()
        {
            while(communicating)
            {
                string request = sr.ReadLine();
                string[] tokens = request.Split(' ');
                int angle = Convert.ToInt32(tokens[0]);
                double power = Convert.ToDouble(tokens[1]);
                

            }
        }

    }
}
