using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using System.IO;

[TestFixture]
public class NavigationTest
{
    private IWebDriver driver;

    [SetUp]
    public void StartBrowser()
    {
        driver = new ChromeDriver();
    }

    [Test]
    public void TestHomePageLoads()
    {
        driver.Navigate().GoToUrl("https:/www.example.com");
        Assert.That(driver.Title, Is.EqualTo("Example Domain"));
        TakeScreenshot("homepage-load");
    }

    public void TakeScreenshot(string fileName)
    {
        Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        Directory.CreateDirectory("screenshots");
        screenshot.SaveAsFile($"screenshots/{fileName}.png");
    }

    [TearDown]
    public void CloseBrowser()
    {
        driver.Quit();
    }
}