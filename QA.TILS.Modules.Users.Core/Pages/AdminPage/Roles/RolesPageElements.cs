namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.Roles
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using QA.Framework.Core.Base;

    public class RolesPageElements : BaseElementsMap
    {
        public HtmlAnchor AnchorAddNewRole
        {
            get
            {
                return this.Find.ByXPath<HtmlAnchor>("//*[@id='DataGrid']/div[1]/a[2]");
            }
        }

        public HtmlInputText Name
        {
            get { return this.Find.ById<HtmlInputText>("Name"); }
        }
        
        public HtmlAnchor UpdateButton
        {
            get
            {
                return this.Find.ByXPath<HtmlAnchor>("/html/body/div[3]/div[2]/div/div[3]/a[1]");
            }
        }

        public HtmlTable TheGrid
        {
            get
            {
                return this.Find.ByXPath<HtmlTable>("//*[@id='DataGrid']/table");
            }
        }
    }
}
