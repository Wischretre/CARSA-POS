# CarSaPOS - Carl Andrey C. Sabares

## Setup
1. In SSMS, connect with Windows Authentication and run `Database/01_CreateDatabase.sql`. This creates the `sabares` database.
2. Make sure your Windows account has access to `sabares`.
3. Open `CarSaPOS.sln` in Visual Studio, set the configuration to Release, and choose Rebuild Solution.
4. Run `CarSaPOS.exe` from `CarSaPOS.WinForms/bin/Release/`.
5. Sign in with the admin account in the app.

## Logs
Error logs are written to `%ProgramData%\CarSaPOS\Logs`.