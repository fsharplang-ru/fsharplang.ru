@echo off

call npm install
cd src
dotnet restore
dotnet fable npm-start