@echo off

call npm install 
cd src
dotnet tool restore
dotnet restore
cd ../
npm start