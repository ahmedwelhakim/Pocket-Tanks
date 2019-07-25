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
        protected float X {get;set;}
        protected float Y { get;set;}
        protected float Height { get; set; }
        protected float Width { get; set; }
        public GameObject(float x,float y)
        {
            this.X = x;
            this.Y = y;
        }
        public abstract void Draw(Graphics g);
    }
}
