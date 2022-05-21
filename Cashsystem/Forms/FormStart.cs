namespace Cashsystem.Forms
{
    public partial class FormStart : Form
    {
        public FormStart()
        {
            InitializeComponent();
        }

        private void buttonCashSystem_Click(object sender, EventArgs e)
        {
            FormSingleton.GetInstance().FormCashSystem.Show();
            FormSingleton.GetInstance().FormStart.Hide();
        }
    }
}