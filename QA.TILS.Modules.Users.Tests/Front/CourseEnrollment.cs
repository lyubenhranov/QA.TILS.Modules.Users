namespace QA.TILS.Modules.Users.Tests.Functional.Front
{
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.Win32.Dialogs;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Attributes;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Enumerations;
    using QA.Framework.Core.Helpers;
    using QA.TILS.Modules.Users.Core.Pages.Common;
    using QA.TILS.Modules.Users.Core.SharedSteps;

    /// <summary>
    /// The pre-conditions of any test are
    /// --> the test course is starting today and ending tomorrow
    /// --> the course has a limit of both online and onsite students of 1
    /// --> the test user is NOT enrolled into the course
    /// --> the test user does NOT have ANY courses enrolled
    /// </summary>
    [TestClass]
    public class CourseEnrollment : BaseTest
    {
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
            Manager.Current.DialogMonitor.AddDialog(new AlertDialog(Manager.Current.ActiveBrowser, DialogButton.OK));
            Manager.Current.DialogMonitor.Start();

            CoursesSteps.TestCourseName = "CloudberryTempCourse";
            CoursesSteps.TestInstanceName = RandomDataGenerator.GenerateRandomString(8, 15);

            CoursesSteps.CreateNewCourseInstance();
        }

        [BugReported("2253")]
        public override void TestCleanUp()
        {
            CoursesSteps.RemoveTestInstanceFromLoggedUser();
            CoursesSteps.DeleteTheTestCourseInstance();
        }

        [TestMethod]
        [Priority(1)]
        [BugReported("2253")]
        public void EnrollingOnsite_ShouldAddTheCourseToYourCourses()
        {
            CoursesSteps.EnrollTestUserForCourse(CourseAttendanceType.Onsite);
            CommonPagesValidator.CoursesAssertCoursesMenuIsPresent();
        }

        [TestMethod]
        [Priority(1)]
        [BugReported("2253")]
        public void EnrollingOnline_ShouldAddTheCourseToYourCourses()
        {
            CoursesSteps.EnrollTestUserForCourse(CourseAttendanceType.Online);
            CommonPagesValidator.CoursesAssertCoursesMenuIsPresent();
        }
    }
}
