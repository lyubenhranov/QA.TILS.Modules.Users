namespace QA.TILS.Modules.Users.Core.Pages.Common
{
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using QA.Framework.Core.Base;
    using QA.Framework.Core.Extensions;

    public class CourseDialogElements : BaseElementsMap
    {
        public HtmlInputText CourseFieldName
        {
            get
            {
                return this.Find.ByName<HtmlInputText>("CourseId_input");
            }
        }

        public HtmlInputText InstanceNameField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("Name");
            }
        }

        public HtmlInputText StartDateField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("StartDate");
            }
        }

        public HtmlInputText EndDateField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("EndDate");
            }
        }

        public HtmlInputCheckBox IsCourseActiveCheckbox
        {
            get
            {
                return this.Find.ById<HtmlInputCheckBox>("IsActive");
            }
        }

        public HtmlInputCheckBox IsCoursePublicCheckbox
        {
            get
            {
                return this.Find.ById<HtmlInputCheckBox>("IsPublic");
            }
        }

        public HtmlInputText LecturesPerWeekField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("LecturesPerWeek");
            }
        }

        public HtmlSpan LecturesPerWeekIncreaseButton
        {
            get
            {
                return this.Find.ByXPath<HtmlSpan>("//*[@id='LecturesPerWeek']/following-sibling::span/span[1]/span");
            }
        }

        public HtmlSpan LecturesPerWeekDecreaseButton
        {
            get
            {
                return this.Find.ByXPath<HtmlSpan>("//*[@id='LecturesPerWeek']/following-sibling::span/span[2]/span");
            }
        }

        public HtmlInputText ApplicationDeadlineField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("ApplyDeadline");
            }
        }

        public HtmlInputText OnsiteStudentsLimitField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("LiveStudentsLimit");
            }
        }

        public HtmlSpan OnsiteStudentsLimitIncreaseButton
        {
            get
            {
                return this.Find.ByXPath<HtmlSpan>("//*[@id='LiveStudentsLimit']/following-sibling::span/span[1]/span");
            }
        }

        public HtmlSpan OnsiteStudentsLimitDecreaseButton
        {
            get
            {
                return this.Find.ByXPath<HtmlSpan>("//*[@id='LiveStudentsLimit']/following-sibling::span/span[2]/span");
            }
        }

        public HtmlInputText OnlineStudentsLimitField
        {
            get
            {
                return this.Find.ById<HtmlInputText>("OnlineStudentsLimit");
            }
        }

        public HtmlSpan OnlineStudentsLimitIncreaseButton
        {
            get
            {
                return this.Find.ByXPath<HtmlSpan>("//*[@id='OnlineStudentsLimit']/following-sibling::span/span[1]/span");
            }
        }

        public HtmlSpan OnlineStudentsLimitDecreaseButton
        {
            get
            {
                return this.Find.ByXPath<HtmlSpan>("//*[@id='OnlineStudentsLimit']/following-sibling::span/span[2]/span");
            }
        }

        public HtmlAnchor UpdateButton
        {
            get
            {
                return this.Find.ByExpression<HtmlAnchor>("k-button k-button-icontext k-primary k-grid-update".ToClassContainsExpression());
            }
        }

        public HtmlAnchor CancelButton
        {
            get
            {
                return this.Find.ByExpression<HtmlAnchor>("k-button k-button-icontext k-grid-cancel".ToClassContainsExpression());
            }
        }
    }
}
