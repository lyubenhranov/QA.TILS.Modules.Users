namespace QA.TILS.Modules.Users.Core.SharedSteps
{
    using ArtOfTest.WebAii.Core;
    using QA.Framework.Core.Data;
    using QA.Framework.Core.Data.Templates;
    using QA.Framework.Core.Helpers;
    using QA.TILS.Modules.Users.Core.Pages.Common;
    using QA.TILS.Modules.Users.Core.Pages.MessagesPage;

    public static class MessagesSteps
    {
        private static NotLoggedUserProfilePageElements UserProfilePage
        {
            get
            {
                return new NotLoggedUserProfilePageElements();
            }
        }

        private static LoggedUserStartPageElements UserStartPage
        {
            get
            {
                return new LoggedUserStartPageElements();
            }
        }

        private static MessagesPage MessagesPage
        {
            get
            {
                return new MessagesPage();
            }
        }

        public static void SendMessageTo(User user, string messageContent)
        {
            NavigateTo.Url(user.ProfileUrl);
            UserProfilePage.SendMessageButton.Click();

            Manager.Current.ActiveBrowser.WaitUntilReady();

            MessagesPage.Elements.MessageToSendTextArea.Text = messageContent;
            MessagesPage.Elements.SendMessageButton.Click();
        }

        public static void ReadNewMessages()
        {
            NavigateTo.Page(MessagesPage);
            MessagesPage.Elements.FriendTile.Click();
        }

        public static void SendMessageFromTestUser1ToTestUser2AndLoginTestUser2(string messageContent)
        {
            LoginSteps.LoginTestUser1();
            MessagesSteps.SendMessageTo(TestUsers.TestUser2, messageContent);

            LoginSteps.LoginTestUser2();
        }
    }
}
