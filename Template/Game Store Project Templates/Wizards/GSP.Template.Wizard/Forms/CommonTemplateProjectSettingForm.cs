using System;
using System.Windows.Forms;
using static GSP.Template.Wizard.Constants.ErrorMessageConstants;

namespace GSP.Template.Wizard.Forms
{
    public partial class CommonTemplateProjectSettingForm : Form
    {
        public string DomainName => _domainName.Text;

        public string PlainProjectName => _plainProjectName.Text;

        public CommonTemplateProjectSettingForm()
        {
            InitializeComponent();
        }

        private void CreateButtonClickHandler(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(_domainName.Text) || string.IsNullOrWhiteSpace(_plainProjectName.Text))
            {
                MessageBox.Show(FillRequiredFieldErrorMessage);
                return;
            }

            Close();
        }
    }
}