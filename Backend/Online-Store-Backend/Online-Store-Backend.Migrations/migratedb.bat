set /p Name=Enter migration name 
dotnet ef migrations add %Name%
pause