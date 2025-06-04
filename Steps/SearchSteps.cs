using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.IO;
using OpenQA.Selenium.Chrome;

[Binding]
public class SearchSteps
{
    private readonly IWebDriver driver;

    public SearchSteps()
    {
        driver = new ChromeDriver();
    }

    [Given("the user is on the homepage")]
    public void GivenUserIsOnHomePage()
    {
        driver.Navigate().GoToUrl("https://www.example.com");
        TakeScreenshot("home-page");
    }

    [When("the user enters a search query")]
    public void WhenUserEntersSearchQuery()
    {
        var searchBox = driver.FindElement(By.Name("q"));
        searchBox.SendKeys("specFlow Testing");
        searchBox.Submit();
        TakeScreenshot("search-input");
    }

    [Then("the results should contain the expected value")]
    public void ThenResultsShouldContainExpectedValue()
    {
        Assert.That(driver.PageSource.Contains("Expected Result"), Is.True);
        TakeScreenshot("search-success");
        driver.Quit();
    }

    private void TakeScreenshot(string fileName)
    {
        Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
        Directory.CreateDirectory("screenshots");
        screenshot.SaveAsFile($"screenshots/{fileName}.png");
    }
}