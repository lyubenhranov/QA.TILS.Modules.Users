namespace QA.TILS.Modules.Users.Core.Pages.MessagesPage
{
    using QA.Framework.Core.Base;

    public class MessagesPage : BasePage
    {
        public MessagesPage()
        {
            this.Elements = new MessagesPageElements();
            this.Validator = new MessagesPageValidator();
            this.Url = "/Messages";
        }

        public MessagesPageElements Elements { get; set; }

        public MessagesPageValidator Validator { get; set; }
    }
}
