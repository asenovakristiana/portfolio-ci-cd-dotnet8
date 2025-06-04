using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace PortfolioCiCdDotNet8.Steps
{
    public class LoginSteps
    {
        private readonly IWebDriver driver;

        public LoginSteps()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Given("the user is on login page")]
        public void GivenUserIsOnLoginPage()
        {
            driver.Navigate().GoToUrl("https://www.example.com/login");
            TakeScreenshot("login-page");
        }

        [When("the user enters {string} and {string}")]
        public void WhenUserEnterCredentials(string username, string password)
        {
            try
            {
                driver.FindElement(By.Id("username")).SendKeys(username);
                driver.FindElement(By.Id("password")).SendKeys(password);
                driver.FindElement(By.Id("loginButton")).Click();
                TakeScreenshot("login-submit");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Login elements not found");
                TakeScreenshot("error-login");
                Assert.Fail("Login form elements not found");
            }
        }

        [Then("the user should be logged in successfully")]
        public void ThenUserShouldBeLoggedInSuccessfully()
        {
            Assert.That(driver.PageSource.Contains("Welcome, testuser"), Is.True);
            TakeScreenshot("login-success");
            driver.Quit();
        }

        private void TakeScreenshot(string fileName)
        {
            try
            {
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                Directory.CreateDirectory("screenshots");
                screenshot.SaveAsFile($"screenshots/{fileName}.png");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
