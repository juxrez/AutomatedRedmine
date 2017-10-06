using System;
using System.Windows.Forms;

namespace Redmine_for_dummies
{
    public partial class LoginCredentialsWindows : Form
    {
        public string EmailTextBox { get; set; }
        public string PasswordTextBox { get; set; }
        public string IssueTextBox { get; set; }

        private Form _parentForm;

        public LoginCredentialsWindows()
        {
            InitializeComponent();
            _parentForm = ParentForm;
        }

        public void LogButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) || !string.IsNullOrEmpty(txtIssue.Text) || !string.IsNullOrEmpty(txtPassword.Text))
            {
                EmailTextBox = txtEmail.Text;
                PasswordTextBox = txtPassword.Text;
                IssueTextBox = txtIssue.Text;
                Hide();
            }
            else
                MessageBox.Show("Please enter your credentials", "Error");
        }

        private void txtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                LogButton_Click(null, null);
            }
        }

        private void LoginCredentialsWindows_Load(object sender, EventArgs e)
        {
            txtEmail.Text = "alexis.juarez@unosquare.com";
            txtPassword.Text = "panda123";
            txtIssue.Text = "31330";
        }
    }
}
