using GSP.Template.Wizard.Extensions;
using GSP.Template.Wizard.Forms;
using GSP.Template.Wizard.Wizards.Abstract;
using Microsoft.VisualStudio.TemplateWizard;
using System.Collections.Generic;
using static GSP.Template.Wizard.Constants.ProjectVariableNameConstants;

namespace GSP.Template.Wizard.Wizards
{
    public class DomainProjectTemplateSettingWizard : BaseWizard
    {
        public override void RunStarted(
            object automationObject,
            Dictionary<string, string> replacementsDictionary,
            WizardRunKind runKind, object[] customParams)
        {
            var projectSettingsForm = new DomainTemplateProjectSettingForm();
            projectSettingsForm.ShowDialog();

            replacementsDictionary.Add(DomainName, projectSettingsForm.DomainName);
            replacementsDictionary.Add(DomainNameLowerTitleCase, projectSettingsForm.DomainName.ToLowerTitleCase());
        }
    }
}