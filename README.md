# awme
 ![GitHub last commit](https://img.shields.io/github/last-commit/Vaidual/awme)
 
Back-end for animal collar managment/promotion system build on ASP.NET Core Web API.

## Features:
- Rest API.
- JWT token authorization.
- Interaction with hardware emulator (emulating smart collar) through mqtt client.

## Installation

1. Clone git repo.
2. In appsetting.json set you database connection string, eg. `Data Source=your_connection_string;...`
3. Create database by running `dotnet ef database update` in .NET CLI or `Update-Database` in PowerShell.
4. Install [front-end](https://github.com/Vaidual/awme-react) and run it.
