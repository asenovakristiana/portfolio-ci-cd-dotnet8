[Binding]
public class SearchSteps
{
    IWebDriver driver = new ChromeDriver();

    [Given(@"the user is on the search page")]
    public void GivenUserIsOnSearchPage()
    {
        driver.Navigate().GoToUrl("https://www.example.com");
    }

    [When(@"they enter ""(.*)"" in the search box")]
    public void WhenEnterText(string query)
    {
        IWebElement searchBox = driver.FindElement(By.Name("q"));
        searchBox.SendKeys(query);
        searchBox.Submit();
    }

    [Then(@"they see relevant results")]
    public void ThenSeeResults()
    {
        Assert.IsTrue(driver.Title.Contains("Selenium WebDriver"));
        driver.Quit();
    }
}