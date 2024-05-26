using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp55
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            if (f.ShowDialog() == DialogResult.OK)
            {
                int x = Convert.ToInt32(f.textBox1.Text);
                int y = Convert.ToInt32(f.textBox2.Text);
                int h = Convert.ToInt32(f.textBox3.Text);
                Figura fg = new Figura(x, y, h, pictureBox1);
                listBox1.Items.Add(fg);
                DrawFigures();

            }
        }

        private void DrawFigures()
        {
            Graphics gr = Graphics.FromImage(pictureBox1.Image);
            SolidBrush solidBrush = new SolidBrush(Color.Purple);
            gr.FillRectangle(solidBrush, 0, 0, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Refresh(); 

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                Figura fg1 = listBox1.Items[i] as Figura;
                fg1.Draw();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Объект для удаления не выбран");
            }
            else
            {
                Figura selectedFigura = (Figura)listBox1.SelectedItem;
                listBox1.Items.Remove(selectedFigura);
                pictureBox1.Refresh();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Bitmap bp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bp;
            Graphics gr = Graphics.FromImage(bp);
            SolidBrush solidBrush = new SolidBrush(Color.Purple);
            gr.FillRectangle(solidBrush, 0, 0, pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            if (f.ShowDialog() == DialogResult.OK)
            {
                int index = listBox1.SelectedIndex;
                if (index != -1)
                {
                    int x = Convert.ToInt32(f.textBox1.Text);
                    int y = Convert.ToInt32(f.textBox2.Text);
                    int h = Convert.ToInt32(f.textBox3.Text);
                    Figura selectedFigure = (Figura)listBox1.Items[index];
                    selectedFigure.SetPosition(x, y);
                    selectedFigure.SetHeight(h);
                    DrawFigures();
                }
                else
                {
                    MessageBox.Show("Выберите фигуру для редактирования.");
                }


            }
        }
    }
}
