using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

[TestFixture]
public class WebDriverTest
{
    IWebDriver driver;

    [SetUp]
    public void StartBrowser()
    {
        driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://www.example.com");
    }

    [Test]
    public void TestSearchBox()
    {
        IWebElement searchBox = driver.FindElement(By.Name("q"));
        searchBox.SendKeys("Selenium WebDriver");
        searchBox.Submit();
    }

    [TearDown]
    public void CloseBrowser()
    {
        driver.Quit();
    }
}