using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class IntroForm : Form
    {
        Thread t;
        public IntroForm()
        {
            InitializeComponent();
        }

        private void Host_RadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            Client_GroupBox.Enabled = false;
            Host_GroupBox.Enabled = true;
            //Play_Btn.Enabled = true;
        }

        private void Client_RadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            Client_GroupBox.Enabled = true;
            Host_GroupBox.Enabled = false;
            //Play_Btn.Enabled = true;
        }
        private void Single_RadBtn_CheckedChanged(object sender, EventArgs e)
        {
            Client_GroupBox.Enabled = false;
            Host_GroupBox.Enabled = false;
           // Play_Btn.Enabled = true;
        }
        private void spclient_rdbutton1_CheckedChanged(object sender, EventArgs e)
        {

            Client_GroupBox.Enabled = false;
            Host_GroupBox.Enabled = false;
          //  Play_Btn.Enabled = true;
        }
        private void Play_Btn_Click(object sender, EventArgs e)
        {
            if(Host_RadioBtn.Checked)
            {
                
                int portNum = int.Parse(Host_Port_TxtBox.Text);
                GameForm gf = new GameForm(portNum, this);
                this.Hide();
                gf.Show();
                
            }
            else if(Client_RadioBtn.Checked)
            {
                int portNum = int.Parse(Client_Port_TxtBox.Text);
                String hostIP =Client_IP_TxtBox.Text;

                GameForm gf = new GameForm(hostIP, portNum, this);
                this.Hide();
                gf.Show();
            }
            else if(Single_RadBtn.Checked)
            {
                GameForm gf = new GameForm(this,User.Host);
                this.Hide();
                gf.Show();
            }
            else
            {

                GameForm gf = new GameForm(this,User.Client);
                this.Hide();
                gf.Show();
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SinglePlayer_groupBox.Hide();
            Multiplayer_groupBox.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void spclient_rdbutton1_CheckedChanged_1(object sender, EventArgs e)
        {
            Play_Btn.Enabled = true;
        }

        private void Singleplayer_Click(object sender, EventArgs e)
        {
            SinglePlayer_groupBox.Show();
            Multiplayer_groupBox.Hide();
        }

        private void Single_RadBtn_CheckedChanged_1(object sender, EventArgs e)
        {
            Play_Btn.Enabled = true;
        }

        private void Host_RadioBtn_CheckedChanged_1(object sender, EventArgs e)
        {
            Play_Btn.Enabled = true;
        }

        private void Client_RadioBtn_CheckedChanged_1(object sender, EventArgs e)
        {
            Play_Btn.Enabled = true;
        }
    }
}
