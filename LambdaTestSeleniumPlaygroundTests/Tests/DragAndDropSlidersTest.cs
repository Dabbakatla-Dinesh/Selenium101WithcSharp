using NUnit.Framework;
using OpenQA.Selenium;
using System;
using WebAutomationFramework.Config;
using WebAutomationFramework.Drivers;
using WebAutomationFramework.Pages;

namespace WebAutomationFramework.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class DragAndDropSlidersTest
    {
        private IWebDriver driver;
        private string browser;
        private string version;
        private string platform;

        [SetUp]
        public void SetUp()
        {
            driver = null;
        }

        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
            driver?.Dispose();
        }

        [Test, TestCaseSource(typeof(BrowserConfigs), nameof(BrowserConfigs.All))]
        public void ValidateSimpleFormDemo(string browser, string version, string platform)
        {
            this.browser = browser;
            this.version = version;
            this.platform = platform;
            var urlKey = "SeleniumPlayground";

            try
            {
                driver = WebDriverInitializer.LaunchWebDriver(browser, version, platform);

                var playgroundPage = new SeleniumPlaygroundPage(driver);
                playgroundPage.NavigateTo(ConfigReader.GetUrl(urlKey));

                var dragAndDropPage = playgroundPage.ClickDragAndDropSliders();
                dragAndDropPage.DragDefaultValue15SliderTo(95);
                var rangeValue = dragAndDropPage.RangeSuccessValue;

                WebDriverInitializer.MarkTestStatus(driver, rangeValue == 95);

                Assert.That(rangeValue, Is.EqualTo(95), "The slider did not reach the expected value of 95.");
            }
            catch (Exception ex)
            {
                WebDriverInitializer.MarkTestStatus(driver, false, ex.Message);
                throw;
            }
        }
    }
}
