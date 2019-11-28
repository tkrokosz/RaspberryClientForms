using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaspberryClientForms
{
    public partial class Form1 : Form
    {
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        public Form1()
        {
            InitializeComponent();
            temperatureUserControl1.Visible = false;


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel3.Height = button1.Height;
            panel3.Top = button1.Top;

            startUserControl1.Visible = false;
            temperatureUserControl1.Visible = true;
            windowUserControl1.Visible = false;
            doorUserControl1.Visible = false;
            groupSettings1.Visible = false;
            stats1.Visible = false;
            button1.BackColor = Color.FromArgb(60, 70, 80);
            button7.BackColor = Color.FromArgb(41, 53, 65);
            button2.BackColor = Color.FromArgb(41, 53, 65);
            button3.BackColor = Color.FromArgb(41, 53, 65);
            button6.BackColor = Color.FromArgb(41, 53, 65);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel3.Height = button2.Height;
            panel3.Top = button2.Top;

            startUserControl1.Visible = false;
            temperatureUserControl1.Visible = false;
            windowUserControl1.Visible = true;
            doorUserControl1.Visible = false;
            groupSettings1.Visible = false;
            stats1.Visible = false;

            button2.BackColor = Color.FromArgb(60, 70, 80);
            button1.BackColor = Color.FromArgb(41, 53, 65);
            button7.BackColor = Color.FromArgb(41, 53, 65);
            button3.BackColor = Color.FromArgb(41, 53, 65);
            button6.BackColor = Color.FromArgb(41, 53, 65);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel3.Height = button3.Height;
            panel3.Top = button3.Top;

            startUserControl1.Visible = false;
            temperatureUserControl1.Visible = false;
            windowUserControl1.Visible = false;
            doorUserControl1.Visible = true;
            groupSettings1.Visible = false;
            stats1.Visible = false;

            button1.BackColor = Color.FromArgb(41, 53, 65);
            button2.BackColor = Color.FromArgb(41, 53, 65);
            button7.BackColor = Color.FromArgb(41, 53, 65);
            button6.BackColor = Color.FromArgb(41, 53, 65);
            button3.BackColor = Color.FromArgb(60, 70, 80);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void header_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void header_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void header_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button1_Move(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.WindowState = FormWindowState.Minimized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel3.Height = button6.Height;
            panel3.Top = button6.Top;

            startUserControl1.Visible = false;
            temperatureUserControl1.Visible = false;
            windowUserControl1.Visible = false;
            doorUserControl1.Visible = false;
            groupSettings1.Visible = true;
            stats1.Visible = false;

            button1.BackColor = Color.FromArgb(41, 53, 65);
            button2.BackColor = Color.FromArgb(41, 53, 65);
            button3.BackColor = Color.FromArgb(41, 53, 65);
            button7.BackColor = Color.FromArgb(41, 53, 65);
            button6.BackColor = Color.FromArgb(60, 70, 80);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel3.Height = button7.Height;
            panel3.Top = button7.Top;

            startUserControl1.Visible = false;
            temperatureUserControl1.Visible = false;
            windowUserControl1.Visible = false;
            doorUserControl1.Visible = false;
            groupSettings1.Visible = false;
            stats1.Visible = true;

            button1.BackColor = Color.FromArgb(41, 53, 65);
            button2.BackColor = Color.FromArgb(41, 53, 65);
            button3.BackColor = Color.FromArgb(41, 53, 65);
            button6.BackColor = Color.FromArgb(41, 53, 65);
            button7.BackColor = Color.FromArgb(60, 70, 80);
        }


        private void groupSettings1_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void header_Paint(object sender, PaintEventArgs e)
        {

        }

        private void startUserControl1_Load(object sender, EventArgs e)
        {

        }

        private void temperatureUserControl1_Load(object sender, EventArgs e)
        {

        }

        private void windowUserControl1_Load(object sender, EventArgs e)
        {

        }

        private void doorUserControl1_Load(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void stats1_Load(object sender, EventArgs e)
        {

        }
    }
}
