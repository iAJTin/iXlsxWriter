@ECHO OFF
CLS

rmdir ..\documentation /s /q

xmldocmd ..\src\lib\iXlsxWriter\bin\Debug\netstandard2.0\iXlsxWriter.dll ..\documentation

PAUSE