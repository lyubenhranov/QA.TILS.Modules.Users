namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.CommentsPage
{
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.Win32.Dialogs;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Data.Templates;
    using QA.TILS.Modules.Users.Core.SharedSteps;

    public class CommentsPage : BasePage
    {
        public CommentsPage()
        {
            this.Elements = new CommentsPageElements();
            this.Validator = new CommentsPageValidator(this);
            this.Url = @"/Administration_Users/Comments";
        }

        public CommentsPageElements Elements { get; private set; }

        public CommentsPageValidator Validator { get; private set; }

        public void WriteNewComment(User user, string comment, bool saveComment)
        {
            this.Elements.AddCommentButton.Wait.ForExists();
            this.Elements.AddCommentButton.Click();

            this.SetCommentsUser(user);

            this.Elements.Comment.Text = comment;
            this.Elements.Comment.AsjQueryControl().InvokejQueryEvent(ArtOfTest.WebAii.jQuery.jQueryControl.jQueryControlEvents.change);

            if (saveComment == true)
            {
                this.Elements.UpdateCommentButton.Click();
            }
            else
            {
                this.Elements.CancelCommentButton.Click();
            }
            
            Manager.Current.ActiveBrowser.RefreshDomTree();
        }

        public void DeleteMostRecentComment(bool confirmDeletion)
        {
            Manager.Current.ActiveBrowser.Refresh();
            AlertDialog alert;
            if (confirmDeletion)
            {
                alert = AlertDialog.CreateAlertDialog(Manager.Current.ActiveBrowser, DialogButton.OK);
            }
            else
            {
                alert = AlertDialog.CreateAlertDialog(Manager.Current.ActiveBrowser, DialogButton.CANCEL);
            }
            Manager.Current.DialogMonitor.AddDialog(alert);
            Manager.Current.DialogMonitor.Start();
            this.Elements.DeleteComment.Click();
            alert.WaitUntilHandled();
            Manager.Current.DialogMonitor.RemoveDialog(alert);
            Manager.Current.DialogMonitor.Stop();
        }

        public void EditCommentsText(string newComment, bool saveComment)
        {
            this.Elements.EditComment.Wait.ForExists();
            this.Elements.EditComment.Click();

            this.Elements.Comment.Text = newComment;
            this.Elements.Comment.AsjQueryControl().InvokejQueryEvent(ArtOfTest.WebAii.jQuery.jQueryControl.jQueryControlEvents.change);

            if (saveComment == true)
            {
                this.Elements.UpdateCommentButton.Click();
            }
            else
            {
                this.Elements.CancelCommentButton.Click();
            }
        }

        public void SetCommentsUser(User newUser)
        {
            this.Elements.User.Wait.ForExists();
            this.Elements.User.Text = newUser.Username;
            this.Elements.User.AsjQueryControl().InvokejQueryEvent(ArtOfTest.WebAii.jQuery.jQueryControl.jQueryControlEvents.change);
            this.Elements.User.MouseClick();
        }

        public void NavigateToPageAsAdmin()
        {
            LoginSteps.LoginAdmin();
            this.NavigateTo();
        }
    }
}
