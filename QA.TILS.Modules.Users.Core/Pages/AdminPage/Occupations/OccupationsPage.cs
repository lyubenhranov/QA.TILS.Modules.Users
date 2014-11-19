namespace QA.TILS.Modules.Users.Core.Pages.OccupationsPage
{
    using QA.Framework.Core.Base;
    using QA.TILS.Modules.Users.Core.SharedSteps;

    public class OccupationsPage : BasePage
    {
        public OccupationsPage()
        {
            this.Elements = new OccupationsPageElements();
            this.Validator = new OccupationsPageValidator(this);
            this.Url = "Administration_Users/WorkEducationStatuses";
        }

        public OccupationsPageElements Elements { get; set; }
        public OccupationsPageValidator Validator { get; set; }

        public void NavigateToAsAdmin()
        {
            LoginSteps.LoginAdmin();
            this.NavigateTo();
        }
    }
}
