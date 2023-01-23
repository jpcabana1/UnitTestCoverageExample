# UnitTestCoverageExample

## Commands Sumary

- dotnet tool install -g dotnet-reportgenerator-globaltool
- dotnet test --collect:"XPlat Code Coverage"
- reportgenerator -reports:"PATH TO coverage.cobertura.xml" -targetdir:"CoverageReport" -reporttypes:Html