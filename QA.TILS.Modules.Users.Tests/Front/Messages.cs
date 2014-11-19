namespace QA.TILS.Modules.Users.Tests.Functional.Front
{
    using ArtOfTest.WebAii.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Helpers;
    using QA.TILS.Modules.Users.Core.Pages.Common;
    using QA.TILS.Modules.Users.Core.Pages.MessagesPage;
    using QA.TILS.Modules.Users.Core.SharedSteps;

    /// <summary>
    /// The initial state that must serve as a precondition for all of the tests below is 
    /// that TestUser1 and TestUser 2 are friends and there are no new messages between them
    /// </summary>
    [TestClass]
    public class Messages : BaseTest
    {
        private MessagesPage messagesPage;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            BaseClassInitialize();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            BaseClassCleanup();
        }

        public override void TestInitialize()
        {
            this.messagesPage = new MessagesPage();

            Manager.Current.Settings.Web.RecycleBrowser = true;
        }

        [TestMethod]
        [Priority(1)]
        public void LoggedUsers_ShouldHaveAccessMessagesSection()
        {
            LoginSteps.LoginTestUser1();
            this.messagesPage.NavigateTo();

            messagesPage.Validator.MessagesPageHasLoadedCorrectly();
        }

        [TestMethod]
        [Priority(1)]
        public void LoggedOutUsers_ShouldNotHaveAccessToMessagesSection()
        {
            this.messagesPage.NavigateTo();

            CommonPagesValidator.AssertCorrectPageHasBeenLoaded(this.Browser.Url, "http://test.telerikacademy.com/Users/Auth/Login");
        }

        [TestMethod]
        [Priority(1)]
        public void MessagesSent_ShouldBeReceivedByTheRecepient()
        {
            string messageContent = RandomDataGenerator.GenerateRandomString(5, 15);

            MessagesSteps.SendMessageFromTestUser1ToTestUser2AndLoginTestUser2(messageContent);

            this.messagesPage.NavigateTo();
            this.messagesPage.Elements.FriendTile.Click();

            this.messagesPage.Validator.MessagesSectionHasLoaded();

            this.messagesPage.Validator.MessageContentIsContainedInMessages(messageContent);

            // Reverse to initial state (there are no unread messages between the users)
            MessagesSteps.ReadNewMessages();
        }

        [TestMethod]
        [Priority(2)]
        public void NewMessagesSent_ShouldInvokeNewMessagesNotification()
        {
            MessagesSteps.SendMessageFromTestUser1ToTestUser2AndLoginTestUser2("Test message");

            CommonPagesValidator.StartPageNewMessagesNotificationExists();

            // Reverse to initial state (there are no unread messages between the users)
            MessagesSteps.ReadNewMessages();
        }

        [TestMethod]
        [Priority(2)]
        public void NewMessagesNotification_ShouldBeRemovedAfterTheMessageIsRead()
        {
            string messageContent = RandomDataGenerator.GenerateRandomString(5, 15);

            MessagesSteps.SendMessageFromTestUser1ToTestUser2AndLoginTestUser2(messageContent);

            CommonPagesValidator.StartPageNewMessagesNotificationExists();
            MessagesSteps.ReadNewMessages();

            NavigateTo.Url("http://test.telerikacademy.com/");
            CommonPagesValidator.StartPageNewMessagesNotificationDoesNotExist();
        }
    }
}
