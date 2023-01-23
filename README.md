# UnitTestCoverageExample

## Commands Sumary

- dotnet tool install -g dotnet-reportgenerator-globaltool
- dotnet test --collect:"XPlat Code Coverage"
- reportgenerator -reports:"C:\DEV\UnitTestCoverageExample\src\app.test\TestResults\1a793bec-aad2-4633-9f96-0b7f0552452d\coverage.cobertura.xml" -targetdir:"TestResultsCoverage" -reporttypes:Html