namespace QA.TILS.Modules.Users.Core.Pages.FriendsPage
{
    using QA.Framework.Core.Base;

    public class FriendsPage : BasePage
    {
        public FriendsPage()
        {
            this.Elements = new FriendsPageElements();
            this.Validator = new FriendsPageValidator();
            this.Url = "/Friends";
        }

        public FriendsPageElements Elements { get; set; }
        public FriendsPageValidator Validator { get; set; }

    }
}
