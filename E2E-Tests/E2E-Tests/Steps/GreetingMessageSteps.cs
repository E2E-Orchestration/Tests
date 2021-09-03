using E2E_Tests.PageObjects;
using Microsoft.Playwright;
using NUnit.Framework;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace E2E_Tests.Steps
{
    [Binding]
    public class GreetingMessageSteps
    {
        public GreetingMessageSteps(IHomePageObject homePage)//, IGreetingPageObject greetingPage)
        {
            HomePage = homePage;
            //GreetingPage = greetingPage;
        }

        public IHomePageObject HomePage { get; }
        //public IGreetingPageObject GreetingPage { get; }

        const string GreetingMessage = "Hello, World!";

        [Given(@"I visit the website")]
        public async Task VisitTheWebstie()
        {
            await HomePage.NavigateAsync();
        }

        [When(@"I navigate to the greeting screen")]
        public async Task NavigateToWelcom()
        {
            await HomePage.NavigateToGreeting();
        }


        [Then(@"I see the greeting message")]
        public async Task ThenISeeTheGreetingMessage()
        {
            var message = await HomePage.GetGreetingMessage();
            Assert.IsTrue(message == GreetingMessage);
        }
    }
}
