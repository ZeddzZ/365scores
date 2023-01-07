# 365scores
This is an implementation of test assignment for project 365scores

Here will be some kind of documentation so you can understand overall idea of this Framework.
This is a Test Automation Framework Mainly designed for running UI and API Tests. That is why there are two separate project for Business Objects for these: PageObjects and APIModels.UI Testing is made by Selenium, so Page Objects use IWebElement, IWebDriver and Page Factory to do it easier.
At the same time, API Testing is using RestShart library, but it is fully incapsulated with API Client, so if we want we can use any library and no test cases needed to be changed.
Also, here you can find additional items that can ease work with tests and data like Message Queues, Databases, CSV Readers, Mocks and custom Configuration to make .config file more beatiful and readable.

Core project contatins all the stuff that can be reused within other frameworks and not depends on Business. Main Sections are: WebDriver, Configuration, API; All Base Items (BasePage, Base Test, Base Model) also stored here
Utilities projects, as it named, contains some helpers and utilities used by other components to reduse code duplication and make items accessible where they need.
PageObjects contains Business Logic used by UI Tests and implements Page Object pattern with usage of Page Factory for Lazy init and simplier page writing.
ApiModels contains Business Logic used by API tests (Model to convert JSON to) that can be easily checked with other sources (e.g. CSV or DB values)
TestScenarios contains all the tests from out solution, splitted by folders, so we have single place to run everything and work with it. Also test parallel execution is implemented within BaseTest class

All the test result by default are stored at '%Execution folder%/TestResults/%datetime of run start in format yyyy_MM_dd-hh_mm_ss%/%Test result%' where will be next files: Test log in .txt format and batch of screenshots (only for UI tests) with names %Test Name%.txt and %Test Name%_%Number of Screenshot%.png, they both attached to NUnit results so can be uploaded to any Report System
Configuration is stored under TestScenarios project and on build is copied to execution folder
BaseModel overrides ToString method, so you can write any API Models without additional parsing

If you will have additional questions, feel free to contact me and ask.
