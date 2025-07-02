using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAutomationFramework.Tests
{
    public static class BrowserConfigs
    {
        public static IEnumerable<TestCaseData> All =>
            new[]
            {
                new TestCaseData("Chrome",  "latest", "Windows 10"),
                new TestCaseData("Safari",  "latest", "macOS Catalina")
            };
    }

}
