using APIFramework;

namespace APITests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void VerifyListOfRetrievedUsers()
        {
            var framework = new APISetup();
            var response = framework.GetUsers();

            Assert.Multiple(() =>
            {
                Assert.That(response, Is.Not.Null);
                Assert.That(response.page, Is.EqualTo(2));
                Assert.That(actual: response.data[0].first_name, Is.EqualTo("Michael"));
            });
            

        }
    }
}