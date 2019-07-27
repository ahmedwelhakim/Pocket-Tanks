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
        public abstract void Draw(Graphics g);
    }
}
