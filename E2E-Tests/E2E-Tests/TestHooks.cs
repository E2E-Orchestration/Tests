using BoDi;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Microsoft.Playwright;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using System;
using E2E_Tests.Models;
using E2E_Tests.PageObjects;

namespace E2E_Tests
{
	[Binding]
    public class TestHooks
    {
		[BeforeFeature]
		public static async Task BeforeAllFeatures(IObjectContainer container)
		{
			var config = new ConfigurationBuilder()
				.SetBasePath(Environment.CurrentDirectory)
				.AddJsonFile("appsettings.json", optional: true)
				.AddEnvironmentVariables()
				.Build();

			var playwright = await Playwright.CreateAsync();

			var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
			{
				Headless = !Debugger.IsAttached,
				SlowMo = Debugger.IsAttached ? 10 : 0
			});

			var configuration = new TestConfig();

			config.GetSection(nameof(TestConfig))
				.Bind(configuration);

			container.RegisterInstanceAs(playwright);
			container.RegisterInstanceAs(browser);
			container.RegisterInstanceAs(configuration);
		}


		[BeforeScenario]
		public void BeforeScenario(IObjectContainer container, IBrowser browser, TestConfig config)
		{
			var homePageObject = new HomePageObject(browser, config);
			container.RegisterInstanceAs<IHomePageObject>(homePageObject);
		}


		[AfterScenario]
		public async Task AfterBoxScenario(IObjectContainer container)
		{
			var browser = container.Resolve<IBrowser>();
			await browser.CloseAsync();
			var playwright = container.Resolve<IPlaywright>();
			playwright.Dispose();
		}
	}
}
