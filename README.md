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
![image (7)](https://github.com/yaroslav-lysenko-axon/CrossAgerTest/assets/88324041/2803f6e8-dfdf-4198-a6bb-49a5529bc1d5)

2. Get clients group by id:
![image (3)](https://github.com/yaroslav-lysenko-axon/CrossAgerTest/assets/88324041/aa99acf3-5069-4e73-a715-864b82b446c3)

3. Create clients group (OnArrive method in service):
![image](https://github.com/yaroslav-lysenko-axon/CrossAgerTest/assets/88324041/9a2b7346-3b87-4e0e-9ceb-4de2b98f052e)

4. Delete clients group by id from queue and this group doesn't attended any tables:
![image (9)](https://github.com/yaroslav-lysenko-axon/CrossAgerTest/assets/88324041/26f8978f-f2b1-4d75-8ad5-59d3caadaaaa)

5. Delete clients group by id from table and this table was filled out by the groups from the queue:
![image (8)](https://github.com/yaroslav-lysenko-axon/CrossAgerTest/assets/88324041/e21dd3de-9ff3-4eec-8cf8-8c5889dca490)

6. Clients group table (groups with table_id = null and state 'Completed' decided to leave from queue):
<br>![image](https://github.com/yaroslav-lysenko-axon/CrossAgerTest/assets/88324041/0bb5eb6f-3b89-437e-a5b9-3dc11600e45a)
<br>![image (6)](https://github.com/yaroslav-lysenko-axon/CrossAgerTest/assets/88324041/599fe20d-c9bd-4e58-b3ff-aed067472b1e)

7. Table table:
<br>![image (5)](https://github.com/yaroslav-lysenko-axon/CrossAgerTest/assets/88324041/029dd3dc-adc6-427c-adc9-b48e04fb620e)


