namespace QA.TILS.Modules.Users.Tests.Functional.Admin.Comments
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Data;
    using QA.Framework.Core.Helpers;
    using QA.TILS.Modules.Users.Core.Pages.AdminPage.CommentsPage;

    [TestClass]
    public class AddComment : BaseTest
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
        public void AddingANewComment_ShouldSaveItToTheDatabase()
        {
            var comment = RandomDataGenerator.GenerateUniqueRandomString();

            this.commentsPage.WriteNewComment(TestUsers.TestUser1, comment, true);
            
            this.commentsPage.Validator.VerifyCommentsTextExists(comment);
            this.commentsPage.DeleteMostRecentComment(true);
        }

        [TestMethod]
        [Priority(4)]
        public void AddingACommentWithWrongUsername_ShouldNotBeAllowed()
        {
            var comment = RandomDataGenerator.GenerateUniqueRandomString();

            this.commentsPage.WriteNewComment(TestUsers.NotExistingUser, comment, true);
            this.commentsPage.Validator.VerifyWrongUsernameMessage();
        }

        [TestMethod]
        [Priority(4)]
        public void AddingACommentWithoutText_ShouldNotBeAllowed()
        {
            var comment = string.Empty;

            this.commentsPage.WriteNewComment(TestUsers.TestUser1, comment, true);
            this.commentsPage.Validator.VerifyNoCommentTextMessage();
        }

        [TestMethod]
        [Priority(3)]
        public void CancellingANewCommentCreation_ShouldNotSaveItToTheDatabase()
        {
            var comment = RandomDataGenerator.GenerateUniqueRandomString();

            this.commentsPage.WriteNewComment(TestUsers.TestUser1, comment, false);
            this.commentsPage.Validator.VerifyCommentDoesNotExist(comment);
        }

    }
}
