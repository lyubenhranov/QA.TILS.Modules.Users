namespace QA.TILS.Modules.Users.Core.Pages.MessagesPage
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Extensions;

    public class MessagesPageValidator : BasePageValidator
    {
        private string testUserMessaesIdentifier = "13:32, 1.10Test22:49, 8.10Test22:52, 8.10Test22:54, 8.10This is a text message";
        private MessagesPage messagesPage = new MessagesPage();        

        public void MessagesOfTheCorrectUserHaveBeenSelected()
        {
            this.messagesPage.Elements.Messages.AssertTextIsContained(this.testUserMessaesIdentifier);
        }

        public void MessagesPageHasLoadedCorrectly()
        {
            messagesPage.Elements.SendMessageButton.Wait.ForExists(5000);
        }

        public void MessagesSectionHasLoaded()
        {
            this.messagesPage.Elements.Messages.Wait.ForExists(5000);
        }

        public void MessageContentIsContainedInMessages(string messageContent)
        {
            Assert.IsTrue(this.messagesPage.Elements.Messages.InnerText.Contains(messageContent));
        }
    }
}
