using System;
using TechTalk.SpecFlow;
using WireMock.Server;
using WireMock.Settings;

namespace AcceptanceTests
{
    [Binding]

    public static class Hooks
    {
        public static WireMockServer TwitterStub;
        public static WireMockServer TwitterLoginStub;


        [BeforeTestRun]
        private static void BeforeTestRun()
        {
            StartFakeTwitterLogin();
            StartFakeTwitter();
        }
        private static void StartFakeTwitterLogin()
        {
            TwitterStub = FluentMockServer.Start( new FluentMockServerSettings
            {
                Urls = new[] {"http://localhost:5000"},
                StartAdminInterface = true
            });
        }
        private static void StartFakeTwitter()
        {
            TwitterStub = FluentMockServer.Start( new FluentMockServerSettings
            {
                Urls = new[] {"http://localhost:5001"},
                StartAdminInterface = true
            });
        }
        

        [BeforeScenario]
        private static void BeforeScenario(ScenarioContext currentScenario)
        {
            Console.WriteLine($"Starting Scenario: {currentScenario.ScenarioInfo.Title}");
            TwitterLoginStub.Reset();
            TwitterStub.Reset();

        }

        [AfterTestRun]
        private static void AfterTestRun()
        {
            TwitterLoginStub.Stop();
            TwitterStub.Stop();
        }
    }


    
}