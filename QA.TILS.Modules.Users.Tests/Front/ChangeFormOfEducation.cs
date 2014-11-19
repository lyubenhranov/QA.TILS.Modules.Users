namespace QA.TILS.Modules.Users.Tests.Functional.Front
{
    using ArtOfTest.WebAii.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Base;
    using QA.TILS.Modules.Users.Core.SharedSteps;
    using QA.TILS.Modules.Users.Core.Pages.AdminPage.CoursesPage;
    using QA.Framework.Core.Enumerations;
    using QA.TILS.Modules.Users.Core.Pages.Common;
    using ArtOfTest.WebAii.Win32.Dialogs;

    /// <summary>
    /// The pre-conditions of any test are
    /// --> the test course is starting today and ending tomorrow
    /// --> the course has a limit of both online and onsite students of 1
    /// --> the test user is NOT enrolled into the course
    /// --> the test user does NOT have ANY courses enrolled
    /// </summary>
    [TestClass]
    public class ChangeFormOfEducation : BaseTest
    {
        private CoursesPage coursesPage;
        private LoggedUserStartPageElements startPageElements;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            BaseClassInitialize();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            BaseClassCleanup();
        }

        public override void TestInitialize()
        {
            this.coursesPage = new CoursesPage();
            this.startPageElements = new LoggedUserStartPageElements();

            Manager.Current.DialogMonitor.AddDialog(new AlertDialog(Manager.Current.ActiveBrowser, DialogButton.OK));
            Manager.Current.DialogMonitor.Start();

            CoursesSteps.CreateNewCourseInstance();
        }

        public override void TestCleanUp()
        {
            CoursesSteps.RemoveTestInstanceFromLoggedUser();
            CoursesSteps.DeleteTheTestCourseInstance();
        }

        [TestMethod]
        [Priority(2)]
        public void ChangingToOnlineAttendance_ShouldBeReflectedCorrectly()
        {
            CoursesSteps.EnrollCourseAndChangeAttendanceTypeForTestUser(CourseAttendanceType.Onsite);
        }

        [TestMethod]
        [Priority(2)]
        public void ChangingToOnsiteAttendance_ShouldBeReflectedCorrectly()
        {
            CoursesSteps.EnrollCourseAndChangeAttendanceTypeForTestUser(CourseAttendanceType.Online);
        }
    }
}
