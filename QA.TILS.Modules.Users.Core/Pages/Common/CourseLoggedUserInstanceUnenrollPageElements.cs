namespace QA.TILS.Modules.Users.Core.Pages.Common
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using QA.Framework.Core.Base;

    public class CourseLoggedUserInstanceUnenrollPageElements : BaseElementsMap
    {
        public HtmlInputSubmit UnenrollCourseButton
        {
            get
            {
                return this.Find.ByXPath<HtmlInputSubmit>("//input[@value = 'Отпиши се от курса']");
            }
        }
    }
}
