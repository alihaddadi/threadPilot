using Microsoft.Azure.Workflows.UnitTesting.Definitions;
using Microsoft.Azure.Workflows.UnitTesting.ErrorResponses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net;
using System;

namespace threadPilotUserApi.Tests.Mocks.getUserInsuranceInfo
{
    /// <summary>
    /// The <see cref="CallInsuranceInfoAPIActionMock"/> class.
    /// </summary>
    public class CallInsuranceInfoAPIActionMock : ActionMock
    {
        /// <summary>
        /// Creates a mocked instance for  <see cref="CallInsuranceInfoAPIActionMock"/> with static outputs.
        /// </summary>
        public CallInsuranceInfoAPIActionMock(TestWorkflowStatus status = TestWorkflowStatus.Succeeded, string name = null, CallInsuranceInfoAPIActionOutput outputs = null)
            : base(status: status, name: name, outputs: outputs ?? new CallInsuranceInfoAPIActionOutput())
        {
        }

        /// <summary>
        /// Creates a mocked instance for  <see cref="CallInsuranceInfoAPIActionMock"/> with static error info.
        /// </summary>
        public CallInsuranceInfoAPIActionMock(TestWorkflowStatus status, string name = null, TestErrorInfo error = null)
            : base(status: status, name: name, error: error)
        {
        }

        /// <summary>
        /// Creates a mocked instance for <see cref="CallInsuranceInfoAPIActionMock"/> with a callback function for dynamic outputs.
        /// </summary>
        public CallInsuranceInfoAPIActionMock(Func<TestExecutionContext, CallInsuranceInfoAPIActionMock> onGetActionMock, string name = null)
            : base(onGetActionMock: onGetActionMock, name: name)
        {
        }
    }


    /// <summary>
    /// Class for CallInsuranceInfoAPIActionOutput representing an object with properties.
    /// </summary>
    public class CallInsuranceInfoAPIActionOutput : MockOutput
    {
        public JObject Body { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CallInsuranceInfoAPIActionOutput"/> class.
        /// </summary>
        public CallInsuranceInfoAPIActionOutput()
        {
            this.StatusCode = HttpStatusCode.OK;
            this.Body = new JObject();
        }

    }

}