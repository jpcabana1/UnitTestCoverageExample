# UnitTestCoverageExample

## Code coverage Local + Sonar

- dotnet sonarscanner begin /k:"app" /d:sonar.login="sqp_f5734570193fcc42deb8a3388037a194801a4dcd" /d:sonar.cs.opencover.reportsPaths=coverage.xml
- dotnet build --no-incremental
- coverlet .\bin\Debug\net6.0\app.test.dll --target "dotnet" --targetargs "test --no-build" -f=opencover -o="coverage.xml"
- dotnet sonarscanner end /d:sonar.login="sqp_f5734570193fcc42deb8a3388037a194801a4dcd"
- reportgenerator -reports:".\coverage.xml" -targetdir:"CoverageReport" -reporttypes:Html
- clear

## DotCover Sonar 
- dotnet tool install --global JetBrains.dotCover.GlobalTool
- dotnet sonarscanner begin /k:"app" /d:sonar.login="sqp_f5734570193fcc42deb8a3388037a194801a4dcd" /d:sonar.cs.dotcover.reportsPaths=dotCover.Output.html
- dotnet build –no-incremental
- dotnet dotcover test --dcReportType=HTML
- dotnet sonarscanner end /d:sonar.login="sqp_f5734570193fcc42deb8a3388037a194801a4dcd"
- clear

## Coverlet Sonar
- dotnet sonarscanner begin /k:"app" /d:sonar.login="sqp_f5734570193fcc42deb8a3388037a194801a4dcd" /d:sonar.cs.opencover.reportsPaths=coverage.xml
- dotnet build --no-incremental 
- coverlet .\bin\Debug\net6.0\app.test.dll --target "dotnet"  --targetargs "test --no-build" -f=opencover  -o="coverage.xml"
- dotnet sonarscanner end /d:sonar.login="sqp_f5734570193fcc42deb8a3388037a194801a4dcd"