**To run this project locally, you need:**

1. Clone using the web URL (https://github.com/yaroslav-lysenko-axon/CrossAgerTest.git) or use a password-protected SSH key (git@github.com:yaroslav-lysenko-axon/CrossAgerTest.git) and open in your IDE via "Get from Version Control" menu;
2. Find in CrossAgerTest.Host -> Properties -> launchSettings.json. Click Run Profile against the 4th row;
3. Change connection string in appsettings.json to your credentials to connect to the sql server;
4. Press button "Run" in IDE. The migrations will be completed automatically. After that you can find VersionInfo, task and user table directly into dbo in your database;
5. Go by this link "http://localhost:5001/swagger/index.html" to Browser (to use Swagger);
