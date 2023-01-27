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
using Игра.Properties;

namespace Игра
{
    public partial class Winner : Form
    {
        public Winner()
        {
            InitializeComponent();
        }

        private void InputName()
        {
            if (NameInput.Text != String.Empty)
            {
                string millioners = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "millioners.txt");
                using (StreamWriter file = new StreamWriter(millioners, true))
                {
                    if (!File.Exists(millioners))
                    {
                        File.Create(millioners);
                    }
                    file.WriteLine(NameInput.Text);
                }
            }
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            InputName();
            Menu menu = new Menu();
            menu.Show();
            menu.Location = this.Location;
            this.Close();
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
