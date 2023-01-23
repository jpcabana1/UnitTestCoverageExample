# UnitTestCoverageExample

## Code coverage local

- dotnet tool install -g dotnet-reportgenerator-globaltool
- dotnet test --collect:"XPlat Code Coverage"
- reportgenerator -reports:"PATH TO coverage.cobertura.xml" -targetdir:"CoverageReport" -reporttypes:Html


## Code coverage Sonar
- dotnet tool install --global JetBrains.dotCover.GlobalTool
- dotnet sonarscanner begin /k:"app" /d:sonar.login="sqp_f5734570193fcc42deb8a3388037a194801a4dcd" /d:sonar.cs.dotcover.reportsPaths=dotCover.Output.html
- dotnet build –no-incremental
- dotnet dotcover test --dcReportType=HTML /p:ExcludeByFile="**/program.cs"
- dotnet sonarscanner end /d:sonar.login="sqp_f5734570193fcc42deb8a3388037a194801a4dcd"