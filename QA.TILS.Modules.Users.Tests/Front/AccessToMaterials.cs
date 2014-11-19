namespace QA.TILS.Modules.Users.Tests.Functional.Front
{
    using ArtOfTest.WebAii.Core;
    using ArtOfTest.WebAii.Win32.Dialogs;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Attributes;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Helpers;
    using QA.TILS.Modules.Users.Core.Pages.Common;
    using QA.TILS.Modules.Users.Core.SharedSteps;

    /// <summary>
    /// All tests are performed with Test User 2, who is enrolled to the course "AccessToMaterialsTestsCourse"
    /// The course has only one material, which is known to the testing team. There should be NO error reports for
    /// the test lecture in the database.
    /// </summary>
    [TestClass]
    public class AccessToMaterials : BaseTest
    {
        private const string TestInstanceProfilePageUrl = "/Courses/Courses/Details/91";
        private const string TestLectureMaterialLink = "http://youtube.com";
        private const string TestMaterialName = "Introduction Video";
        private const string TestLectureName = "Introduction";
        private const int TestMaterialsCount = 1;

        private CourseLoggedUserInstanceProfilePageElements CourseProfilePageElements;

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

            CoursesSteps.TestInstanceName = "AccessToMaterialsTestsCourse";
            this.CourseProfilePageElements = new CourseLoggedUserInstanceProfilePageElements();
        }

        [TestMethod]
        [Priority(2)]
        public void CreatingAnIssueReport_ShouldBeCorrectlySavedInTheDatabase()
        {
            string errorLocationText = RandomDataGenerator.GenerateRandomString(5, 10);
            string errorDescriptionText = RandomDataGenerator.GenerateRandomString(21, 30);

            AccessToLectureMaterialsSteps.LoginTestUser();

            AccessToLectureMaterialsSteps.SendMaterialErrorReportFromLoggedUser(TestInstanceProfilePageUrl, TestMaterialName, errorLocationText, errorDescriptionText);

            CommonPagesValidator.AssertErrorReportHasBeenSavedCorrectly(TestLectureName, TestMaterialName, errorLocationText, errorDescriptionText);

            //Delete the created test report in order to bring back the DB to the preconditioned state
            AccessToLectureMaterialsSteps.DeleteTestErrorReport();
        }

        [TestMethod]
        [Priority(2)]
        public void MaterialsDownloadLinks_ShouldPointToCorrectLocation()
        {
            AccessToLectureMaterialsSteps.NavigateToTestCoursePage(TestInstanceProfilePageUrl);

            CommonPagesValidator.MaterialsAssertMaterialLinkPointsToTheCorrectLocation(TestLectureMaterialLink, this.CourseProfilePageElements.MaterialLink.HRef);
        }

        [TestMethod]
        [Priority(2)]
        public void ReportingIssueForm_ShouldIncludeAllOfTheMaterialsForTheLecture()
        {
            AccessToLectureMaterialsSteps.NavigateToTestCoursePage(TestInstanceProfilePageUrl);

            this.CourseProfilePageElements.MaterialLink.Wait.ForExists(5000);

            CommonPagesValidator.MaterialsAssertNumberOfMaterialsToReport(TestInstanceProfilePageUrl, TestMaterialsCount);
        }

        [TestMethod]
        [Priority(1)]
        public void AllUploadedMaterials_ShouldBeVisibleOnTheCoursePage()
        {
            AccessToLectureMaterialsSteps.NavigateToTestCoursePage(TestInstanceProfilePageUrl);

            this.CourseProfilePageElements.MaterialLink.Wait.ForExists(5000);

            CommonPagesValidator.MaterialsAssertAllMaterialsForALectureArePresent(TestLectureName, new string[] {TestMaterialName});
        }
    }
}
