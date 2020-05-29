# API-Lansweeper
Web API for Lansweeper. Get Information what Software is installed on Computers by HTTP Requests.

## What you will need:
* Windows Server with IIS installed incl. .Net 4.5 Features
* Lansweeper that is running on SQL Server (at least SQLExpress)
* Lansweeper Datebase Credentials for the web.config
* Microsoft Web Deploy 3.6 installed on IIS Server

## How to install

Download the current WebDeploy Package from the Releases Directory. Unzip the directory und run the .cmd File with Parameter /Y (As Admin User). If the Installation fails, check if your IIS Default Page is named: "Default Web Site".

After Installation you need to change the Connection String to your Lansweeper Database in the web.config File (Website Directory)

Check working Installation by trying to access the Lansweeper JSON Data: http://hostname:port/api/Values
You should get an JSON Result.

[German Info Page from the Softwaredeveloper](https://www.marcogriep.de/blog/vorstellung-lansweeper-web-api/)
