namespace QA.TILS.Modules.Users.Core.Pages.Common
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using QA.Framework.Core.Base;
    using QA.TILS.Modules.Users.Core.SharedSteps;

    public class MaterialsMistakeReportsPageElements : BaseElementsMap
    {
        public HtmlTableCell TestReportLectureNameCell
        {
            get
            {
                return this.Find.ByXPath<HtmlTableCell>("//*[@id='DataGrid']/table/tbody/tr[td/a/. ='" + CoursesSteps.TestInstanceName + "']/td[3]");
            }
        }

        public HtmlTableCell TestReportResourceNameCell
        {
            get
            {
                return this.Find.ByXPath<HtmlTableCell>("//*[@id='DataGrid']/table/tbody/tr[td/a/. ='" + CoursesSteps.TestInstanceName + "']/td[4]");
            }
        }

        public HtmlTableCell TestReportErrorLocationCell
        {
            get
            {
                return this.Find.ByXPath<HtmlTableCell>("//*[@id='DataGrid']/table/tbody/tr[td/a/. ='" + CoursesSteps.TestInstanceName + "']/td[5]");
            }
        }

        public HtmlTableCell TestReportErrorDescriptionCell
        {
            get
            {
                return this.Find.ByXPath<HtmlTableCell>("//*[@id='DataGrid']/table/tbody/tr[td/a/. ='" + CoursesSteps.TestInstanceName + "']/td[6]");
            }
        }

        public HtmlAnchor DeleteErrorReportButton
        {
            get
            {
                return this.Find.ByXPath<HtmlAnchor>("//*[@id='DataGrid']/table/tbody/tr[td/a/. ='" + CoursesSteps.TestInstanceName + "']/td[11]/a");
            }
        }
    }
}
