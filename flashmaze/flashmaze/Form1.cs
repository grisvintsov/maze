using flashmaze.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace flashmaze
{
    public partial class Form1 : Form
    {
        engine engin = new engine();
        public Form1()
        {
            InitializeComponent();
            engin.gamestart();  

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var map = e.Graphics;
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (engin.mas[j, i] is wall) map.DrawImage((Image)Resources.wall, engin.mas[j, i].coordX, engin.mas[j, i].coordY);
                    if (engin.mas[j, i] is way) map.DrawImage((Image)Resources.way, engin.mas[j, i].coordX, engin.mas[j, i].coordY);
                    if (engin.mas[j, i] is ent) map.DrawImage((Image)Resources.end, engin.mas[j, i].coordX, engin.mas[j, i].coordY);
                    if (engin.mas[j, i] is exit) map.DrawImage((Image)Resources.end, engin.mas[j, i].coordX, engin.mas[j, i].coordY);
                    if (engin.mas[j, i] is dp) map.DrawImage((Image)Resources.player, engin.mas[j, i].coordX, engin.mas[j, i].coordY);
                }
            }
            //map.DrawImage((Image)Resources.player, engin.deadpool.p_coordX, engin.deadpool.p_coordY);
        }

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    //pictureBox1.Invalidate();
        //    //if (engin.nextlvl)
        //    //{
        //    //    MessageBox.Show("Вы выиграли игра закончина", "Конец");
        //    //    timer1.Enabled = false;

        //    //}

        //}

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                engin.move_t();
                pictureBox1.Invalidate();
            }
            else
            if (e.KeyCode == Keys.S)
            {
                engin.move_b();
                pictureBox1.Invalidate();
            }
            else
            if (e.KeyCode == Keys.A)
            {
                engin.move_l();
                pictureBox1.Invalidate();
            }
            else
            if (e.KeyCode == Keys.D)
            {
                engin.move_r();
                pictureBox1.Invalidate();
            }
            else return;
            if (engin.nextlvl)
            {
                MessageBox.Show("Вы выиграли игра закончина", "Конец");

            }
            
        }
    }
}
