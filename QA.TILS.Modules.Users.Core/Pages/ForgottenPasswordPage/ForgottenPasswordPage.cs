namespace QA.TILS.Modules.Users.Core.Pages.ForgottenPasswordPage
{
    using QA.Framework.Core.Base;

    public class ForgottenPasswordPage : BasePage
    {
        public ForgottenPasswordPage()
        {
            this.Elements = new ForgottenPasswordPageElements();
            this.Validator = new ForgottenPasswordPageValidator();
            this.Url = "/Users/Auth/ForgottenPassword";
        }

        public ForgottenPasswordPageElements Elements { get; set; }

        public ForgottenPasswordPageValidator Validator { get; set; }
    }
}
