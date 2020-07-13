using GSP.Template.Wizard.Extensions;
using GSP.Template.Wizard.Forms;
using GSP.Template.Wizard.Wizards.Abstract;
using Microsoft.VisualStudio.TemplateWizard;
using System.Collections.Generic;
using static GSP.Template.Wizard.Constants.ProjectVariableNameConstants;

namespace GSP.Template.Wizard.Wizards
{
    public class CommonProjectTemplateSettingWizard : BaseWizard
    {
        public override void RunStarted(
            object automationObject,
            Dictionary<string, string> replacementsDictionary,
            WizardRunKind runKind, object[] customParams)
        {
            var projectSettingsForm = new CommonTemplateProjectSettingForm();
            projectSettingsForm.ShowDialog();

            replacementsDictionary.Add(DomainName, projectSettingsForm.DomainName);
            replacementsDictionary.Add(DomainNameLowerTitleCase, projectSettingsForm.DomainName.ToLowerTitleCase());
            replacementsDictionary.Add(ProjectPlainName, projectSettingsForm.PlainProjectName);
        }
    }
}