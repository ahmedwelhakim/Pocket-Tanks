using Game.GameObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    static class Physics
    {
        public static float gravity = 1;
        public static List<PointF> path_pts;
        private static Pen dashed_pen;

        private static float PathEquation(float x,double angle,double speed_mag,float ground_Y,Player player)
        {
            double angle_rad = angle * Math.PI / 180.0;            
            float tankX = player.X + player.Width / 2;
            float y = (float)-((x - tankX) * Math.Tan(angle_rad) - ((Physics.gravity * Math.Pow(x - tankX, 2)) / (2 * Math.Pow(speed_mag, 2) * Math.Pow(Math.Cos(angle_rad), 2))));
            return y + ground_Y - player.Height;
        }
        private static float MaxHeight(double angle, double speed_mag)
        {
            double angle_rad = angle * Math.PI / 180.0;
            return (float)((Math.Pow(speed_mag,2)*Math.Pow(Math.Sin(angle_rad),2))/2*gravity);
        }
        private static float Range(double angle, double speed_mag,Player player)
        {
            double angle_rad = angle * Math.PI / 180.0;
            float tankX = player.X + player.Width / 2;
            return (float)((Math.Pow(speed_mag, 2) * Math.Sin(2*angle_rad)) /  gravity)+tankX;
        }
        public static void DrawFirePath(double angle,float ground_Y,Power power,Player player,Graphics g)
        {
            path_pts = new List<PointF>();
            dashed_pen = new Pen(Color.SandyBrown, 2.7f);
            dashed_pen.DashStyle = DashStyle.Dot;
            if (angle > 0 && angle < 180 && power.getPower_Val() > 10)
            {
                if (angle < 90)
                {
                    for (int i = (int)(player.X + player.Width / 2.0); i <= (int)Physics.Range(angle, power.getSpeedMagnitude()/1.2, player); i += 1)
                    {
                        path_pts.Add(new PointF(i, Physics.PathEquation(i, angle, power.getSpeedMagnitude(), ground_Y, player)));
                    }
                }
                else if (angle > 90)
                {
                    for (int i = (int)(player.X + player.Width / 2.0); i >= (int)Physics.Range(angle, power.getSpeedMagnitude()/1.2, player); i -= 1)
                    {
                        path_pts.Add(new PointF(i, Physics.PathEquation(i, angle, power.getSpeedMagnitude(), ground_Y, player)));
                    }
                }
                else if (angle == 90)
                {
                    path_pts.Add(new PointF((float)(player.X + player.Width / 2.0), ground_Y - player.Height));
                    path_pts.Add(new PointF((float)(player.X + player.Width / 2.0), ground_Y - player.Height - Physics.MaxHeight(angle, power.getSpeedMagnitude())));
                }
                if (path_pts.Count != 0)
                {
                    g.DrawCurve(dashed_pen, path_pts.ToArray());
                }
            }
        }
    }
}
