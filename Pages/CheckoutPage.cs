using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTrainingProject.Pages
{
    public class CheckoutPage
    {
        private IPage _page;
        public CheckoutPage(IPage page) => _page = page;

        //Locator for Checkout Page selectors
        private ILocator _txtYourCart => _page.Locator("css=#header_container > div.header_secondary_container > span");
        private ILocator _btnContinueShopping => _page.Locator("continue-shopping");
        private ILocator _btnCheckout => _page.Locator("checkout");
        private ILocator _btnLeftPanel => _page.Locator("#react-burger-menu-btn");
        private ILocator _btnLogout => _page.Locator("#logout_sidebar_link");
        private ILocator _btnLogin => _page.Locator("#login-button");



        public async Task IsCheckoutPageLoaded()
        {
            await _txtYourCart.IsVisibleAsync();
            await _btnContinueShopping.IsVisibleAsync();
            await _btnCheckout.IsVisibleAsync();

        }

        public async Task Logout()
        {
            await _btnLeftPanel.ClickAsync();
            await _btnLogout.ClickAsync();
        }
        public async Task<bool> IsLogoutSuccessful() => await _btnLogin.IsVisibleAsync();

    }
}
