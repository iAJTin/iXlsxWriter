@ECHO OFF
CLS

..\src\.nuget\nuget Pack iXlsxWriter.1.0.0.nuspec -IncludeReferencedProjects -NoDefaultExcludes -NoPackageAnalysis -OutputDirectory ..\deployment\nuget 

pause

