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
    /// The <see cref="InsuranceInfoTriggerMock"/> class.
    /// </summary>
    public class InsuranceInfoTriggerMock : TriggerMock
    {
        /// <summary>
        /// Creates a mocked instance for  <see cref="InsuranceInfoTriggerMock"/> with static outputs.
        /// </summary>
        public InsuranceInfoTriggerMock(TestWorkflowStatus status = TestWorkflowStatus.Succeeded, string name = null, InsuranceInfoTriggerOutput outputs = null)
            : base(status: status, name: name, outputs: outputs ?? new InsuranceInfoTriggerOutput())
        {
        }

        /// <summary>
        /// Creates a mocked instance for  <see cref="InsuranceInfoTriggerMock"/> with static error info.
        /// </summary>
        public InsuranceInfoTriggerMock(TestWorkflowStatus status, string name = null, TestErrorInfo error = null)
            : base(status: status, name: name, error: error)
        {
        }

        /// <summary>
        /// Creates a mocked instance for <see cref="InsuranceInfoTriggerMock"/> with a callback function for dynamic outputs.
        /// </summary>
        public InsuranceInfoTriggerMock(Func<TestExecutionContext, InsuranceInfoTriggerMock> onGetTriggerMock, string name = null)
            : base(onGetTriggerMock: onGetTriggerMock, name: name)
        {
        }
    }


    /// <summary>
    /// Class for InsuranceInfoTriggerOutput representing an object with properties.
    /// </summary>
    public class InsuranceInfoTriggerOutput : MockOutput
    {
        public InsuranceInfoTriggerOutputBody Body { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InsuranceInfoTriggerOutput"/> class.
        /// </summary>
        public InsuranceInfoTriggerOutput()
        {
            this.StatusCode = HttpStatusCode.OK;
            this.Body = new InsuranceInfoTriggerOutputBody();
        }

    }

    /// <summary>
    /// Class for InsuranceInfoTriggerOutputBody representing an object with properties.
    /// </summary>
    public class InsuranceInfoTriggerOutputBody
    {
        public string SSN { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="InsuranceInfoTriggerOutputBody"/> class.
        /// </summary>
        public InsuranceInfoTriggerOutputBody()
        {
            this.SSN = string.Empty;
        }

    }

}