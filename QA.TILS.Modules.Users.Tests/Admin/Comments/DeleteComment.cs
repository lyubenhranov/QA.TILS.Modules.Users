namespace QA.TILS.Modules.Users.Tests.Functional.Admin.Comments
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Data;
    using QA.Framework.Core.Helpers;
    using QA.TILS.Modules.Users.Core.Pages.AdminPage.CommentsPage;

    [TestClass]
    public class DeleteComment : BaseTest
    {
        private CommentsPage commentsPage;

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
            this.commentsPage = new CommentsPage();
            this.commentsPage.NavigateToPageAsAdmin();
        }

        [TestMethod]
        [Priority(2)]
        public void DeletingComment_ShouldRemoveItFromTheDatabase()
        {
            var comment = RandomDataGenerator.GenerateUniqueRandomString();

            this.commentsPage.WriteNewComment(TestUsers.TestUser1, comment, true);
            this.commentsPage.Validator.VerifyCommentsTextExists(comment);

            this.commentsPage.DeleteMostRecentComment(true);
            this.commentsPage.Validator.VerifyCommentDoesNotExist(comment);
        }

        [TestMethod]
        [Priority(3)]
        public void CancelDeletionOfComment_ShouldNotDeleteTheCommentFromTheDatabase()
        {
            var comment = RandomDataGenerator.GenerateUniqueRandomString();

            this.commentsPage.WriteNewComment(TestUsers.TestUser1, comment, true);
            this.commentsPage.Validator.VerifyCommentsTextExists(comment);

            this.commentsPage.DeleteMostRecentComment(false);
            this.commentsPage.Validator.VerifyCommentsTextExists(comment);
        }
    }
}
