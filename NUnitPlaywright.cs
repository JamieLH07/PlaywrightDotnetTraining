using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NuGet.Frameworks;
using NUnit.Framework;
using PlaywrightTrainingProject.Pages;

namespace PlaywrightTrainingProject;

public class NUnitPlaywright : PageTest
{
    [SetUp]
    public async Task Setup()

    {

        await Page.GotoAsync("https://www.saucedemo.com/", new PageGotoOptions
        {
            //This will be used instead of the auto wait in playwright (This may not be needed as Playwright but the options are there if neede)
            WaitUntil = WaitUntilState.DOMContentLoaded
        });


    }

    [Test]
    public async Task Test1()
    {
        //You can use this to set the default timeout for the whole test to a new default (In MS)
        Page.SetDefaultTimeout(5000);


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

        //You can edit the default timeout by using the LocatorAssertionsToBeVisable Options and then specificy the new timeout time (In MS) 
        await Expect(Page.Locator("text='Products'")).ToBeVisibleAsync(new LocatorAssertionsToBeVisibleOptions
        {
            Timeout = 5000

        });


        //Use the Below to take a Snapshot of the page if there are any issues
        //await page.ScreenshotAsync(new PageScreenshotOptions
        //{
        //    Path = "SauceDemo.jpg"

        //});



    }

    [Test]
    public async Task TestWithPOM()
    {
        //Get the page variable using the POM 
        var page = await Browser.NewPageAsync();
        var loginPage = new LoginPageUpgraded(page);


        //Navigate to the website
        await page.GotoAsync("https://www.saucedemo.com/");

        
        //Do the Login using the POM
        await loginPage.Login(userName: "standard_user", password: "secret_sauce");

        //Check login was succesful
        var isExist = await loginPage.IsProductTxtExists();
        Assert.IsTrue(isExist);

    }
}