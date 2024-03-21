**I worked on this test task for 10 hours.**

**To run this project locally, you need:**
1. Clone using the web URL (https://github.com/yaroslav-lysenko-axon/CrossAgerTest.git) or use a password-protected SSH key (git@github.com:yaroslav-lysenko-axon/CrossAgerTest.git) and open in your IDE via "Get from Version Control" menu;
2. Find in CrossAgerTest.Host -> Properties -> launchSettings.json. Click Run Profile against the 4th row;
3. Change connection string in appsettings.json to your credentials to connect to the sql server;
4. Press button "Run" in IDE. The migrations will be completed automatically. After that you can find VersionInfo, _clients_group_ and _table_ table directly into dbo in your database;
5. Go by this link "http://localhost:5001/swagger/index.html" to Browser (to use Swagger);

**There are four http methods to:**
1. Get tables (GET);
2. Get clients group by id (GET);
3. Create clients group (POST);
4. Delete clients group by id (DELETE). I made the decision not to delete clients gropus completely, but will instead mark their state as 'Completed'.

**Local screenshoots:**
1. Get all tables:
![image](https://github.com/yaroslav-lysenko-axon/CrossAgerTest/assets/88324041/2f44463a-0cb4-45b3-932c-b9439f46d1b9)

2. Get clients group by id:
![image](https://github.com/yaroslav-lysenko-axon/CrossAgerTest/assets/88324041/7b1bd52f-0d76-48e4-be2a-67bcfebe93d9)

3. Create clients group (OnArrive method in service):
![image](https://github.com/yaroslav-lysenko-axon/CrossAgerTest/assets/88324041/80df98d7-8781-48cd-9f8d-fb98e8f85dcb)

4. Delete clients group by id from queue and this group doesn't attended any tables:
![image](https://github.com/yaroslav-lysenko-axon/CrossAgerTest/assets/88324041/bb8d850f-1aad-400b-90c2-30d86bbf72c9)

5. Delete clients group by id from table and this table was filled out by the groups from the queue:
![image](https://github.com/yaroslav-lysenko-axon/CrossAgerTest/assets/88324041/48fef4bf-3f79-4e6e-a417-1c5b1be5ba2c)

6. Clients group table (groups with table_id = null decided to leave):
<br>![image](https://github.com/yaroslav-lysenko-axon/CrossAgerTest/assets/88324041/0bb5eb6f-3b89-437e-a5b9-3dc11600e45a)
<br>![image](https://github.com/yaroslav-lysenko-axon/CrossAgerTest/assets/88324041/79640226-8c3f-41af-b47b-02d688ac5d18)

7. Table table:
<br>![image](https://github.com/yaroslav-lysenko-axon/CrossAgerTest/assets/88324041/9008102a-170e-43c5-9771-b5a796abb14d)


