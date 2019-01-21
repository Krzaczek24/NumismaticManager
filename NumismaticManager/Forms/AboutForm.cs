using System.Windows.Forms;

namespace NumismaticManager.Forms
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
    }
}
