using Microsoft.Playwright;
using NuGet.Frameworks;
using NUnit.Framework;

namespace PlaywrightTrainingProject;

public class Tests
{
    [SetUp]
    public void Setup()

    {
    }

    [Test]
    public async Task Test1()
    {

        //Playwright
        using var playwright = await Playwright.CreateAsync();

        //Browser
        await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions

        {
            Headless = false

        });

        //Page
        var page = await browser.NewPageAsync();
        await page.GotoAsync("https://www.saucedemo.com/");
        await page.Locator("#user-name").FillAsync("standard_user");
        await page.Locator("#password").FillAsync("secret_sauce");
        await page.ClickAsync("text=Login");
        var isExist = await page.Locator("text='Products'").IsVisibleAsync();
        Assert.IsTrue(isExist);


        //Use the Below to take a Snapshot of the page if there are any issues
        //await page.ScreenshotAsync(new PageScreenshotOptions
        //{
        //    Path = "SauceDemo.jpg"

        //});



    }

}