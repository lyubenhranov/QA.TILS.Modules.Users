namespace QA.TILS.Modules.Users.Core.SharedSteps
{
    using ArtOfTest.WebAii.Core;
    using QA.Framework.Core.Data;
    using QA.Framework.Core.Data.Templates;
    using QA.Framework.Core.Helpers;
    using QA.TILS.Modules.Users.Core.Pages.Common;
    using QA.TILS.Modules.Users.Core.Pages.FriendsPage;

    public static class FriendsSteps
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

        private static FriendsPage FriendsPage
        {
            get
            {
                return new FriendsPage();
            }
        }

        public static void RemoveUserFromFriends(User user)
        {
            NavigateTo.Url(user.ProfileUrl);
            UserProfilePage.UnfriendButton.Click();

            Manager.Current.ActiveBrowser.WaitUntilReady();
            Manager.Current.ActiveBrowser.Refresh();

            UserProfilePage.AddAsFriendButton.Wait.ForExists(10000);
        }

        public static void AddUserToFriends(User user)
        {
            NavigateTo.Url(user.ProfileUrl);
            UserProfilePage.AddAsFriendButton.Click();

            Manager.Current.ActiveBrowser.WaitUntilReady();
            Manager.Current.ActiveBrowser.Refresh();

            UserProfilePage.UnfriendButton.Wait.ForExists(10000);
        }

        public static void AcceptUserInvitation()
        {
            NavigateTo.Url("http://test.telerikacademy.com/");

            UserStartPage.UnacceptedInvitationsLink.Click();
            FriendsPage.Elements.AcceptFriendshipButton.Click();
        }

        public static void AcceptInvitationFromTestUser2Profile()
        {
            LoginSteps.LoginTestUser2();
            FriendsSteps.AcceptUserInvitation();
        }

        public static void RemoveTestUser2FromTestUser1Profile()
        {
            LoginSteps.LoginTestUser1();
            FriendsSteps.RemoveUserFromFriends(TestUsers.TestUser2);
        }

        public static void NavigateToTestUser1FriendsPage()
        {
            LoginSteps.LoginTestUser1();
            FriendsPage.NavigateTo();
        }

        public static void InitiateNewFriendshipBetweenTestUsersAndLoginUserWithPendingInvitation()
        {
            LoginSteps.LoginTestUser1();
            FriendsSteps.RemoveUserFromFriends(TestUsers.TestUser2);
            FriendsSteps.AddUserToFriends(TestUsers.TestUser2);

            LoginSteps.LoginTestUser2();
        }
    }
}
