using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System;
using System.IO;

namespace PortfolioCiCdDotNet8.Tests
{
    [TestFixture]
    public class WebDriverTest
    {
        ChromeDriver? driver;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("https://www.example.com");
        }

        [Test]
        public void TestSearchBox()
        {
            try
            {
                IWebElement searchBox = driver!.FindElement(By.Name("q"));
                searchBox.SendKeys("Selenium WebDriver");
                searchBox.Submit();

                TakeScreenshot("search-box");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("SB not found");
                TakeScreenshot("error-search-box");
                Assert.Fail("SB not found");
            }
        }

        public void TakeScreenshot(string fileName)
        {
            try
            {
                Screenshot screenshot = ((ITakesScreenshot)driver!).GetScreenshot();
                Directory.CreateDirectory("screenshots");
                screenshot.SaveAsFile($"screenshots/{fileName}.png");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error taking screenshot: {ex.Message}");
            }
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver!.Quit();
        }
    }
}