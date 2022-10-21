using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace APITests.TestingData
{
    public class TestDataConfig
    {
        /* The method to read test data from file is not 
         * going to be used for now, therefor it's commented out
         * 
         * public static List<TestCaseData> UserInfoFromJson()
        {
            // Obtain info for user creation from json file
            // located in the same TestingData folder
            // Set individual test parameters by parsing the file
            var filePath = "UserInfo.json";
            var fileContent = File.ReadAllText(filePath);
            var userInfo = JsonConvert.DeserializeObject<List<ExternalUserData>>(fileContent);
            var testCases = new List<TestCaseData>();   

            foreach (var test in userInfo)
            {
                var testCase = new TestCaseData(test.UserData)
                                   .SetName(test.TestName)
                                   .SetDescription(test.Description);

                test.Categories.ForEach(category => testCase.SetCategory(category));

                if (test.IsExplicit)
                {
                    testCase.Explicit();
                }

                if (test.IsIgnored)
                {
                    testCase.Ignore(test.IgnoreReason);
                }

                testCases.Add(testCase);
            }
            return testCases;   
        }
        */
        
                
        public static TestCaseData[] PostUsersTestData()
        {
            return new TestCaseData[]
            {
                new TestCaseData("John", "QA")
                    .SetName("TestName")
                    .SetDescription("TestDescription"),

                new TestCaseData("Yu", "Software Engineer")
                    .SetName("TestName")
                    .SetDescription("TestDescription"),
                
                new TestCaseData("Ferdinant-Marcisce", "CEO")
                    .SetName("TestName")
                    .SetDescription("TestDescription")
            };
        }
    }
}
