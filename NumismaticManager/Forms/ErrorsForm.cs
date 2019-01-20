using NumismaticManager.Logics;
using System;
using System.Windows.Forms;

namespace NumismaticManager.Forms
{
    public partial class ErrorsForm : Form
    {
        public ErrorsForm()
        {
            InitializeComponent();
        }

        private void ErrorsForm_Load(object sender, EventArgs e)
        {
            DataGridViewErrors.DataSource = Database.GetErrors();
            DataGridViewErrors.Columns["Date"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DataGridViewErrors.Columns["Date"].FillWeight = 1;
            DataGridViewErrors.Columns["Class"].FillWeight = 1;
            DataGridViewErrors.Columns["Function"].FillWeight = 3;
            DataGridViewErrors.Columns["Message"].FillWeight = 7;
        }
    }
}
