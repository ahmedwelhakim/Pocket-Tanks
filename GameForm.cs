using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class GameForm : Form
    {
        GamePanel gp;
        public GameForm()
        {
            InitializeComponent();
            gp = new GamePanel();
            Controls.Add(gp);

        }

       
    }
}
