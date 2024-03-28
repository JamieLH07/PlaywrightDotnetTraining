using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NuGet.Frameworks;
using NUnit.Framework;
using PlaywrightTrainingProject.Pages;

namespace PlaywrightTrainingProject.PlaywrightDemo;

public class PlaywrightPostLoginTests : PageTest
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
    public async Task LoginAndAddToBasket()
    {
        //Get the page variable using the POM 
        var page = await Browser.NewPageAsync();
        var loginPage = new LoginPageUpgraded(page);


        //Navigate to the website
        await page.GotoAsync("https://www.saucedemo.com/");


        //Do the Login using the POM
        await loginPage.Login(userName: "standard_user", password: "secret_sauce");

        //Check login was succesful
        var ProductExists = await loginPage.IsProductTxtExists();
        Assert.IsTrue(ProductExists);

        var productPage = new ProductsPage(page);

        //Add all products to the Basket
        await productPage.AddAllToBasket();

        //Check products have been added
        var BasketUpdated = await productPage.IsBasketUpdated();
        Assert.IsTrue(BasketUpdated);


        //Logout
        await productPage.Logout();

        //Check Logout Was Successful
        var LogoutCheck = await productPage.IsLogoutSuccessful();
        Assert.IsTrue(LogoutCheck);

    }
}