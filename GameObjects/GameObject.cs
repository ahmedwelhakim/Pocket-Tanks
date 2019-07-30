using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameObjects
{
    abstract class GameObject
    {
        public float X {get;set;}
        public float Y { get;set;}
        public float Height { get; set; }
        public float Width { get; set; }


        public GameObject(float x,float y)
        {
            this.X = x;
            this.Y = y;
        }
        public static bool checkCollision(GameObject gameObj1, GameObject gameObj2)
        {
            double center_x1 = gameObj1.X + gameObj1.Width / 2.0;
            double center_y1 = gameObj1.Y + gameObj1.Height / 2.0;

            double center_x2 = gameObj2.X + gameObj2.Width / 2.0;
            double center_y2 = gameObj2.Y + gameObj2.Height / 2.0;

            double distX =Math.Abs(center_x1 - center_x2);
            double distY = Math.Abs(center_y1 - center_y2);

            double sum_width = gameObj1.Width / 2.0 + gameObj2.Width / 2.0;
            double sum_height = gameObj1.Height / 2.0 + gameObj2.Height / 2.0;

            return (distX <= sum_width && distY <=sum_height);

        }
        public abstract void Draw(Graphics g);
    }
}
