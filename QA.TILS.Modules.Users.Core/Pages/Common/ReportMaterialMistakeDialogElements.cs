namespace QA.TILS.Modules.Users.Core.Pages.Common
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using QA.Framework.Core.Base;

    public class ReportMaterialMistakeDialogElements : BaseElementsMap
    {
        public HtmlUnorderedList ResourcesToReportList
        {
            get
            {
                return this.Find.ById<HtmlUnorderedList>("LectureResourceId_listbox");
            }
        }

        public HtmlSpan SelectedMaterialSpan
        {
            get
            {
                return this.Find.ByXPath<HtmlSpan>("//span[@class='k-input']");
            }
        }

        public HtmlSpan ExpandMaterialsArrow
        {
            get
            {
                return this.Find.ById<HtmlForm>("report-bug-form").Find.ByXPath<HtmlSpan>("//span[@class = 'k-icon k-i-arrow-s']");
            }
        }

        public HtmlInputText ErrorLocationField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("Location");
            }
        }

        public HtmlTextArea ErrorDescriptionField
        {
            get
            {
                return this.Find.ById<HtmlTextArea>("Description");
            }
        }

        public HtmlInputSubmit SubmitReportButton
        {
            get
            {
                return this.Find.ById<HtmlInputSubmit>("resource-bug-report-ok-button");
            }
        }

        public HtmlInputSubmit CancelReportButton
        {
            get
            {
                return this.Find.ById<HtmlInputSubmit>("resource-bug-report-cancel-button");
            }
        }
    }
}
