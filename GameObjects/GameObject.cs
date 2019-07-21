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

        public GameObject(int x,int y)
        {
            this.X = X;
            this.Y = y;
        }
        public abstract void Draw(Graphics g);
    }
}
