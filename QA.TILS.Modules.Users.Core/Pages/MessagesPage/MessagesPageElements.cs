namespace QA.TILS.Modules.Users.Core.Pages.MessagesPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Extensions;

    public class MessagesPageElements : BaseElementsMap
    {
        public HtmlInputText SearchField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("inputQuery");
            }
        }

        public HtmlDiv FriendTile
        {
            get
            {
                return this.Find.ByAttributes<HtmlDiv>("friendInfo".ToClassContainsExpression());
            }
        }

        public HtmlDiv Messages
        {
            get
            {
                return this.Find.ByXPath<HtmlDiv>("//*[@id='messagesContainer']/div/div");
            }
        }

        public HtmlTextArea MessageToSendTextArea
        {
            get
            {
                return this.Find.ById<HtmlTextArea>("messageToSend");
            }
        }

        public HtmlDiv SendMessageButton
        {
            get
            {
                return this.Find.ById<HtmlDiv>("sendButton");
            }
        }
    }
}
