using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6_2
{
    public partial class Form1 : Form
    {
        int i=0;
        int score = 0;
        public  PictureBox[] pic = new PictureBox[1000];
        int c = 0;
        public Form1()
        {
            InitializeComponent();
            i = 0;
            timer1.Enabled = true;
            pictureBox3.Image = Image.FromFile("Invader.png");
            pictureBox3.Hide();
            pictureBox1.Image = Image.FromFile("ship 1.png");
            timer1.Start();
            timer3.Start();
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    pictureBox1.Left -= 5;
                    if (pictureBox1.Left < 0)
                    {
                        pictureBox1.Left += 20;
                    }
                    break;
                case Keys.Right:
                    pictureBox1.Left += 5;
                    if (pictureBox1.Left+30 > pictureBox2.Left)
                    {
                        pictureBox1.Left -= 20;
                    }       
                    break;
                case Keys.Up:
                    pictureBox1.Top -= 5;
                    if (pictureBox1.Top <= 0)
                    {
                        pictureBox1.Top += 20;
                    }
                    break;
                case Keys.Down:
                    pictureBox1.Top += 5;
                    if (pictureBox1.Top >240)
                    {
                        pictureBox1.Top -= 20;
                    }
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
      
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            label2.Text = score.ToString();
            Random r = new Random();
            int x = r.Next(0, pictureBox2.Left-10);
            pic[c] = new PictureBox();        
            pic[c].Image = pictureBox3.Image;
            pic[c].SizeMode = PictureBoxSizeMode.Zoom;
            pic[c].Size = new Size(20, 20);
            pic[c].Left = x;
            score++;
            timer2.Start();
            this.Controls.Add(pic[c]);
           // pic[c].Top += 10;
            if (c < 999)
            {
                c++;
            }
            else
            {
                timer1.Stop();
                c = 0;
            }
            

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            for (i = 0; i < c; i++)
            {
                pic[i].Top += 10;
            }
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            timer1.Start();
            timer2.Start();
            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            for (int j = 0; j < c; j++)
            {

                if ((pic[j].Top <= pictureBox1.Top + pictureBox1.Height && pic[j].Top >= pictureBox1.Top - pic[j].Height) && pic[j].Left <= pictureBox1.Left + pictureBox1.Width && pic[j].Left >= pictureBox1.Left - pic[j].Width)
                {
                    timer1.Stop();
                    timer2.Stop();
                    timer3.Stop();
                    DialogResult a = MessageBox.Show("gameover");
                    if (a == DialogResult.OK)
                    {
                        score = 0;
                        pictureBox1.Location = new Point(130, 230);
                        button1.Enabled = true;
                        for (int i = 0; i < c; i++)
                        {
                            pic[i].Location = new Point(-100, -100);
                            pic[i].Dispose();
                        }
                        label2.Text = score.ToString();
                    }

                }
            }
        }
    }
}
