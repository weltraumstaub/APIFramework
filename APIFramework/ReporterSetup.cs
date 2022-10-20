using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework
{
    public static class ReporterSetup
    {
        public static ExtentReports extentReports;
        public static ExtentReports testReporter;
        public static ExtentHtmlReporter htmlReporter;
        public static ExtentTest testCase;

        public static void SetupTestReporter(string reportName, string documentTitle, dynamic filePath)
        {
            htmlReporter = new ExtentHtmlReporter(filePath);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            htmlReporter.Config.ReportName = reportName;
            htmlReporter.Config.DocumentTitle = documentTitle;

            testReporter = new ExtentReports();
            testReporter.AttachReporter(htmlReporter);
        
        }

        public static void CreateTest(string testName)
        {
            testCase = testReporter.CreateTest(testName);
        }

        public static void LogTestResult(Status status, string message)
        {
            testCase.Log(status, message);
        }

        public static void FlushReport()
        {
            testReporter.Flush();
        }

        public static void TestStatus(string status)
        {
            if (status.Equals("Pass"))
            {
                testCase.Pass("The test has passed successfully");
            }
            else
            {
                testCase.Fail("The test has failed");
            }
        }
    }
}
