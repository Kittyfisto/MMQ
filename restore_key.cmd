@setlocal
@echo off

sig\crypt.exe decrypt sig\sns key.snk
sig\crypt.exe enablesigning src\MMQ\MMQ.csproj ..\..\key.snk
sig\crypt.exe enablesigning src\MMQ.Test\MMQ.Test.csproj ..\..\key.snk netstandard
