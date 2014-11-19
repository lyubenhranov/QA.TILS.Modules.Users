namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.CommentsPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using QA.Framework.Core.Base;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CommentsPageElements : BaseElementsMap
    {
        public HtmlDiv AllCommentsGrid
        {
            get
            {
                return this.Find.ById<HtmlDiv>("DataGrid");
            }
        }

        public HtmlAnchor AddCommentButton
        {
            get
            {
                return this.Find.ByExpression<HtmlAnchor>("tagname=a", "class=k-button k-button-icontext k-grid-add");
            }
        }

        public HtmlAnchor EditComment
        {
            get
            {
                return this.Find.ByExpression<HtmlAnchor>("xpath=//*[@id='DataGrid']/table/tbody/tr/td[6]/a");
            }
        }

        public HtmlSpan DeleteComment
        {
            get
            {
                return this.Find.ByExpression<HtmlSpan>("xpath=//*[@id='DataGrid']/table/tbody/tr[2]/td[7]/a/span");
            }
        }

        public HtmlDiv CommentWindow
        {
            get
            {
                return this.Find.ByExpression<HtmlDiv>("tagname=div", "class=k-widget k-window");
            }
        }

        public HtmlInputText User
        {
            get
            {
                return this.Find.ById<HtmlInputText>("ReceiverUsername");
            }
        }

        public HtmlTextArea Comment
        {
            get
            {
                return this.Find.ById<HtmlTextArea>("Text");
            }
        }

        public HtmlAnchor UpdateCommentButton
        {
            get
            {
                return this.Find.ByExpression<HtmlAnchor>("tagname=a", "class=k-button k-button-icontext k-grid-update");
            }
        }

        public HtmlDiv WrongUsernameMessage
        {
            get
            {
                return this.Find.ById<HtmlDiv>("ReceiverUsername_validationMessage");
            }
        }

        public HtmlDiv NoCommentTextMessage
        {
            get
            {
                return this.Find.ById<HtmlDiv>("Text_validationMessage");
            }
        }

        public HtmlAnchor CancelCommentButton
        {
            get
            {
                return this.Find.ByExpression<HtmlAnchor>("tagname=a", "class=k-button k-button-icontext k-grid-cancel");
            }
        }
    }
}
