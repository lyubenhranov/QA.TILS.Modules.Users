using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QA.TILS.Modules.Users.Core.Pages.AdminPage.AttendancesPage;
using QA.Framework.Core.Base;
using QA.Framework.Core.Data;

namespace QA.TILS.Modules.Users.Tests.Admin.Attendance
{
    [TestClass]
    public class AddAttendance : BaseTest
    {
        private AttendancesPage attendancesPage;

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
            this.attendancesPage = new AttendancesPage();

            this.attendancesPage.NavigateToPageAsAdmin();
        }

        [TestMethod]
        [Priority(2)]
        public void AddNewValidAttendance_ShouldAddItToTheDatabase()
        {
            string dateAndTimeOfAttendance = "10/10/2014 10:00:00";

            this.attendancesPage.AddAttendance(TestUsers.TestUser1, dateAndTimeOfAttendance);

            this.attendancesPage.Validator.VerifyIfDateExists("10/10/2014 - 10:00:00");

            this.attendancesPage.DeleteMostRecentAttendance(true);
        }
    }
}
