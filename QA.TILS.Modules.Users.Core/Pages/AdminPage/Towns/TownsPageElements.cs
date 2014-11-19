namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.Towns
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using QA.Framework.Core.Base;

    public class TownsPageElements : BaseElementsMap
    {
        public HtmlAnchor AnchorAddNewTown
        {
            get
            {
                return
                    this.Find.ByXPath<HtmlAnchor>(
                        "//a[@href='/Administration_Users/Provinces/Read?DataGrid-mode=insert']");
            }
        }

        public HtmlInputText NameEnglish
        {
            get { return this.Find.ById<HtmlInputText>("NameEn"); }
        }

        public HtmlInputText NameBulgarian
        {
            get { return this.Find.ById<HtmlInputText>("NameBg"); }
        }


        public HtmlAnchor UpdateButton
        {
            get
            {
                return this.Find.ByXPath<HtmlAnchor>("/html/body/div[3]/div[2]/div/div[5]/a[1]");
            }
        }

        public HtmlDiv EnglishNameValidationMessage
        {
            get
            {
                return this.Find.ById<HtmlDiv>("NameEn_validationMessage");
            }
        }

        public HtmlDiv BulgarianNameValidationMessage
        {
            get
            {
                return this.Find.ById<HtmlDiv>("NameBg_validationMessage");
            }
        }

        public HtmlAnchor DeleteButton
        {
            get
            {
                return this.Find.ByXPath<HtmlAnchor>("//*[@id='DataGrid']/table/tbody/tr[3]/td[6]/a");
            }
        }

        public HtmlTable TheGid
        {
            get
            {
                return this.Find.ByXPath<HtmlTable>("//*[@id='DataGrid']/table");
            }
        }
    }
}
