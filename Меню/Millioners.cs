using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Millioner.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Игра
{
    public partial class Millioners : Form
    {
        public Millioners()
        {
            InitializeComponent();
            NameRead();
        }

        string millionersOut = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "millioners.txt");
        List<string> millioners = new List<string>();

        private void NameRead()
        {
            Names.Text = string.Empty;

            try
            {
                using (StreamReader reader = new StreamReader(millionersOut))
                {
                    while (!reader.EndOfStream)
                    {
                        millioners.Add(reader.ReadLine() ?? string.Empty);
                    }
                    foreach (string millioner in millioners)
                    {
                        if (millioner != string.Empty && millioner != null)
                        {
                            Names.AppendText(millioner + "\r\n");
                        }
                    }
                }
            }
            catch
            {
                File.Create(millionersOut);
            }
        }
        private void BackButton_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
            menu.Location = this.Location;
            this.Close();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(millionersOut);
            sw.WriteLine(string.Empty);
            Names.Text = String.Empty;
            sw.Close();
        }

        Point lastPoint;

        private void Background_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Background_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}