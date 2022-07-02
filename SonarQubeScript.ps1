dotnet sonarscanner begin /k:"RaceCarSetup" /d:sonar.host.url="http://localhost:9000"  /d:sonar.login="sqp_bf5d60ddf7d0fcf58fe0cf1fab88596c103da498" /d:sonar.cs.vscoveragexml.reportsPaths=coverage.xml
dotnet build --no-incremental
dotnet-coverage collect 'dotnet test' -f xml  -o 'coverage.xml'
dotnet sonarscanner end /d:sonar.login="sqp_bf5d60ddf7d0fcf58fe0cf1fab88596c103da498"