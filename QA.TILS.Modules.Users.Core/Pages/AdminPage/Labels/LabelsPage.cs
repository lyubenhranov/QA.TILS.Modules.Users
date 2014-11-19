using QA.Framework.Core.Base;
using QA.TILS.Modules.Users.Core.Pages.AdminPage.Labels;
using QA.TILS.Modules.Users.Core.SharedSteps;

namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.Labels
{
    public class LabelsPage : BasePage
    {
        public LabelsPage()
        {
            this.Validator = new LabelsPageValidator(this);
            this.Elements = new LabelsPageElements();
            this.Url = "Administration_Users/UserLabels";
        }

        public LabelsPageValidator Validator { get; private set; }
        public LabelsPageElements Elements { get; private set; }

        public void NavigateToAsAdmin()
        {
            LoginSteps.LoginAdmin();
            this.NavigateTo();
        }
    }
}
