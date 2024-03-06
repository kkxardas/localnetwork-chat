# localnetwork-chat
This is a simple chat in which you can communicate via local network

## Requirements
  * .NET 7.0

## How to use it
  * First of all change connection string to yours in class AppDbContext
  * Add migration and update database via nuget terminal ```Add-Migration InitDB``` ```Update-Database```
  * Change your credentials if you want to send email verification code(In form LogUp)
