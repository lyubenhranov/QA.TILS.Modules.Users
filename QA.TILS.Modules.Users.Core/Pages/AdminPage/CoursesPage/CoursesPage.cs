namespace QA.TILS.Modules.Users.Core.Pages.AdminPage.CoursesPage
{
    using QA.Framework.Core.Base;

    public class CoursesPage : BasePage
    {
        public CoursesPage()
        {
            this.Elements = new CoursesPageElements();
            this.Validator = new CoursesPageValidator();
            this.Url = "/Administration_Courses/CoursesInstancesAndLectures";
        }

        public CoursesPageElements Elements { get; set; }

        public CoursesPageValidator Validator { get; set; }
    }

}
