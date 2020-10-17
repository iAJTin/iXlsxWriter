@ECHO OFF
CLS

..\src\.nuget\nuget Pack iXlsxWriter.1.0.1.nuspec -IncludeReferencedProjects -NoDefaultExcludes -NoPackageAnalysis -OutputDirectory ..\deployment\nuget 

pause

