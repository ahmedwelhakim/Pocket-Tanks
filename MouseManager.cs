using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public class MouseManager
    {
        public static int X { get; set; }
        public static int Y { get; set; }
        public static bool is_Left_Btn_Released { get; set;}
        static Dictionary<MouseButtons, bool> mouse_btns = new Dictionary<MouseButtons, bool>();
        public static void setMouseState(MouseButtons m,bool state)
        {
            mouse_btns[m] = state;
        }
        public static bool getMouseState(MouseButtons m)
        {
            if (mouse_btns.ContainsKey(m))
            {
                return mouse_btns[m];
            }
            return false;
        }
    }
}
