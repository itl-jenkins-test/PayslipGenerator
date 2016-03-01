# Salary Manager 

Command Line Client to generate Payslip based on employee(s) data.

### Project Organisation
* The project is organised into [milestones] (https://github.com/cryptomatt/PayslipGenerator/milestones)
* Issues indicate the work that has to be done per milestone
* Each feature has been coded as much as possible into it's own branch
* After getting it to work along with testing, the code is merged into master. The history of the project can be seen [here] (https://github.com/cryptomatt/PayslipGenerator/network)
* Once all the issues in a milestone are completed, the commit in master is tagged with the milestone name

### Assumptions
* Not many assumptions actually. Except that the date should be entered in yyy-mm-dd format
* I haven't put much work into ordering the CSV output format but it is not a difficult task given the library being used.


### Solution Dependencies
To make things a little easier, a few open source libraries were used to provide specialised functionality
* [CSVHelper] (http://joshclose.github.io/CsvHelper/) Used for processing CSV files. Allows for both read and write of files. Converts standard data types from CSV files into the corresponding property in the Entity
* [CommandLine] (https://github.com/gsscoder/commandline) Used for processing command line options and provide a well defined interface to the Console application.


### Solution Organisation
The project itself is divided into 3 portions, with each main project having its own specific Test Project.

* **SalaryMgr.Model**
This project contains the entities involved in the project. Mainly **Employee**, **Payslip**, **TaxRules**

* **SalaryMgr.Service**
This project contains the ServiceProvider as a way of decoupling the interface definitions to their actual implementations. The console class and eventually any web app can use the **ServiceProvider** class to get the same functionality.

* **PayslipGeneratorConsole**
This project contains the console app as a default client for interacting with the Salary Manager back end. 

### Building the application
* Requirements VS 2015 Community Edition
* Clone the [repository](https://github.com/cryptomatt/PayslipGenerator) as usual. _master_ branch contains the latest code
* Have hardwired mstest location within build.proj. Please update it to suit your machine
* Open the solution within Visual Studio and restore NuGet packages
* Build solution as normal
* Command Line`msbuild build.proj /t:build`

### Testing the application
* In Visual Studio just run all tests as usual
* Command Line `msbuild build.proj /t:test`

### Executing the application

* Command Line

running `PayslipGeneratorConsole` will provide a detailed help about the command line app and its usage 

```
  -i, --input         Required. Input mode. Options console|file

  -s, --inputfile     Provide the name of the file containing employee records.
                      CSV file

  -o, --output        Required. Output mode. Options console|file

  -t, --outputfile    (Default: N) Provide the name of the file for the payslip
                      records

  -v, --verbose       (Default: False) Prints all messages to standard output.

  --help              Display this help screen.
```  

* Choosing console for input will allow you to accept Employee records through the console. This can be for any number of records
* Choosing file for input will allow you to select a CSV file. This file has to contain text in the following format

```
FirstName,LastName,Salary,SuperRate,StartDate,EndDate
David,Rudd,60050,9,2012-03-01,2012-03-30
Ryan,Chen,120000,10,2012-03-01,2012-03-30
```

## [Outstanding Issues] (https://github.com/cryptomatt/PayslipGenerator/issues)

  


