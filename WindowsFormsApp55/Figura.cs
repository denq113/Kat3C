using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp55
{
    public class Figura
    {
        int x;
        int y;
        int h;
        PictureBox pb;

        public Figura(int nx, int ny, int nh, PictureBox npb )
        {
            x = nx;
            y = ny;
            h = nh;
            pb = npb;
            Draw();
        }

        public void Draw()
        {
          
            Graphics gr = Graphics.FromImage(pb.Image);
            Pen obwodka = new Pen(Color.Red);
            SolidBrush zalivka = new SolidBrush(Color.SkyBlue);
            SolidBrush zalivkaG = new SolidBrush(Color.Green);
            gr.FillRectangle(zalivka, x, y, h, h);
            gr.DrawRectangle(obwodka, x, y, h, h);
            gr.DrawLine(obwodka, x, y,x + h, y + h);
            gr.DrawLine(obwodka, x + h, y, x, y + h);
            gr.FillEllipse(zalivkaG, x + (h / 3), y + h / 20, h / 3, h / 3);
            gr.FillEllipse(zalivkaG, x + (h / 3), y + h * 3 / 5,h / 3, h / 3);
            pb.Refresh();
        }
        internal void SetPosition(int newX, int newY)
        {
            x = newX;
            y = newY;
            Draw();
        }
        internal void SetHeight(int newHeight)
        {
            h = newHeight;
            Draw();
        }
    }
}
