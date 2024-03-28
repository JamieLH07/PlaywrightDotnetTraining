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
        //Use this to set the Username locator as a variable and then call the Fill action afterwards (POM) Method
        var userName = Page.Locator("#user-name");
        await userName.FillAsync("standard_user");


        //Use this to find and fill the locator in one line of code (The above is better as variable can be reused
        //await Page.Locator("#user-name").FillAsync("standard_user");

        //Use this to set the Password locator as a variable and then call the Fill action afterwards (POM) Method
        var passWord = Page.Locator("#password");
        await passWord.FillAsync("secret_sauce");


        //Use this to find and fill the locator in one line of code (The above is better as variable can be reused
        //await Page.Locator("#password").FillAsync("secret_sauce");


        var btnLogin = Page.Locator("input", new PageLocatorOptions { HasTextString = "Login" });
        await btnLogin.ClickAsync();

        //await Page.ClickAsync("text=Login");
        await Expect(Page.Locator("text='Products'")).ToBeVisibleAsync();


        //Use the Below to take a Snapshot of the page if there are any issues
        //await page.ScreenshotAsync(new PageScreenshotOptions
        //{
        //    Path = "SauceDemo.jpg"

        //});



    }

}