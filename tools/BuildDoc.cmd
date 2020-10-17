@ECHO OFF
CLS

rmdir ..\documentation /s /q

xmldocmd ..\src\lib\iTin.Utilities\iTin.Utilities.Xlsx\iTin.Utilities.Xlsx.Design\bin\Release\net461\iTin.Utilities.Xlsx.Design.dll ..\documentation
xmldocmd ..\src\lib\iTin.Utilities\iTin.Utilities.Xlsx\iTin.Utilities.Xlsx.Writer\bin\Release\net461\iTin.Utilities.Xlsx.Writer.dll ..\documentation

PAUSE
