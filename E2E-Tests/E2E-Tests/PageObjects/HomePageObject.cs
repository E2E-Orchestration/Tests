using E2E_Tests.Models;
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace E2E_Tests.PageObjects
{
    public class HomePageObject : IHomePageObject
    {
        const string HelloLinkSelector = "data-test-id=hello-link";

        const string GreetingSelector = "data-test-id=greeting";

        public HomePageObject(IBrowser browser, TestConfig config)
        {
            Browser = browser;
            BasePageUrl = config.BaseUrl;
        }

        public string BasePageUrl { get; set; }
        public string PagePath { get; set; }
        public IPage Page { get; set; }
        public IBrowser Browser { get; set; }


        public async Task NavigateToGreeting()
        {
            await Page.WaitForSelectorAsync(HelloLinkSelector, new PageWaitForSelectorOptions
            {
                State = WaitForSelectorState.Attached
            });

            await Page.ClickAsync(HelloLinkSelector);
        }

        public async Task<string> GetGreetingMessage()
        {
            await Page.WaitForSelectorAsync(GreetingSelector, new PageWaitForSelectorOptions
            {
                State = WaitForSelectorState.Attached
            });

            return await Page.InnerHTMLAsync(GreetingSelector);
        }
    }

    public interface IHomePageObject : IPageObject
    {
        public Task NavigateToGreeting();

        public Task<string> GetGreetingMessage();
    }
}
