using System;
using System.Windows.Forms;

namespace Redmine_for_dummies
{
    public partial class LoginCredentialsWindows : Form
    {
        public string EmailTextBox
        {
            get; set;
        }
        public string PasswordTextBox
        {
            get; set;
        }
        private Form _parentForm;

        public LoginCredentialsWindows()
        {
            InitializeComponent();
            _parentForm = ParentForm;
        }

        public void LogButton_Click(object sender, EventArgs e)
        {
            EmailTextBox = txtEmail.Text;
            PasswordTextBox = txtPassword.Text;
            Hide();
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                LogButton_Click(null, null);
            }
        }
    }
}
