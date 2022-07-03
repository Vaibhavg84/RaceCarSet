# Race Car SetUp 
 ## _Technical Arctiture_

[![N|Solid](https://www.secret-source.eu/wp-content/uploads/2017/11/microsoft-net-logo.jpg)](https://nodesource.com/products/nsolid)
```sh
Solution uses .Net 6.0 and UnitTest Project use MSTest. 
Code Coverage report is generated with FineCodeCoverage tool. 
Source code added in Git with public rights. Library havn’t any dependencies. 
Unit Test project having Moq(4.18.1) and Microsoft.NET.Test.SDk(16.11.0) dependencies.
SonarQube Integration for Code Analysis.
```



## Race Solution consist fo 3 Projects.

- RaceSetUpLibrary : Core Logic is written under this. Interface ICarSetUp having SetCarRanks for calculating the car ranks on race completion time.
- RaceTestProject : This is unit test project for RaceSetUpLibrary. % different test method are written to test the logic of the code. 80% code coverage is done. Report is generated with the help of FineCodeCoverage tool.
- Race: This is console app, which use the RaceSetUpLibrary. This is just for demonstrate the usage of the SetCarRanks method. It generate the output like below:

## Sonar Qube Code Analysis Report


| Tool | Descrption |
| ------ | ------ |
| Code Coverage | 80% |
| Vulnerabilities  | Rating A |
| Code Smells | No Issues  |
| Security Hotspot | No Issues - Rating A |
| Reliablity | Rating A |
| Maintainability | Rating A |

## Console Output
```sh
Car Rank: 1

Car Race Completion Time: 1509

Car Details: -----

Car Fuel Capacity: 189

Car Lap Completion Time: 30

Car Lap Fuel Consumption: 8

Car Rank: 2

Car Race Completion Time: 1603

Car Details: -----

Car Fuel Capacity: 258

Car Lap Completion Time: 32

Car Lap Fuel Consumption: 5

Car Rank: 3

Car Race Completion Time: 1809

Car Details: -----

Car Fuel Capacity: 151

Car Lap Completion Time: 36

Car Lap Fuel Consumption: 8

Car Rank: 4

Car Race Completion Time: 2306

Car Details: -----

Car Fuel Capacity: 276

Car Lap Completion Time: 46

Car Lap Fuel Consumption: 9

Car Rank: 5

Car Race Completion Time: 2309

Car Details: -----

Car Fuel Capacity: 156

Car Lap Completion Time: 46

Car Lap Fuel Consumption: 9
```

### Vaibhav Gupta
