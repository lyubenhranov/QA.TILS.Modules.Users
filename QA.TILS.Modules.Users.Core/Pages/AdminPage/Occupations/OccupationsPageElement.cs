namespace QA.TILS.Modules.Users.Core.Pages.OccupationsPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Extensions;

    public class OccupationsPageElements : BaseElementsMap
    {
        public HtmlAnchor AddNewOccupation
        {
            get
            {
                return this.Find.ByXPath<HtmlAnchor>("//*[@id='DataGrid']/div[1]/a[2]");
            }
        }

        public HtmlAnchor UpdateNewOccupation
        {
            get
            {
                return this.Find.ByXPath<HtmlAnchor>("/html/body/div[3]/div[2]/div/div[3]/a[1]");
            }
        }

        public HtmlAnchor CancelNewOccupation
        {
            get
            {
                return this.Find.ByXPath<HtmlAnchor>("/html/body/div[3]/div[2]/div/div[3]/a[2]");
            }
        }

        public HtmlAnchor EditOccupation
        {
            get
            {
                return this.Find.ByXPath<HtmlAnchor>("//*[@id='DataGrid']/table/tbody/tr[1]/td[3]/a");
            }
        }

        public HtmlAnchor DeleteOccupation
        {
            get
            {
                return this.Find.ByXPath<HtmlAnchor>("//*[@id='DataGrid']/table/tbody/tr[1]/td[4]/a");
            }
        }

        public HtmlInputText TypeNameOfOccupation
        {
            get
            {
                return this.Find.ById<HtmlInputText>("Name");
            }
        }
    }
}
