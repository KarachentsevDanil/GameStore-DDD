using System;
using System.Windows.Forms;
using static GSP.Template.Wizard.Constants.ErrorMessageConstants;

namespace GSP.Template.Wizard.Forms
{
    public partial class DomainTemplateProjectSettingForm : Form
    {
        public string DomainName => _domainName.Text;

        public DomainTemplateProjectSettingForm()
        {
            InitializeComponent();
        }

        private void CreateButtonClickHandler(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_domainName.Text))
            {
                MessageBox.Show(FillRequiredFieldErrorMessage);
                return;
            }

            Close();
        }
    }
}