﻿namespace QA.Framework.Core.Extensions
{
    using ArtOfTest.Common.UnitTesting;
    using ArtOfTest.WebAii.Controls.HtmlControls;
    using Telerik.TestingFramework.Controls.KendoUI;

    public static class HtmlControlsAssertions
    {
        private const string TextNotAsExpectedExceptionMessage = "Control inner text mismatch\n Expected: {0} \n Actual: {1}";

        public static T AssertIsNotNull<T>(this T control) where T : HtmlControl
        {
            string exceptionMessage = string.Format("Control found with the following Expression is null: {0}", control.BaseElement.FindExpressionUsed);

            Assert.IsNotNull(control, exceptionMessage);

            return control;
        }

        public static T AssertTextIsContained<T>(this T control, string expectedText) where T : HtmlControl
        {
            string realText = control.BaseElement.InnerText;
            string exceptionMessage = string.Format(TextNotAsExpectedExceptionMessage, expectedText, realText);

            Assert.IsTrue(realText.Contains(expectedText), exceptionMessage);

            return control;
        }

        public static T AssertTextIsNotContained<T>(this T control, string expectedText) where T : HtmlControl
        {
            string realText = control.BaseElement.InnerText;
            string exceptionMessage = string.Format(TextNotAsExpectedExceptionMessage, expectedText, realText);

            Assert.IsFalse(realText.Contains(expectedText), exceptionMessage);

            return control;
        }

        public static T AssertTextEquals<T>(this T control, string expectedText) where T : HtmlControl
        {
            string realText = control.BaseElement.InnerText;
            string exceptionMessage = string.Format(TextNotAsExpectedExceptionMessage, expectedText, control.BaseElement.InnerText);

            Assert.AreEqual<string>(expectedText, realText, exceptionMessage);

            return control;
        }

        public static T AssertValueEquals<T>(this T control, string expectedValue) where T : HtmlInputControl
        {
            string realValue = control.Value;
            string exceptionMessage = string.Format("Expected value is {0}, but it was {1}", expectedValue, control.BaseElement.InnerText);

            Assert.AreEqual<string>(expectedValue, realValue, exceptionMessage);

            return control;
        }

        public static T AssertKendoValueEquals<T>(this T control, string expectedValue) where T : KendoInput
        {
            string realValue = control.InputValue;
            string exceptionMessage = string.Format("Expected value is {0}, but it was {1}", expectedValue, control.BaseElement.InnerText);

            Assert.AreEqual<string>(expectedValue, realValue, exceptionMessage);

            return control;
        }

        public static T AssertIsPresent<T>(this T control) where T : HtmlControl
        {
            string exceptionMessage = string.Concat("The '", control.TagName, "' is not present on the page but it should be");

            Assert.IsNotNull(control, exceptionMessage);
            exceptionMessage = string.Concat("The '", control.TagName, "' is not visible on the page but it should be");
            Assert.IsTrue(control.IsVisible(), exceptionMessage);

            return control;
        }

        public static T AssertIsNotPresent<T>(this T control) where T : HtmlControl
        {
            string exceptionMessage = string.Concat("The control is present on the page but it should not be");

            Assert.IsNull(control, exceptionMessage);

            return control;
        }

        public static T AssertIsVisible<T>(this T control) where T : HtmlControl
        {
            control.Wait.ForVisible();
            string exceptionMessage = string.Concat("The '", control.TagName, " ", control.TagName, "' is not visible on the page but it should be");

            Assert.IsTrue(control.IsVisible(), exceptionMessage);

            return control;
        }

        public static T AssertIsNotVisible<T>(this T control) where T : HtmlControl
        {
            control.Wait.ForVisibleNot();
            string exceptionMessage = string.Concat("The '", control.TagName, " ", control.TagName, "' is visible on the page but it should not be");

            Assert.IsFalse(control.IsVisible(), exceptionMessage);

            return control;
        }
    }
}
