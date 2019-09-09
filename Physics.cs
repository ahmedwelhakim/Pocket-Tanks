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
        private static List<PointF> path_pts;
        private static List<RectangleF> circles;
        private static Pen dashed_pen;
        static float z_lw90 = 0;
        static float z_hi90 = 0;
        static float z_90 = 0;
        public static float PathEquation(float x, double angle, double speed_mag, float ground_Y, Player player)
        {
            double angle_rad = angle * Math.PI / 180.0;
            float tankX = player.X + player.Width / 2;
            float y = (float)-((x - tankX) * Math.Tan(angle_rad) - ((Physics.gravity * Math.Pow(x - tankX, 2)) / (2 * Math.Pow(speed_mag, 2) * Math.Pow(Math.Cos(angle_rad), 2))));
            return y + ground_Y - player.Height;
        }
        public static float MaxHeight(double angle, double speed_mag)
        {
            double angle_rad = angle * Math.PI / 180.0;
            return (float)((Math.Pow(speed_mag, 2) * Math.Pow(Math.Sin(angle_rad), 2)) / 2 * gravity);
        }
        public static float Range(double angle, double speed_mag, Player player)
        {
            double angle_rad = angle * Math.PI / 180.0;
            float tankX = player.X + player.Width / 2;
            return (float)((Math.Pow(speed_mag, 2) * Math.Sin(2 * angle_rad)) / gravity) + tankX;
        }
        public static void DrawFirePath_dashedLine(double angle, float ground_Y, Power power, Player player, Graphics g)
        {
            path_pts = new List<PointF>();
            dashed_pen = new Pen(Color.SandyBrown, 2.7f);
            dashed_pen.DashStyle = DashStyle.Dot;
            if (angle > 0 && angle < 180 && power.getPower_Val() > 10)
            {
                if (angle < 90)
                {
                    for (int i = (int)(player.X + player.Width / 2.0); i <= (int)Physics.Range(angle, power.getSpeedMagnitude() / 1.2, player); i += 1)
                    {
                        path_pts.Add(new PointF(i, Physics.PathEquation(i, angle, power.getSpeedMagnitude(), ground_Y, player)));
                    }
                }
                else if (angle > 90)
                {
                    for (int i = (int)(player.X + player.Width / 2.0); i >= (int)Physics.Range(angle, power.getSpeedMagnitude() / 1.2, player); i -= 1)
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
        public static void DrawFirePath_movingBalls(double angle, float ground_Y, Power power, Player player, Graphics g)
        {
            circles = new List<RectangleF>();
            float range_percent = 0.65f;
            if (angle > 0 && angle < 180 && power.getPower_Val() > 10)
            {
                if (angle < 90)
                {//Physics.Range return the last x in the range of path equation
                    float range = (float)Physics.Range(angle, power.getSpeedMagnitude() * range_percent, player) - (float)(player.X + player.Width / 2.0);
                    float actual_len;
                    float ratio;
                    float size;
                    for (float i = (float)(player.X + player.Width / 2.0) + z_lw90; i <= (float)Physics.Range(angle, power.getSpeedMagnitude() * range_percent, player);  )
                    {
                        actual_len = (float)Physics.Range(angle, power.getSpeedMagnitude() * range_percent, player) - i;
                        ratio = actual_len / range;
                        size = 7 * ratio + 3;
                        circles.Add(new RectangleF(i - size / 2, Physics.PathEquation(i, angle, power.getSpeedMagnitude(), ground_Y, player) - size / 2, size, size));
                        i += range / 20f;
                        z_lw90 += range / (15 * 200);
                        if (z_lw90 > range / 20)
                        {
                            z_lw90 = 0;
                        }
                    }
                }
                else if (angle > 90)
                {
                    for (float i = (float)(player.X + player.Width / 2.0) + z_hi90; i >= (float)Physics.Range(angle, power.getSpeedMagnitude() * range_percent, player);)
                    {
                        float range = (float)Physics.Range(angle, power.getSpeedMagnitude() * range_percent, player) - (float)(player.X + player.Width / 2.0);
                        float actual_len = (float)Physics.Range(angle, power.getSpeedMagnitude() * range_percent, player) - i;
                        float ratio = actual_len / range;
                        float size = 7 * ratio + 3;
                        circles.Add(new RectangleF(i - size / 2, Physics.PathEquation(i, angle, power.getSpeedMagnitude(), ground_Y, player) - size / 2, size, size));
                        i += range / 20f;
                        z_hi90 += range / (15 * 200);
                        if (z_hi90 < range / 20)
                        {
                            z_hi90 = 0;
                        }
                    }
                }
                else if (angle == 90)
                {
                    float height = ground_Y - player.Height - Physics.MaxHeight(angle, power.getSpeedMagnitude());
                    float actual_height;
                    float len;
                    float ratio;
                    float size;
                    for (float i = (float)(player.Y) - z_90; i >= height;)
                    {
                        height = ground_Y - player.Height - Physics.MaxHeight(angle, power.getSpeedMagnitude());
                        actual_height =player.Y- i;
                        len = Math.Abs(player.Y - height);
                        ratio = 1-(actual_height / len);
                        size = 7 * ratio + 3;
                        circles.Add(new RectangleF(player.X+player.Width/2 -size/2.0f, i, size, size));
                        i -= len / 20f;
                        z_90 += len / (15 * 200);
                        if (z_90 > len / 20)
                        {
                            z_90 = 0;
                        }

                    }
                    
                }
                if (circles.Count != 0)
                {
                    foreach (var c in circles)
                    {
                        g.FillEllipse(Brushes.Chocolate, c);
                    }
                }
       
            }
        }
    }
}
