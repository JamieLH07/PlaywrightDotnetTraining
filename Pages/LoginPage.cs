using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightTrainingProject.Pages
{
    public class LoginPage
    {
        private IPage _page;
        private readonly ILocator _txtuserName;
        private readonly ILocator _txtpassWord;
        private readonly ILocator _btnLogin;
        private readonly ILocator _txtProducts;
        public LoginPage(IPage page)
        {

            _page = page;
            _txtuserName = _page.Locator("#user-name");
            _txtpassWord = _page.Locator("#password");
            _btnLogin = _page.Locator("input", new PageLocatorOptions { HasTextString = "Login" });
            _txtProducts = _page.Locator("text='Products'");

        }

        public async Task Login(string userName, string password)
        {

            await _txtuserName.FillAsync(userName);
            await _txtpassWord.FillAsync(password);
            await _btnLogin.ClickAsync();

        }

        public async Task<bool> IsProductTxtExists() => await _txtProducts.IsVisibleAsync();


    }
}
