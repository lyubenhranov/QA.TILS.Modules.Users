namespace QA.TILS.Modules.Users.Core.Pages.ForgottenPasswordPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using QA.Framework.Core.Extensions;
    using QA.Framework.Core.Base;

    public class ForgottenPasswordPageElements : BaseElementsMap
    {
        public HtmlInputText UsernameOrEmailField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("usernameOrEmailAddress");
            }
        }

        public HtmlInputSubmit SendNewPasswordButton
        {
            get
            {
                return this.Find.ByAttributes<HtmlInputSubmit>("generalButtonStyles normalButton greenButton".ToClassIsExpression());
            }
        }
    }
}
