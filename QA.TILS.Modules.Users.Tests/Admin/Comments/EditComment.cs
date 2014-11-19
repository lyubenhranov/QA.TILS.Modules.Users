namespace QA.TILS.Modules.Users.Tests.Functional.Admin.Comments
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Data;
    using QA.Framework.Core.Helpers;
    using QA.TILS.Modules.Users.Core.Pages.AdminPage.CommentsPage;

    [TestClass]
    public class EditComment : BaseTest
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
        public void ChangingCommentWithValidText_ShouldBeReflectedInTheDatabase()
        {
            var comment = RandomDataGenerator.GenerateUniqueRandomString();

            this.commentsPage.EditCommentsText(comment, true);
            this.commentsPage.Validator.VerifyCommentsTextExists(comment);
        }

        [TestMethod]
        [Priority(3)]
        public void CancellingChangesOnExistingComment_ShouldNotBeReflectedInTheDatabase()
        {
            var comment = RandomDataGenerator.GenerateUniqueRandomString();

            this.commentsPage.EditCommentsText(comment, false);
            this.commentsPage.Validator.VerifyCommentDoesNotExist(comment);
        }

        [TestMethod]
        [Priority(3)]
        public void ChangingTheUserOfAnExistingCommentWithAnotherValidUser_ShouldBeAllowed()
        {
            this.commentsPage.Elements.EditComment.Click();
            this.commentsPage.SetCommentsUser(TestUsers.TestUser2);

            this.commentsPage.Elements.UpdateCommentButton.Click();
            this.commentsPage.Validator.VerifyCommentsTextExists(TestUsers.TestUser2.Username);
        }

        [TestMethod]
        [Priority(3)]
        public void ChangingTheUserOfAnExistingCommentWithAnInvalidUser_ShouldNotBeAllowed()
        {
            this.commentsPage.Elements.EditComment.Click();
            this.commentsPage.SetCommentsUser(TestUsers.NotExistingUser);

            this.commentsPage.Elements.UpdateCommentButton.Click();
            this.commentsPage.Validator.VerifyWrongUsernameMessage();
        }

        [TestMethod]
        [Priority(2)]
        public void ErasingTheTextFromAnExistingComment_ShouldNotBeAllowed()
        {
            var comment = string.Empty;

            this.commentsPage.EditCommentsText(comment, true);
            this.commentsPage.Validator.VerifyNoCommentTextMessage();
        }
    }
}
