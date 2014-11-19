namespace QA.TILS.Modules.Users.Core.SharedSteps
{
    using ArtOfTest.WebAii.Core;
    using QA.Framework.Core.Enumerations;
    using QA.Framework.Core.Extensions;
    using QA.Framework.Core.Helpers;
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using QA.TILS.Modules.Users.Core.Pages.AdminPage.CoursesPage;
    using QA.TILS.Modules.Users.Core.Pages.Common;
    using System;

    public static class CoursesSteps
    {
        public static string TestCourseName = "Users Module Testing Course";
        public static string TestInstanceName = "CloudberryTempTestInstance";
        public static string TestInstanceProfilePageUrl = String.Empty;
        public static string TestInstanceUnenrollPageUrl = String.Empty;

        private static CoursesPage CoursesPage
        {
            get
            {
                return new CoursesPage();
            }
        }

        private static CourseDialogElements CourseDialogElements
        {
            get
            {
                return new CourseDialogElements();
            }
        }

        private static CourseLoggedUserInstanceProfilePageElements InstanceProfilePageElements
        {
            get
            {
                return new CourseLoggedUserInstanceProfilePageElements();
            }
        }

        private static CourseLoggedUserInstanceUnenrollPageElements InstanceUnenrollPageElements
        {
            get
            {
                return new CourseLoggedUserInstanceUnenrollPageElements();
            }
        }

        private static void OpenTestCourseEditPage()
        {
            NavigateToCoursesAdminPage();
            CoursesPage.Elements.EditTestCourseButton.Click();
        }

        public static void OpenNewInstancePage()
        {
            NavigateToCoursesAdminPage();
            CoursesPage.Elements.CreateNewInstanceButton.Click();
        }

        private static void NavigateToCoursesAdminPage()
        {
            LoginSteps.LoginAdmin();
            NavigateTo.Page(CoursesPage);
        }

        public static void CreateNewCourseInstance()
        {
            OpenNewInstancePage();

            CourseDialogElements.CourseFieldName.TypeText(TestCourseName);
            CourseDialogElements.CourseFieldName.FireJQueryChangeEvent();

            CourseDialogElements.InstanceNameField.TypeText(TestInstanceName);
            CourseDialogElements.InstanceNameField.FireJQueryChangeEvent();

            string startDateAsString = DateTime.Now.ToString("dd/MM/yyyy").ToUpper();
            CourseDialogElements.StartDateField.TypeText(startDateAsString);
            CourseDialogElements.StartDateField.FireJQueryChangeEvent();

            string endDateAsString = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy").ToUpper();
            CourseDialogElements.EndDateField.TypeText(endDateAsString);
            CourseDialogElements.EndDateField.FireJQueryChangeEvent();

            CourseDialogElements.IsCourseActiveCheckbox.Check(true, true, true);
            CourseDialogElements.IsCourseActiveCheckbox.FireJQueryChangeEvent();

            CourseDialogElements.IsCoursePublicCheckbox.Check(true, true, true);
            CourseDialogElements.IsCoursePublicCheckbox.FireJQueryChangeEvent();

            CourseDialogElements.LecturesPerWeekIncreaseButton.MouseClickCustom();

            string applicationDeadlineAsString = endDateAsString + " 00:00:00";
            CourseDialogElements.ApplicationDeadlineField.TypeText(applicationDeadlineAsString);
            CourseDialogElements.ApplicationDeadlineField.FireJQueryChangeEvent();

            CourseDialogElements.OnsiteStudentsLimitIncreaseButton.MouseClickCustom();

            CourseDialogElements.OnlineStudentsLimitIncreaseButton.MouseClickCustom(); 

            CourseDialogElements.UpdateButton.FireJQueryClickEvent();

            SetInstanceUrlVariables();
        }

        public static void DeleteTheTestCourseInstance()
        {
            NavigateToCoursesAdminPage();

            CoursesPage.Elements.DeleteTestCourseButton.Click();
        }

        private static void SetInstanceUrlVariables()
        {
            LoginSteps.LoginAdmin();
            NavigateTo.Page(CoursesPage);

            SortCoursesByIdDescending();

            string testInstanceId = CoursesPage.Elements.TestInstanceIdCell.TextContent;

            TestInstanceProfilePageUrl = "http://test.telerikacademy.com/Courses/Courses/Details/" + testInstanceId;
            TestInstanceUnenrollPageUrl = "http://test.telerikacademy.com/Courses/Courses/UnenrollCourse/" + testInstanceId;
        }

        private static void SortCoursesByIdDescending()
        {
            CoursesPage.Elements.SortByIdColumn.Click();
            CoursesPage.Elements.SortByIdColumn.Click();
        }

        public static void ChangeTestCourseDates(DateTime startingDate)
        {
            string startDateAsString = startingDate.ToString("dd/MM/yyyy").ToUpper();
            string endDateAsString = startingDate.AddDays(1).ToString("dd/MM/yyyy").ToUpper();
            string applicationDeadlineAsString = endDateAsString + " 00:00:00";

            OpenTestCourseEditPage();

            CourseDialogElements.StartDateField.ReplaceTextWith(startDateAsString);
            CourseDialogElements.StartDateField.FireJQueryChangeEvent();

            CourseDialogElements.EndDateField.ReplaceTextWith(endDateAsString);
            CourseDialogElements.EndDateField.FireJQueryChangeEvent();

            CourseDialogElements.ApplicationDeadlineField.ReplaceTextWith(applicationDeadlineAsString);
            CourseDialogElements.ApplicationDeadlineField.FireJQueryChangeEvent();

            CourseDialogElements.UpdateButton.FireJQueryClickEvent();
        }

        public static void ChangeStudentsLimits(string onsiteStudentsCount, string onlineStudentsCount)
        {
            //TODO: Fix value input for the Kendo Fields
            OpenTestCourseEditPage();

            if (onsiteStudentsCount != null)
            {             
                CourseDialogElements.OnsiteStudentsLimitField.Value = onsiteStudentsCount;
                CourseDialogElements.OnsiteStudentsLimitField.FireJQueryChangeEvent();
            }

            if (onlineStudentsCount != null)
            {
                CourseDialogElements.OnlineStudentsLimitField.Value = onlineStudentsCount;
                CourseDialogElements.OnlineStudentsLimitField.FireJQueryChangeEvent();                
            }

            CourseDialogElements.UpdateButton.FireJQueryClickEvent();
        }

        public static void EnrollTestUserForCourse(CourseAttendanceType attendanceType)
        {            
            LoginSteps.LoginTestUser1();

            NavigateTo.Url(TestInstanceProfilePageUrl);

            if (attendanceType.ToString() == "Online")
            {
                InstanceProfilePageElements.ApplyOnlineButton.Click();
                InstanceProfilePageElements.SuccessfullyEnrolledOnlineMessage.Wait.ForExists(2000);
            }
            else
            {
                InstanceProfilePageElements.ApplyOnsiteButton.Click();
                InstanceProfilePageElements.SuccessfullyEnrolledOnsiteMessage.Wait.ForExists(2000);
            }
        }

        public static void ChangeCourseAttendance(CourseAttendanceType attendanceType)
        {
            NavigateTo.Url(TestInstanceProfilePageUrl);

            if (attendanceType.ToString() == "Online")
            {
                InstanceProfilePageElements.ChangeAttendanceToOnlineButton.Click();
                InstanceProfilePageElements.SuccessfullyChangedAttendanceToOnlineMessage.Wait.ForExists(2000);
            }
            else
            {
                InstanceProfilePageElements.ChangeAttendanceToOnsiteButton.Click();
                InstanceProfilePageElements.SuccessfullyChangedAttendanceToOnsiteMessage.Wait.ForExists(2000);
            }
        }

        public static void RemoveTestInstanceFromLoggedUser()
        {
            NavigateTo.Url(TestInstanceUnenrollPageUrl);
            InstanceUnenrollPageElements.UnenrollCourseButton.Click();

            var answersToQuestions = Manager.Current.ActiveBrowser.Find.AllByXPath<HtmlInputCheckBox>("//input[@type='radio']");

            foreach (var answer in answersToQuestions)
            {
                answer.Check(true, true);
            }

            Manager.Current.ActiveBrowser.WaitForUrl("http://test.telerikacademy.com/Courses/Courses/UnenrollCourseSuccess", false, 5000);
        }

        public static void EnrollCourseAndChangeAttendanceTypeForTestUser(CourseAttendanceType enrolledCourseType)
        {
            CoursesSteps.EnrollTestUserForCourse(enrolledCourseType);

            if (enrolledCourseType == CourseAttendanceType.Online)
            {
                CoursesSteps.ChangeCourseAttendance(CourseAttendanceType.Onsite);
            }
            else
            {
                CoursesSteps.ChangeCourseAttendance(CourseAttendanceType.Online);
            }
            
        }
    }
}