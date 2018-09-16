NAME: MICHAEL K

*The Automation Framework is written using Specflow and Page Object Model.
*Due to the time constraints and family responsibilities, 
it's only intended to illustrate the code and framework structure as well as implementation, whilst keeping the tests to purpose.

*I decided on using Specflow as it's the current industry standard and just a week ago, I started implementing a new framework based on the same code principle.
* I used Nunit for all assertions mainly because I've used it since day one and it's never disappointed me.
* Code write using Visual studio 2017 using 4.71 .Net Framework.

Requirements
            * To review and test the code in Microsoft Visual studio, you need to install specflow framework in your IDE
            * To run Tests within Visual Studio, please make sure Nunt adaptor is installed

NB: Code only tested within visual studio, see screenshot attached

FRAMEWORK STRUCTURE:
              There are 4 projects this solution
1) Auden Exercise: Contains all the Page Object Classes and Page implementation logic
2) Auden.Exercise.Common: Contains and would contain all common methods and all constants shared across the solution
3) Auden.Exercise.Tests : This is where all tests would go, it contais features and code bindings
4) Auden.Exercise.Webdriver: This is where we have the driver custom methods

REMARKS:
        In an ideal world, a failure would be noted down and save in a file (Excel spreadsheet), screen shot would be taken and 
attached and perhaps an email would be triggered results and attachments

Michael K.