using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.IO;

[TestFixture]
public class Buttontest
{
    private IWebDriver driver;

    [SetUp]
    public void Startbrowser()
    {
        driver = new ChromeDriver();
    }

    [Test]
    public void TestSignUpButton()
    {
        driver.Navigate().GoToUrl("https://www.example.com");
        IWebElement signUpButton = driver.FindElement(By.Id("signUp"));

        Assert.That(signUpButton.Displayed, Is.True);
        TakeScreenshot("button-clicked");
    }

    public void TakeScreenshot(string fileName)
    {
        Screenshot screenshot =((ITakesScreenshot)driver).GetScreenshot();
        Directory.CreateDirectory("screenshots");
        screenshot.SaveAsFile($"screenshots/{fileName}.png");
    }

    [TearDown]
    public void CloseBrowser()
    {
        driver.Quit();
    }
}