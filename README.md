You will find a description of the following in this READ.ME:

a. Architecture

b. How to run the solutions locally

c. Error handling

d. Maintenance and extinsibility

e. Security provisioning

a. Architecture:

The ThreadPilot solution follows a 2-layer API approach:
- System Layer: Connects to data source systems and presents their data using REST APIs.
- User Layer: Presents the data to consumers, retrieves it from the system layer, combines multiple sources, and applies transformations and validations. Optional business logic can be applied at this layer in complex scenarios.

The solution includes the following projects:

- threadPilotInsuranceInfo: Azure function app for insurance data.
- threadPilotVehicleInfo: Azure function app for vehicle data.

Both projects follow the MVC pattern, have unit tests, and can be run by using unit test files or .http files.

The ThreadPilotUserApi contains an Azure Logic App solution called getUserInsuranceInfo that combines data from the insurance and vehicle projects based on requirements.
Source: Internal documentation

b. How to run the solutions locally:

To run the Azure function app projects, open the folders individually in VSCode or open threadPilotApi.sln in Visual Studio.
For the Azure Logic App, open the solution in Visual Studio 2019 or VSCode. Modify the base URLs (SYSTEM_API_INSURANCE_URL and SYSTEM_API_VEHICLE_URL) in the workflow parameters. Debug the Logic App and use Postman to send a POST request to the endpoint shown in the overview.

c. Error handling:

Exception handling is implemented in the projects to handle various error cases. The Logic App handles exceptions by returning appropriate error messages or responses.

d. Maintenance and Extensibility:

The design focuses on minimal changes in the data access layer and flexibility in the user access layer. To add a new system access layer, copy an existing project structure and implement new APIs. For each distinct data source, create a new independent system API project. The user API layer can be extended by combining multiple data sources based on business requirements.

e. Security Provisioning:

Security best practices include: 
-deploying system layer function apps to private VNETs using limited access from logic apps.
-deploying logic apps to private VNETs or restricting internet access, and managing access using application gateway and APIM. 
-Access between logic apps and function apps should follow Azure best practices, such as OAuth flows or Azure managed Identity, while avoiding static tokens or keys.
