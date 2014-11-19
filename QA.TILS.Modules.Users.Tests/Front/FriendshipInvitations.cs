namespace QA.TILS.Modules.Users.Tests.Functional.Front
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.TILS.Modules.Users.Core.Pages.Common;
    using QA.TILS.Modules.Users.Core.Pages.FriendsPage;
    using QA.TILS.Modules.Users.Core.SharedSteps;

    /// <summary>
    /// The initial state that must serve as a precondition for all of the tests below is 
    /// that TestUser1 and TestUser 2 are friends
    /// </summary>
    [TestClass]
    public class FriendshipInvitations : BaseTest
    {
        private FriendsPage friendsPage;
        private LoggedUserStartPageElements userStartPage;

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
            this.userStartPage = new LoggedUserStartPageElements();
        }

        [TestMethod]
        [Priority(1)]
        public void InvitationSent_ShouldBeReceivedByTheCorrectUser()
        {
            FriendsSteps.InitiateNewFriendshipBetweenTestUsersAndLoginUserWithPendingInvitation();

            CommonPagesValidator.StartPageUnacceptedFriendshipInvitationExists();

            // Reverse to initial state (the two test users ARE friends)
            FriendsSteps.AcceptUserInvitation();
        }

        [TestMethod]
        [Priority(4)]
        public void RequestNotificationReceived_ShouldDisappearAfterFriendshipApproval()
        {
            FriendsSteps.InitiateNewFriendshipBetweenTestUsersAndLoginUserWithPendingInvitation();

            CommonPagesValidator.StartPageUnacceptedFriendshipInvitationExists();

            FriendsSteps.AcceptUserInvitation();
            this.Browser.Refresh();
            
            CommonPagesValidator.StartPageUnacceptedFriendshipInvitationDoesNotExist();
        }

        [TestMethod]
        [Priority(4)]
        public void InvitationNotificationLink_ShouldNavigateToTheCorrectPlace()
        {
            FriendsSteps.InitiateNewFriendshipBetweenTestUsersAndLoginUserWithPendingInvitation();

            this.userStartPage.UnacceptedInvitationsLink.Click();
            this.Browser.WaitUntilReady();

            CommonPagesValidator.AssertCorrectPageHasBeenLoaded(this.friendsPage.Url, this.Browser.Url);

            // Reverse to initial state (the two test users ARE friends)
            FriendsSteps.AcceptUserInvitation();
        }
    }
}
