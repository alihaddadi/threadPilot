using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Workflows.Common.ErrorResponses;
using Microsoft.Azure.Workflows.UnitTesting;
using Microsoft.Azure.Workflows.UnitTesting.Definitions;
using Microsoft.Azure.Workflows.UnitTesting.ErrorResponses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using threadPilotUserApi.Tests.Mocks.getUserInsuranceInfo;

namespace threadPilotUserApi.Tests
{
    /// <summary>
    /// The unit test class.
    /// </summary>
    [TestClass]
    public class InsuranceAndCarInfoUnitTest
    {
        /// <summary>
        /// The unit test executor.
        /// </summary>
        public TestExecutor TestExecutor;

        [TestInitialize]
        public void Setup()
        {
            this.TestExecutor = new TestExecutor("getUserInsuranceInfo/testSettings.config");
        }

        /// <summary>
        /// A sample unit test for executing the workflow named getUserInsuranceInfo with static mocked data.
        /// This method shows how to set up mock data, execute the workflow, and assert the outcome.
        /// </summary>
        [TestMethod]
        public async Task getUserInsuranceInfo_InsuranceAndCarInfoUnitTest_ExecuteWorkflow_SUCCESS_Sample1()
        {
            // PREPARE Mock
            // Generate mock action and trigger data.
            var mockData = this.GetTestMockDefinition();
            var sampleActionMock = mockData.ActionMocks["Call_Insurance_Info_API"];
            // sampleActionMock.Outputs["your-property-name"] = "your-property-value";

            // ACT
            // Create an instance of UnitTestExecutor, and run the workflow with the mock data.
            var testRun = await this.TestExecutor
                .Create()
                .RunWorkflowAsync(testMock: mockData).ConfigureAwait(continueOnCapturedContext: false);

            // ASSERT
            // Verify that the workflow executed successfully, and the status is 'Succeeded'.
            Assert.IsNotNull(value: testRun);
            Assert.AreEqual(expected: TestWorkflowStatus.Succeeded, actual: testRun.Status);
        }

        /// <summary>
        /// A sample unit test for executing the workflow named getUserInsuranceInfo with dynamic mocked data.
        /// This method shows how to set up mock data, execute the workflow, and assert the outcome.
        /// </summary>
        [TestMethod]
        public async Task getUserInsuranceInfo_InsuranceAndCarInfoUnitTest_ExecuteWorkflow_SUCCESS_Sample2()
        {
            // PREPARE
            // Generate mock action and trigger data.
            var mockData = this.GetTestMockDefinition();
            // OPTION 1 : defining a callback function
            mockData.ActionMocks["Call_Insurance_Info_API"] = new CallInsuranceInfoAPIActionMock(name: "Call_Insurance_Info_API", onGetActionMock: CallInsuranceInfoAPIActionMockOutputCallback);
            // OPTION 2: defining inline using a lambda
            mockData.ActionMocks["Call_Insurance_Info_API"] = new CallInsuranceInfoAPIActionMock(name: "Call_Insurance_Info_API", onGetActionMock: (testExecutionContext) =>
            {
                return new CallInsuranceInfoAPIActionMock(
                    status: TestWorkflowStatus.Succeeded,
                    outputs: new CallInsuranceInfoAPIActionOutput {
                        // set the desired properties here
                        // if this acount contains a JObject Body
                        // Body = "something".ToJObject()
                    }
                );
            });
            // ACT
            // Create an instance of UnitTestExecutor, and run the workflow with the mock data.
            var testRun = await this.TestExecutor
                .Create()
                .RunWorkflowAsync(testMock: mockData).ConfigureAwait(continueOnCapturedContext: false);

            // ASSERT
            // Verify that the workflow executed successfully, and the status is 'Succeeded'.
            Assert.IsNotNull(value: testRun);
            Assert.AreEqual(expected: TestWorkflowStatus.Succeeded, actual: testRun.Status);
        }

        /// <summary>
        /// A sample unit test for executing the workflow named getUserInsuranceInfo with failed mocked data.
        /// This method shows how to set up mock data, execute the workflow, and assert the outcome.
        /// </summary>
        [TestMethod]
        public async Task getUserInsuranceInfo_InsuranceAndCarInfoUnitTest_ExecuteWorkflow_FAILED_Sample3()
        {
            // PREPARE
            // Generate mock action and trigger data.
            var mockData = this.GetTestMockDefinition();
            var mockError = new TestErrorInfo(code: ErrorResponseCode.BadRequest, message: "Input is invalid.");
            mockData.ActionMocks["Call_Insurance_Info_API"] = new CallInsuranceInfoAPIActionMock(status: TestWorkflowStatus.Failed, error: mockError);

            // ACT
            // Create an instance of UnitTestExecutor, and run the workflow with the mock data.
            var testRun = await this.TestExecutor
                .Create()
                .RunWorkflowAsync(testMock: mockData).ConfigureAwait(continueOnCapturedContext: false);

            // ASSERT
            // Verify that the workflow executed successfully, and the status is 'Succeeded'.
            Assert.IsNotNull(value: testRun);
            Assert.AreEqual(expected: TestWorkflowStatus.Failed, actual: testRun.Status);
        }

        #region Mock generator helpers

        /// <summary>
        /// Returns deserialized test mock data.  
        /// </summary>
        private TestMockDefinition GetTestMockDefinition()
        {
            var mockDataPath = Path.Combine(TestExecutor.rootDirectory, "Tests", TestExecutor.logicAppName, TestExecutor.workflow, "InsuranceAndCarInfoUnitTest", "InsuranceAndCarInfoUnitTest-mock.json");
            return JsonConvert.DeserializeObject<TestMockDefinition>(File.ReadAllText(mockDataPath));
        }

        /// <summary>
        /// The callback method to dynamically generate mocked data for the action named 'actionName'.
        /// You can modify this method to return different mock status, outputs, and error based on the test scenario.
        /// </summary>
        /// <param name="context">The test execution context that contains information about the current test run.</param>
        public CallInsuranceInfoAPIActionMock CallInsuranceInfoAPIActionMockOutputCallback(TestExecutionContext context)
        {
            // Sample mock data : Modify the existing mocked data dynamically for "actionName".
            return new CallInsuranceInfoAPIActionMock(
                status: TestWorkflowStatus.Succeeded,
                outputs: new CallInsuranceInfoAPIActionOutput {
                    // set the desired properties here
                    // if this acount contains a JObject Body
                    // Body = "something".ToJObject()
                }
            );
        }

        #endregion
    }
}