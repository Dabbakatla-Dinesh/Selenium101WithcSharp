using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAutomationFramework.Helpers;

namespace WebAutomationFramework.Pages
{
    public class SeleniumPlaygroundPage : BasePage
    {
        public SeleniumPlaygroundPage(IWebDriver driver) : base(driver)
        {
        }

        private const string SimpleFormDemoBtnText = "Simple Form Demo";
        private const string DragAndDropSlidersBtnLinkText = "Drag & Drop Sliders";
        private const string InputFormSubmitBtnText = "Input Form Submit";


        private IWebElement SimpleFormDemo => Driver.FindElement(By.PartialLinkText(SimpleFormDemoBtnText));
        private By DragAndDropSlidersBtn => By.LinkText(DragAndDropSlidersBtnLinkText);
        private IWebElement InputFormSubmitBtn => Driver.FindElement(By.PartialLinkText(InputFormSubmitBtnText));


        public SimpleFormDemoPage ClickSimpleFormDemo()
        {
            ElementActionHelpers.ClickWhenReady(
                Driver,
                By.PartialLinkText(SimpleFormDemoBtnText),
                TimeSpan.FromSeconds(10));
            return new SimpleFormDemoPage(Driver);
        }

        public DragAndDropSliderPage ClickDragAndDropSliders()
        {
            ElementActionHelpers.ClickWhenReady(
                Driver,
                DragAndDropSlidersBtn,
                TimeSpan.FromSeconds(10));
            return new DragAndDropSliderPage(Driver);
        }

        public InputFormSubmitPage ClickInputFormSubmit()
        {
            ElementActionHelpers.ClickWhenReady(
                Driver,
                By.PartialLinkText(InputFormSubmitBtnText),
                TimeSpan.FromSeconds(10));
            return new InputFormSubmitPage(Driver);
        }
    }
}
