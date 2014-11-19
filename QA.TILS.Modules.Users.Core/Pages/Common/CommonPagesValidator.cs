namespace QA.TILS.Modules.Users.Core.Pages.Common
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using ArtOfTest.WebAii.Core;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using QA.Framework.Core.Extensions;
    using QA.Framework.Core.Helpers;
    using QA.TILS.Modules.Users.Core.SharedSteps;
    using System;

    public static class CommonPagesValidator
    {        
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
        private static LoggedUserStartPageElements StartPageElements
        {
            get
            {
                return new LoggedUserStartPageElements();
            }
        }

        private static string MaterialsMistakeReportsPageUrl 
        {
            get
            {
                return "http://test.telerikacademy.com/Administration_Courses/LectureResourceBugReports";
            }
        }

        private static MaterialsMistakeReportsPageElements MaterialsMistakeReportsPageElements
        {
            get
            {
                return new MaterialsMistakeReportsPageElements();
            }
        }
        
        public static void AssertErrorReportHasBeenSavedCorrectly(string lectureName, string resourceName, string errorLocation, string errorDescription)
        {
            LoginSteps.LoginAdmin();
            NavigateTo.Url(MaterialsMistakeReportsPageUrl);

            string errorMessage = "";
            bool verificationSucceeded = true;

            MaterialsMistakeReportsPageElements.TestReportLectureNameCell.Wait.ForExists(5000);

            if (MaterialsMistakeReportsPageElements.TestReportLectureNameCell.InnerText != lectureName)
            {
                verificationSucceeded = false;
                errorMessage += "The report was created for the wrong lecture\n";
            }

            if (MaterialsMistakeReportsPageElements.TestReportResourceNameCell.InnerText != resourceName)
            {
                verificationSucceeded = false;
                errorMessage += "The report was created for the wrong report\n";
            }

            if (MaterialsMistakeReportsPageElements.TestReportErrorLocationCell.InnerText != errorLocation)
            {
                verificationSucceeded = false;
                errorMessage += "The reported error location was not correctly saved\n";
            }

            if (MaterialsMistakeReportsPageElements.TestReportErrorDescriptionCell.InnerText != errorDescription)
            {
                verificationSucceeded = false;
                errorMessage += "The reported error description was not correctly saved";
            }

            Assert.IsTrue(verificationSucceeded, errorMessage);
        }

        public static void MaterialsAssertAllMaterialsForALectureArePresent(string lectureName, string[] materialsNames)
        {
            HtmlTableRow lectureRowElement = Manager.Current.ActiveBrowser.Find.ByXPath<HtmlTableRow>("//tr[td/. = '" + lectureName + "']");

            HtmlTableCell materialsCell = lectureRowElement.Cells[3];

            //We substract 1 from the count as the the last link is for reporting an error, not for a material
            int numberOfMaterialsOnPage = materialsCell.Find.AllByTagName("a").Count - 1;

            Assert.AreEqual(materialsNames.Length, numberOfMaterialsOnPage, "The number of materials on the page is {0} instead of {1}", numberOfMaterialsOnPage, materialsNames.Length);

            string errorMessage = "";
            bool allMaterialsArePresent = true;

            foreach (var materialName in materialsNames)
            {
                try
                {
                    materialsCell.Find.ByXPath("//a[contains(text(),'" + materialName + "')]");
                }
                catch
                {
                    allMaterialsArePresent = false;
                    errorMessage += String.Format("Material {0} was not found\n", materialName);
                }
            }

            Assert.IsTrue(allMaterialsArePresent, errorMessage);
        }

        public static void MaterialsAssertMaterialLinkPointsToTheCorrectLocation(string expectedLink, string actualLink)
        {
            Assert.AreEqual(expectedLink, actualLink, "The links of the resource do not match");
        }      

        public static void MaterialsAssertNumberOfMaterialsToReport(string courseProfilePageUrl, int expectedMaterialsCount)
        {
            NavigateTo.Url(courseProfilePageUrl);
            InstanceProfilePageElements.ReportMistakeButton.Click();
            ReportMaterialErrorDialogElements.ExpandMaterialsArrow.Wait.ForExists(5000);

            //We substract 1, as the first choice is the default message "Choose material"
            int actualMaterialsCount = ReportMaterialErrorDialogElements.ResourcesToReportList.AllItems.Length - 1;

            Assert.AreEqual(expectedMaterialsCount, actualMaterialsCount, "The number of available lecture materials to report an error for is {0} instead of {1}", actualMaterialsCount, expectedMaterialsCount);
        }

        public static void CoursesAssertCoursesMenuIsPresent()
        {
            Manager.Current.ActiveBrowser.Refresh();
            StartPageElements.MyCoursesMenuItem.AssertIsPresent();
        }

        public static void AssertCorrectPageHasBeenLoaded(string expectedUrl, string actualUrl)
        {
            Assert.AreEqual(expectedUrl, actualUrl);
        }

        public static void StartPageUnacceptedFriendshipInvitationExists()
        {
            StartPageElements.UnacceptedInvitationsLink.Wait.ForExists();
        }

        public static void StartPageUnacceptedFriendshipInvitationDoesNotExist()
        {
            StartPageElements.UnacceptedInvitationsLink.Wait.ForExistsNot();
        }

        public static void StartPageNewMessagesNotificationExists()
        {
            StartPageElements.NewMessagesLink.AssertIsPresent();
        }

        public static void StartPageNewMessagesNotificationDoesNotExist()
        {
            StartPageElements.NewMessagesLink.AssertIsNotPresent();
        }
    }
}
