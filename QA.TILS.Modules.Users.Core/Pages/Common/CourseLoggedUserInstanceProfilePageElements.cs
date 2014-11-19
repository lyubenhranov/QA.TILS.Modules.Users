namespace QA.TILS.Modules.Users.Core.Pages.Common
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using QA.Framework.Core.Base;

    public class CourseLoggedUserInstanceProfilePageElements : BaseElementsMap
    {
        public HtmlInputSubmit ApplyOnsiteButton
        {
            get
            {
                return this.Find.ByXPath<HtmlInputSubmit>("//input[@value = 'Запишете курса присъствено']");
            }
        }

        public HtmlInputSubmit ApplyOnlineButton
        {
            get
            {
                return this.Find.ByXPath<HtmlInputSubmit>("//input[@value = 'Запишете курса онлайн']");
            }
        }

        public HtmlAnchor UnenrollCourseButton
        {
            get
            {
                return this.Find.ByXPath<HtmlAnchor>("//a[. = 'Отпишете курса']");
            }
        }

        public HtmlInputSubmit ChangeAttendanceToOnlineButton
        {
            get
            {
                return this.Find.ByXPath<HtmlInputSubmit>("//input[@value = 'Преминете към онлайн обучение']");
            }
        }

        public HtmlInputSubmit ChangeAttendanceToOnsiteButton
        {
            get
            {
                return this.Find.ByXPath<HtmlInputSubmit>("//input[@value = 'Преминете към присъствено обучение']");
            }
        }

        public HtmlDiv SuccessfullyChangedAttendanceToOnlineMessage
        {
            get
            {
                return this.Find.ByXPath<HtmlDiv>("//div[. = 'Успешно преминахте към онлайн форма на обучение!']");
            }
        }

        public HtmlDiv SuccessfullyChangedAttendanceToOnsiteMessage
        {
            get
            {
                return this.Find.ByXPath<HtmlDiv>("//div[. = 'Успешно преминахте към присъствена форма на обучение! Имейл с потвърждение за успешна смяна на формата на обучение беше изпратен на вашата пощенска кутия.']");
            }
        }

        public HtmlDiv SuccessfullyEnrolledOnlineMessage
        {
            get
            {
                return this.Find.ByXPath<HtmlDiv>("//div[. = 'Успешно се записахте онлайн за курса! Имейл с потвърждение беше изпратен на вашата пощенска кутия.']");
            }
        }

        public HtmlDiv SuccessfullyEnrolledOnsiteMessage
        {
            get
            {
                return this.Find.ByXPath<HtmlDiv>("//div[. = 'Успешно се записахте присъствено за курса! Имейл с потвърждение беше изпратен на вашата пощенска кутия.']");
            }
        }

        public HtmlAnchor MaterialLink
        {
            get
            {
                return this.Find.ByXPath<HtmlAnchor>("//a[contains(text(),'Introduction Video')]");
            }
        }

        public HtmlAnchor ReportMistakeButton
        {
            get
            {
                return this.Find.ByXPath<HtmlAnchor>("//a[. = 'Докладвай грешка в материал']");
            }
        }
    }
}
