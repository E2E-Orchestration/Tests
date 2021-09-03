using Microsoft.Playwright;
using System.Threading.Tasks;

namespace E2E_Tests.PageObjects
{
    public interface IPageObject
    {
		public string BasePageUrl { get; set; }
		public string PagePath { get; set; }

		public abstract IPage Page { get; set; }
		public abstract IBrowser Browser { get; set; }

		public async Task NavigateAsync() => await NavigateAsync($"{BasePageUrl}{PagePath}");

		public async Task NavigateAsync(string absolutePath)
		{
			Page = await Browser.NewPageAsync();
			await Page.GotoAsync(absolutePath);
		}
	}
}
