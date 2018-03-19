using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ACTestProject.Hooks
{
    [Binding]
    public sealed class HookConfig
    {
        [BeforeScenario]
        public static void Initialize()
        {
            Browser.Initialize();
        }

        [AfterScenario]
        public static void TearDown()
        {
            Browser.TearDown();
        }
    }
}
