using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            GameForm gf = new GameForm();
            Console.WriteLine(gf.Height  ); 
            Application.Run(gf);
=======
            Application.Run(new GameForm());
>>>>>>> 4e931aed645e329ce9fe5755ad3f4a65a5f0f8de
        }
    }
}
