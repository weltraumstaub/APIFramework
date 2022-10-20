using APIFramework;
using APIFramework.Models;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

namespace APITests
{
    [TestFixture]
    public class Tests
    {
        public TestContext TestContext { get; set; }

        [OneTimeSetUp]
        public static void SetupReport(TestContext testContext)
        {
            var testDir = testContext.TestDirectory;
            ReporterSetup.SetupTestReporter(testDir, "API Test Suite", "Api Test report");
        }

        [SetUp]
        public void SetupTest()
        {
            ReporterSetup.CreateTest(TestContext.Test.Name);
        }

        [TearDown]
        public void TearDownTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            Status logStatus;

            switch (testStatus)
            {
                case TestStatus.Failed:
                    logStatus = Status.Fail;
                    ReporterSetup.TestStatus(logStatus.ToString());
                    break;
                case TestStatus.Inconclusive:
                    break;
                case TestStatus.Passed:
                    logStatus = Status.Pass;
                    break;
                case TestStatus.Warning:
                    logStatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logStatus = Status.Skip;
                    break;
                default:
                    break;
            }

        }

        [OneTimeTearDown]
        public static void CleanUpReport()
        {
            ReporterSetup.FlushReport();
        }

        [Test]
        public void VerifyListOfRetrievedUsers()
        {
            var apiSetup = new APISetup<ListOfUsersDTO>();
            var response = apiSetup.GetUsers("api/users?page=2");

            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Not.Null);
                Assert.That(response.page, Is.EqualTo(2));
                Assert.That(actual: response.data[0].first_name, Is.EqualTo("Michael"));
            });
            ReporterSetup.LogTestResult(Status.Pass, "The Test is Successfull");
        }

        [Test]
        public void TestNewUserCreation()
        {
            var payload = @"{
                            ""name"": ""Daphna"",
                            ""job"": ""Data Analyst""
                            }";

            var apiSetup = new APISetup<PostUserDTO>();
            var response = apiSetup.CreateUserObject("api/users", payload);


            Assert.Multiple(() =>
            {   Assert.That(response.name, Is.EqualTo("Daphna"));
                Assert.That(response.job, Is.EqualTo("Data Analyst"));
            });
        }
    }
}