namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.CoursesPage
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Extensions;
    using QA.TILS.Modules.Users.Core.SharedSteps;

    public class CoursesPageElements : BaseElementsMap
    {
        public HtmlAnchor EditTestCourseButton
        {
            get
            {
                return this.Find.ByXPath<HtmlAnchor>("//*[@id='DataGrid']/table/tbody/tr[td/a/. ='" + CoursesSteps.TestInstanceName + "']/td[16]/a");
            }
        }

        public HtmlAnchor DeleteTestCourseButton
        {
            get
            {
                return this.Find.ByXPath<HtmlAnchor>("//*[@id='DataGrid']/table/tbody/tr[td/a/. ='" + CoursesSteps.TestInstanceName + "']/td[17]/a");
            }
        }

        public HtmlAnchor CreateNewInstanceButton
        {
            get
            {
                return this.Find.ByXPath<HtmlAnchor>("//a[. = 'Създаване на нова инстанция']");
            }
        }

        public HtmlTableCell TestInstanceIdCell
        {
            get
            {
                return this.Find.ByXPath<HtmlTableCell>("//*[@id='DataGrid']/table/tbody/tr[td/a/. ='" + CoursesSteps.TestInstanceName + "']/td[2]");
            }
        }

        public HtmlAnchor SortByIdColumn
        {
            get
            {
                return this.Find.ByXPath<HtmlAnchor>("//a[. = '№']");
            }
        }
    }
}
