using System;
using System.Drawing;
using System.Windows.Forms;

namespace NumismaticManager.Forms
{
    public partial class BusyForm : Form
    {
        public BusyForm(string message)
        {
            InitializeComponent();

            MessageLabel.Text = Text = message;

            Show();

            if (StartPosition == FormStartPosition.CenterParent)
            {
                Form main = Application.OpenForms["Main"];
                var x = main.Location.X + (main.Width - Width) / 2;
                var y = main.Location.Y + (main.Height - Height) / 2;
                Location = new Point(Math.Max(x, 0), Math.Max(y, 0));
            }

            Refresh();
        }
    }
}
