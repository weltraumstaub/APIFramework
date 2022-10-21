using APIFramework;
using APIFramework.Models;
using APITests.TestingData;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

namespace APITests
{
    [TestFixture]
    public class Tests
    {
      /*  public TestContext TestContext { get; set; }

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
*/
        
        [Test]
        public void VerifyListOfRetrievedUsers()
        {
            var apiSetup = new APISetup<ListOfUsersDTO>();
            var response = apiSetup.GetUsers("api/users?page=2");

            Assume.That(response, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(response.page, Is.EqualTo(2));
                Assert.That(actual: response.data[0].first_name, Is.EqualTo("Michael"));
            });
            // ReporterSetup.LogTestResult(Status.Pass, "The Test is Successfull");
        }

        [TestCaseSource(typeof(TestDataConfig), nameof(TestDataConfig.PostUsersTestData))]
        public void TestNewUserCreation(string userName, string jobTitle)
        {

            var payloadObject = new CreateUserRequestDTO
            {
                Name = userName,
                Job = jobTitle
            };

            var apiSetup = new APISetup<PostUserDTO>();
            var response = apiSetup.CreateUserObject("api/users", payloadObject);

            Assume.That(response, Is.Not.Empty);
            Assert.Multiple(() =>
            {   Assert.That(response.name, Is.EqualTo(userName));
                Assert.That(response.job, Is.EqualTo(jobTitle));
            });
        }
    }
}