namespace QA.TILS.Modules.Users.Core.SharedSteps
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Extensions;
    using QA.Framework.Core.Helpers;
    using QA.TILS.Modules.Users.Core.Pages.Common;
    using System;

    public static class AccessToLectureMaterialsSteps
    {
        private static string MaterialsMistakeReportsPageUrl 
        {
            get
            {
                return "http://test.telerikacademy.com/Administration_Courses/LectureResourceBugReports";
            }
        }

        private static CourseLoggedUserInstanceProfilePageElements InstanceProfilePageElements
        {
            get
            {
                return new CourseLoggedUserInstanceProfilePageElements();
            }
        }

        private static ReportMaterialMistakeDialogElements ReportMaterialErrorDialogElements
        {
            get
            {
                return new ReportMaterialMistakeDialogElements();
            }
        }

        private static MaterialsMistakeReportsPageElements MaterialsMistakeReportsPageElements
        {
            get
            {
                return new MaterialsMistakeReportsPageElements();
            }
        }

        public static void SendMaterialErrorReportFromLoggedUser(string courseProfilePageUrl, string materialName, string errorLocation, string errorDescription)
        {
            NavigateTo.Url(courseProfilePageUrl);
            InstanceProfilePageElements.ReportMistakeButton.Click();
            ReportMaterialErrorDialogElements.ExpandMaterialsArrow.Wait.ForExists(5000);

            ReportMaterialErrorDialogElements.ExpandMaterialsArrow.FireJQueryClickEvent();
            ReportMaterialErrorDialogElements.ResourcesToReportList.AllItems[1].FireJQueryClickEvent();

            ReportMaterialErrorDialogElements.ErrorLocationField.Value = errorLocation;
            ReportMaterialErrorDialogElements.ErrorLocationField.FireJQueryChangeEvent();

            ReportMaterialErrorDialogElements.ErrorDescriptionField.Text = errorDescription;
            ReportMaterialErrorDialogElements.ErrorDescriptionField.FireJQueryChangeEvent();

            ReportMaterialErrorDialogElements.SubmitReportButton.FireJQueryClickEvent();
        }
        
        public static void DeleteTestErrorReport()
        {
            LoginSteps.LoginAdmin();
            NavigateTo.Url(MaterialsMistakeReportsPageUrl);

            MaterialsMistakeReportsPageElements.DeleteErrorReportButton.FireJQueryClickEvent();
        }

        public static void LoginTestUser()
        {
            LoginSteps.LoginTestUser2();
        }

        public static void NavigateToTestCoursePage(string profilePageUrl)
        {
            LoginTestUser();
            NavigateTo.Url(profilePageUrl);
        }
    }
}
