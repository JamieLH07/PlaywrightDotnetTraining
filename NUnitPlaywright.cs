using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NuGet.Frameworks;
using NUnit.Framework;

namespace PlaywrightTrainingProject;

public class NUnitPlaywright : PageTest
{
    [SetUp]
    public async Task Setup()

    {

        await Page.GotoAsync("https://www.saucedemo.com/");


    }

    [Test]
    public async Task Test1()
    {

        await Page.Locator("#user-name").FillAsync("standard_user");
        await Page.Locator("#password").FillAsync("secret_sauce");
        await Page.ClickAsync("text=Login");
        await Expect(Page.Locator("text='Products'")).ToBeVisibleAsync();


        //Use the Below to take a Snapshot of the page if there are any issues
        //await page.ScreenshotAsync(new PageScreenshotOptions
        //{
        //    Path = "SauceDemo.jpg"

        //});



    }

}