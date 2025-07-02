using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutomationFramework.Pages
{
    public class DragAndDropSliderPage : BasePage
    {
        public DragAndDropSliderPage(IWebDriver? driver) : base(driver)
        {
        }

        private const string DefaultValue15SliderCssSelector = "#slider3>div>input";
        private const string RangeSuccessId = "rangeSuccess";

        private IWebElement DefaultValue15Slider => WebDriverExtensions.WaitForElement(
            Driver, By.CssSelector(DefaultValue15SliderCssSelector), TimeSpan.FromSeconds(10));

        private IWebElement RangeSuccess => Driver.FindElement(By.Id(RangeSuccessId));
        public int RangeSuccessValue => int.Parse(RangeSuccess.Text);

        public void DragDefaultValue15SliderTo(int sliderValue)
        {
            int noOfClicks;
            DefaultValue15Slider.Click();
            if (RangeSuccessValue > sliderValue)
            {
                noOfClicks = RangeSuccessValue - sliderValue;
                for (int i = 0; i < noOfClicks; i++)
                {
                    DefaultValue15Slider.SendKeys(Keys.ArrowLeft);
                }
            }
            else if (RangeSuccessValue < sliderValue)
            {
                noOfClicks = sliderValue - RangeSuccessValue;
                for (int i = 0; i < noOfClicks; i++)
                {
                    DefaultValue15Slider.SendKeys(Keys.ArrowRight);
                }
            }
        }
    }
}
