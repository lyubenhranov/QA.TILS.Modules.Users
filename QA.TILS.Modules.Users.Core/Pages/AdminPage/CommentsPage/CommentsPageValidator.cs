namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.CommentsPage
{
    using QA.Framework.Core.Data.Templates;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using QA.Framework.Core.Extensions;
    using ArtOfTest.WebAii.Core;

    public class CommentsPageValidator
    {
        public CommentsPageValidator(CommentsPage initialCommentsPage)
        {
            this.CommentsPage = initialCommentsPage;
        }

        public CommentsPage CommentsPage { get; set; }

        public void VerifyCommentsTextExists(string comment)
        {            
            Manager.Current.ActiveBrowser.Refresh();
            this.CommentsPage.Elements.AllCommentsGrid.AssertTextIsContained(comment);
        }

        public void VerifyCommentDoesNotExist(string comment)
        {
            Manager.Current.ActiveBrowser.Refresh();
            this.CommentsPage.Elements.AllCommentsGrid.AssertTextIsNotContained(comment);
        }

        public void VerifyWrongUsernameMessage()
        {
            this.CommentsPage.Elements.WrongUsernameMessage.Wait.ForExists();
            this.CommentsPage.Elements.WrongUsernameMessage.AssertIsPresent();
        }

        public void VerifyNoCommentTextMessage()
        {         
            Manager.Current.ActiveBrowser.RefreshDomTree();
            this.CommentsPage.Elements.NoCommentTextMessage.Wait.ForExists();
            this.CommentsPage.Elements.WrongUsernameMessage.AssertIsNotPresent();
        }
    }
}
