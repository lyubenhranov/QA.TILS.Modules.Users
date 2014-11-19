namespace QA.TILS.Modules.Users.Core.Pages.FriendsPage
{
    public class FriendsPageValidator
    {
        private FriendsPage friendsPage = new FriendsPage();

        public void RemoveFriendsNotificationExists()
        {
            this.friendsPage.Elements.RemoveFriendshipConfirmation.Wait.ForExists(5000);
        }

        public void PendingFriendshipListExists()
        {
              this.friendsPage.Elements.SentInvitationsList.Wait.ForExists(5000);
        }

        public void UserHasNoFriends()
        {
            this.friendsPage.Elements.NoFriendsMessage.Wait.ForExists(5000);
        }
    }
}
