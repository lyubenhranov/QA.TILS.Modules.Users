namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.Universities
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using QA.Framework.Core.Base;

    public class UniversitiesPageElements : BaseElementsMap
    {
        public HtmlAnchor AnchorAddNewTown
        {
            get
            {
                return
                    this.Find.ByXPath<HtmlAnchor>(
                        "//*[@id='DataGrid']/div[1]/a[2]");
            }
        }

        public HtmlInputText Name
        {
            get { return this.Find.ById<HtmlInputText>("Name"); }
        }

        public HtmlInputText Website
        {
            get { return this.Find.ById<HtmlInputText>("Website"); }
        }

        public HtmlInputText Order
        {
            get { return this.Find.ById<HtmlInputText>("Order"); }
        }

        public HtmlAnchor UpdateButton
        {
            get
            {
                return
                    this.Find.ByXPath<HtmlAnchor>(
                        "/html/body/div[3]/div[2]/div/div[7]/a[1]");
            }
        }

        public HtmlTable TheGrid
        {
            get
            {
                return this.Find.ByXPath<HtmlTable>("//*[@id='DataGrid']/table");
            }
        }

        public HtmlAnchor TheGridLastPAge
        {
            get { return this.Find.ByXPath<HtmlAnchor>("//*[@id='DataGrid']/div[2]/a[4]"); }
        }
    }
}
