using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Игра
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            game.Show();
            game.Location = this.Location;
            this.Hide();
        }

        private void RecordButton_Click(object sender, EventArgs e)
        {
            Millioners millioners = new Millioners();
            millioners.Show();
            millioners.Location = this.Location;
            this.Hide();
        }

        private void CloseGameButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
