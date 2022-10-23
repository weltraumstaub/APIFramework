using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace APITests.TestingData
{
    public class TestDataConfig
    {
           
        public static TestCaseData[] PostUsersTestData()
        {
            return new TestCaseData[]
            {
                new TestCaseData("John", "QA")
                    .SetName("Creating new user with the given name and occupation")
                    .SetDescription("Post Request that creates new users with the passed test data as name and job")
                    .SetCategory("positive"),

                new TestCaseData("Yu", "Software Engineer")
                    .SetName("Creating new user with the given name and occupation")
                    .SetDescription("Post Request that creates new users with the passed test data as name and job")
                    .SetCategory("positive"),

                new TestCaseData("Ferdinant-Marcisce", "CEO")
                    .SetName("Creating new user with the given name and occupation")
                    .SetDescription("Post Request that creates new users with the passed test data as name and job")
                    .SetCategory("positive"),

                /*
                 * Due to Test API Design, Negative Test Data is not handled properly and still return successful user creation.
                 * Therefore the data set below is created exclusively to provide example and doesn't correlate with negative test case.
                 * Described behaviour of the POST method one can find reported & captured in the bug list attached to this test assigment.
                 */
                
                new TestCaseData("#@~&*(){{/", " ")
                    .SetName("Creating new user with the given name and occupation")
                    .SetDescription("Post Request that creates new users with the passed test data as name and job")
                    .SetCategory("negative"),
            };
        }

        public static TestCaseData[] PatchUpdateUserTestData()
        {
            return new TestCaseData[]
            {
                new TestCaseData("Jason", "General Quality Assurance Engineer")
                    .SetName("Patching existent user with the provided name and occupation")
                    .SetDescription("Patch Request that updates user with the passed test data as name and job")
                    .SetCategory("positive"),

                new TestCaseData("Yu", "Software Engineer")
                    .SetName("Patching existent user with the provided name and occupation")
                    .SetDescription("Patch Request that updates user with the passed test data as name and job")
                    .SetCategory("positive"),

                new TestCaseData("123", "~")
                    .SetName("Patching existent user with the provided name and occupation")
                    .SetDescription("Patch Request that updates user with the passed test data as name and job")
                    .SetCategory("negative"),
            };
        }

        public static TestCaseData[] PutUpdateUserTestData()
        {
            return new TestCaseData[]
            {
                new TestCaseData("Jason", "General Quality Assurance Engineer")
                    .SetName("Put update to an existent user with the provided name and occupation")
                    .SetDescription("Put Request that updates user with the passed test data as name and job")
                    .SetCategory("positive"),

                new TestCaseData("Yu", "Software Engineer")
                    .SetName("Put update to an existent user with the provided name and occupation")
                    .SetDescription("Put Request that updates user with the passed test data as name and job")
                    .SetCategory("positive"),

                new TestCaseData("123", "~")
                    .SetName("Put update to an existent user with the provided name and occupation")
                    .SetDescription("Put Request that updates user with the passed test data as name and job")
                    .SetCategory("negative"),
            };
        }

        public static TestCaseData[] RegisterUserPositiveTestData()
        {
            return new TestCaseData[]
            {
                new TestCaseData("eve.holt@reqres.in", "pistol")
                    .SetName("Register new user positive scenario")
                    .SetDescription("Validating registration method with valid & verified test data")
                    .SetCategory("positive"),
            };
        }

        public static TestCaseData[] RegisterUserNegativeTestData()
        {
            return new TestCaseData[]
            {
                new TestCaseData("johndee@gmail.com", "")
                    .SetName("Negative Registration Scenario")
                    .SetDescription("Testing Register Method by making request without password field")
                    .SetCategory("negative"),
            };
        }
    }
}
