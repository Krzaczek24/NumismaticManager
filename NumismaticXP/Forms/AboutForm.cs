using System.Windows.Forms;

namespace Numismatic.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, System.EventArgs e)
        {
            MinimumSize = Size;
        }

        private void ButtonClose_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
