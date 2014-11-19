namespace QA.TILS.Modules.Users.Tests.Functional.Front
{
    using ArtOfTest.WebAii.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Data;
    using QA.TILS.Modules.Users.Core.Pages.FriendsPage;
    using QA.TILS.Modules.Users.Core.Pages.MessagesPage;
    using QA.TILS.Modules.Users.Core.SharedSteps;

    /// <summary>
    /// The initial state that must serve as a precondition for all of the tests below is 
    /// that TestUser1 and TestUser 2 are friends
    /// </summary>
    [TestClass]
    public class Friends : BaseTest
    {
        private FriendsPage friendsPage;
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
            this.friendsPage = new FriendsPage();
            this.messagesPage = new MessagesPage();
        }

        [TestMethod]
        [Priority(2)]
        public void TryingToRemoveAFriend_ShouldPromptForConfirmation()
        {
            FriendsSteps.NavigateToTestUser1FriendsPage();

            this.friendsPage.Elements.RemoveFriendshipButton.Click();
            this.friendsPage.Validator.RemoveFriendsNotificationExists();
        }

        [TestMethod]
        [Priority(3)]
        public void RequestingAFriendship_ShouldNotAddUserToYourFriendsWithoutApproval()
        {
            FriendsSteps.RemoveTestUser2FromTestUser1Profile();
            FriendsSteps.AddUserToFriends(TestUsers.TestUser2);

            this.friendsPage.NavigateTo();
            this.friendsPage.Validator.PendingFriendshipListExists();

            // Reverse to initial state (the two test users ARE friends)
            FriendsSteps.AcceptInvitationFromTestUser2Profile();
        }

        [TestMethod]
        [Priority(3)]
        public void RemovingAFriend_ShouldRemoveHimFromYourFriendsList()
        {
            FriendsSteps.RemoveTestUser2FromTestUser1Profile();
            this.friendsPage.NavigateTo();

            Manager.Current.ActiveBrowser.RefreshDomTree();
            this.friendsPage.Validator.UserHasNoFriends();

            // Reverse to initial state (the two test users ARE friends)
            FriendsSteps.AddUserToFriends(TestUsers.TestUser2);
            FriendsSteps.AcceptInvitationFromTestUser2Profile();
        }

        [TestMethod]
        [Priority(4)]
        public void SendMessageButtonOnAFriendsTile_ShouldNavigatesToTheCorrectPlace()
        {
            FriendsSteps.NavigateToTestUser1FriendsPage();

            this.friendsPage.Elements.SendMessageButton.Click();
            Manager.Current.ActiveBrowser.WaitUntilReady();

            this.messagesPage.Validator.MessagesOfTheCorrectUserHaveBeenSelected();
        }
    }
}
