using APIFramework;
using APIFramework.Models;
using APITests.TestingData;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using System.Net;

namespace APITests
{
    [TestFixture]
    public class Tests
    {
        public HttpStatusCode statusCode;
        
        [TestCase(TestName="Validating obtained user personal information", 
                  Description="Validating the object returned as a response to a query with pagination params",  
                  Category="positive")]        
        public void VerifyListOfRetrievedUsers()
        {
            var apiSetup = new APISetup();
            var response = apiSetup.GetUsers("api/users?page=2&per_page=1");
            var responseBody = apiSetup.GetUsersContent(response);

            Assume.That((int) response.StatusCode, Is.EqualTo(200));

            Assert.Multiple(() =>
            {
                Assert.That(responseBody.page, Is.EqualTo(2));
                Assert.That(responseBody.data[0].first_name, Is.EqualTo("Janet"));
                Assert.That(responseBody.data[0].last_name, Is.EqualTo("Weaver"));
                Assert.That(responseBody.data.Length, Is.EqualTo(1));
            });
        }

        [TestCaseSource(typeof(TestDataConfig), nameof(TestDataConfig.PostUsersTestData))]
        public void TestNewUserCreation(string userName, string jobTitle)
        {

            var payloadObject = new CreateUserRequestDTO
            {
                Name = userName,
                Job = jobTitle
            };

            var apiSetup = new APISetup();
            var response = apiSetup.CreateUserObject("api/users", payloadObject);
            var responseBody = apiSetup.GetCreatedUserResponseBody(response);

            Assume.That((int) response.StatusCode, Is.EqualTo(201));
            Assert.Multiple(() =>
            {   Assert.That(responseBody.name, Is.EqualTo(userName));
                Assert.That(responseBody.job, Is.EqualTo(jobTitle));
                Assert.That(responseBody.id, Is.GreaterThanOrEqualTo(1));
                Assert.That(responseBody.createdAt, Is.TypeOf(typeof(DateTimeOffset)));
            });
        }

        [TestCase(TestName = "Validing Server Response Code to Get Request for nonexistent id",
                  Description = "Checking that server response is 404 for a user id that is not present in the system",
                  Category = "negative")]
        public void TestObtainingNonexistentUser()
        {
            var apiSetup = new APISetup();
            var response = apiSetup.GetUsers("api/users/13");

            Assert.That((int) response.StatusCode, Is.EqualTo(404));
            Assert.That(response.StatusDescription, Is.EqualTo("Not Found"));
            // Validating response body for this test is not practical because API
            // method doesn't return proper error message, but html code for 404 page
        }

        [TestCaseSource(typeof(TestDataConfig), nameof(TestDataConfig.PatchUpdateUserTestData))]
        public void TestUpdatingUserWithPatch(string userName, string jobTitle)
        {
            var payloadObject = new CreateUserRequestDTO
            {
                Name = userName,
                Job = jobTitle
            };

            var apiSetup = new APISetup();
            var response = apiSetup.PatchUpdateAnUserById("api/users/12", payloadObject);
            var responseBody = apiSetup.UpdatedUserContent(response);

            Assume.That((int)response.StatusCode, Is.EqualTo(200));
            Assert.Multiple(() =>
            {
                Assert.That(responseBody.name, Is.EqualTo(userName));
                Assert.That(responseBody.job, Is.EqualTo(jobTitle));
                Assert.That(responseBody.createdAt, Is.TypeOf(typeof(DateTimeOffset)));
            });
        }

        [TestCaseSource(typeof(TestDataConfig), nameof(TestDataConfig.PutUpdateUserTestData))]
        public void TestUpdatingUserWithPut(string userName, string jobTitle)
        {
            var payloadObject = new CreateUserRequestDTO
            {
                Name = userName,
                Job = jobTitle
            };

            var apiSetup = new APISetup();
            var response = apiSetup.PutUpdateToAnUserById("api/users/12", payloadObject);
            var responseBody = apiSetup.UpdatedUserContent(response);

            Assume.That((int)response.StatusCode, Is.EqualTo(200));
            Assert.Multiple(() =>
            {
                Assert.That(responseBody.name, Is.EqualTo(userName));
                Assert.That(responseBody.job, Is.EqualTo(jobTitle));
                Assert.That(responseBody.createdAt, Is.TypeOf(typeof(DateTimeOffset)));
            });
        }

        [TestCase(TestName = "Deleting User Entity From The System By The Id",
                  Description = "Validating HTTP Status Code & Message For Delete Method",
                  Category = "positive")]
        public void TestUserDeletionById()
        {
            var apiSetup = new APISetup();
            var response = apiSetup.DeleteUserById("api/users/13");

            Assert.That((int)response.StatusCode, Is.EqualTo(204));
            Assert.That(response.StatusDescription, Is.EqualTo("No Content"));
        }

        /*
         * Usually confidentail test data like login & password are passed directly 
         * in the test case below because they are publicly available in the api example
         */
        [TestCaseSource(typeof(TestDataConfig), nameof(TestDataConfig.RegisterUserPositiveTestData))]
        public void TestUserRegistrationPositive(string emailAddress, string userPassword)
        {
            var payloadObject = new RegisterUserRequestDTO
            {
                email = emailAddress,
                password = userPassword
            };

            var apiSetup = new APISetup();
            var response = apiSetup.RegisterNewUser("api/register", payloadObject);
            var responseBody = apiSetup.RegistredUserContent(response);
            
            Assume.That((int) response.StatusCode, Is.EqualTo(200));
            Assert.Multiple(() =>
            {
                Assert.That(responseBody.id, Is.EqualTo(4));
                Assert.That(responseBody.token.Length, Is.EqualTo(17));
            });
        }

        [TestCaseSource(typeof(TestDataConfig), nameof(TestDataConfig.RegisterUserNegativeTestData))]
        public void TestUserRegistrationWithoutPassword(string emailAddress, string userPassword)
        {
            var payloadObject = new RegisterUserRequestDTO
            {
                email = emailAddress,
                password = userPassword
            };

            var apiSetup = new APISetup();
            var response = apiSetup.RegisterNewUser("api/register", payloadObject);
            var responseBody = apiSetup.RegistredUserContent(response);

            
            Assert.Multiple(() =>
            {
                Assert.That((int)response.StatusCode, Is.EqualTo(400));
                Assert.That(response.StatusDescription, Is.EqualTo("Bad Request"));
            });
        }
    }
    }