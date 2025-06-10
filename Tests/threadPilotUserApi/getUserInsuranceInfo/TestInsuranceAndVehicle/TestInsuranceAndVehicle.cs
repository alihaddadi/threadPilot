using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.Workflows.UnitTesting.Definitions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using threadPilotUserApi.Tests.Mocks.getUserInsuranceInfo;

namespace threadPilotUserApi.Tests
{
    /// <summary>
    /// The unit test class.
    /// </summary>
    [TestClass]
    public class TestInsuranceAndVehicle
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
        public async Task getUserInsuranceInfo_TestInsuranceAndVehicle_ExecuteWorkflow_SUCCESS_Sample1()
        {
            // PREPARE Mock
            // Generate mock trigger data.
            var triggerMockOutput = new InsuranceInfoTriggerOutput();
            // Sample of how to set the properties of the triggerMockOutput
            // triggerMockOutput.Body.Id = "SampleId";
            var triggerMock = new InsuranceInfoTriggerMock(outputs: triggerMockOutput);

            // Generate mock action data.
            var actionMockOutput = new CallInsuranceInfoAPIActionOutput();
            // Sample of how to set the properties of the actionMockOutput
            // actionMockOutput.Body.Name = "SampleResource";
            // actionMockOutput.Body.Id = "SampleId";
            var actionMock = new CallInsuranceInfoAPIActionMock(name: "Call_Insurance_Info_API", outputs: actionMockOutput);

            // ACT
            // Create an instance of UnitTestExecutor, and run the workflow with the mock data.
            var testMock = new TestMockDefinition(
                triggerMock: triggerMock,
                actionMocks: new Dictionary<string, ActionMock>()
                {
                    {actionMock.Name, actionMock}
                });
            var testRun = await this.TestExecutor
                .Create()
                .RunWorkflowAsync(testMock: testMock).ConfigureAwait(continueOnCapturedContext: false);

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
        public async Task getUserInsuranceInfo_TestInsuranceAndVehicle_ExecuteWorkflow_SUCCESS_Sample2()
        {
            // PREPARE
            // Generate mock trigger data.
            var triggerMockOutput = new InsuranceInfoTriggerOutput();
            // Sample of how to set the properties of the triggerMockOutput
            // triggerMockOutput.Body.Flag = true;
            var triggerMock = new InsuranceInfoTriggerMock(outputs: triggerMockOutput);

            // Generate mock action data.
            // OPTION 1 : defining a callback function
            var actionMock = new CallInsuranceInfoAPIActionMock(name: "Call_Insurance_Info_API", onGetActionMock: CallInsuranceInfoAPIActionMockOutputCallback);
            // OPTION 2: defining inline using a lambda
            /*var actionMock = new CallInsuranceInfoAPIActionMock(name: "Call_Insurance_Info_API", onGetActionMock: (testExecutionContext) =>
            {
                return new CallInsuranceInfoAPIActionMock(
                    status: TestWorkflowStatus.Succeeded,
                    outputs: new CallInsuranceInfoAPIActionOutput {
                        // set the desired properties here
                        // if this acount contains a JObject Body
                        // Body = "something".ToJObject()
                    }
                );
            });*/

            // ACT
            // Create an instance of UnitTestExecutor, and run the workflow with the mock data.
            var testMock = new TestMockDefinition(
                triggerMock: triggerMock,
                actionMocks: new Dictionary<string, ActionMock>()
                {
                    {actionMock.Name, actionMock}
                });
            var testRun = await this.TestExecutor
                .Create()
                .RunWorkflowAsync(testMock: testMock).ConfigureAwait(continueOnCapturedContext: false);

            // ASSERT
            // Verify that the workflow executed successfully, and the status is 'Succeeded'.
            Assert.IsNotNull(value: testRun);
            Assert.AreEqual(expected: TestWorkflowStatus.Succeeded, actual: testRun.Status);
        }

        #region Mock generator helpers

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