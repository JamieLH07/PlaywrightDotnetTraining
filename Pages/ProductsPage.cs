using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTrainingProject.Pages
{
    public class ProductsPage
    {
        private IPage _page;
        public ProductsPage(IPage page) => _page = page;

        //Locator for Backpack at the cart button
        private ILocator _btnBackpackCart => _page.Locator("#add-to-cart-sauce-labs-backpack");
        private ILocator _btnBikeCart => _page.Locator("#add-to-cart-sauce-labs-bike-light");
        private ILocator _btnShirtCart => _page.Locator("#add-to-cart-sauce-labs-bolt-t-shirt");
        private ILocator _btnJacketCart => _page.Locator("#add-to-cart-sauce-labs-fleece-jacket");
        private ILocator _btnOnesieCart => _page.Locator("#add-to-cart-sauce-labs-onesie");
        private ILocator _btnRedTCart => _page.Locator("css=#add-to-cart-test\\.allthethings\\(\\)-t-shirt-\\(red\\)");
        private ILocator _txtBasketNumber => _page.Locator("css=#shopping_cart_container > a > span");
        private ILocator _btnBasket => _page.Locator("css=#shopping_cart_container > a");
        private ILocator _btnLeftPanel => _page.Locator("#react-burger-menu-btn");
        private ILocator _btnLogout => _page.Locator("#logout_sidebar_link");
        private ILocator _btnLogin => _page.Locator("#login-button");


        public async Task AddAllToBasket()
        {
            await _btnBackpackCart.ClickAsync();
            await _btnBikeCart.ClickAsync();
            await _btnShirtCart.ClickAsync();
            await _btnJacketCart.ClickAsync();
            await _btnOnesieCart.ClickAsync();
            await _btnRedTCart.ClickAsync();
        }

        public async Task<bool> IsBasketUpdated() => await _txtBasketNumber.IsVisibleAsync();

        public async Task NavigatetoBasket()
        {
            await _btnBasket.ClickAsync();
        }

        public async Task Logout()
        {
            await _btnLeftPanel.ClickAsync();
            await _btnLogout.ClickAsync();
        }

        

        public async Task<bool> IsLogoutSuccessful() => await _btnLogin.IsVisibleAsync();

    }
}
