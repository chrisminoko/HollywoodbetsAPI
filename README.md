# HollywoodbetsAPI
The Hollywoodbet API is built using DotNet Core 3.1 and Dapper as the ORM. Repository pattern and long side a database first approach has been used to structure to project.
The Main Site reads from the API and get the data from the Db and the admin site does all the crud for the database and reflects on the main site which is the bet striking site.
Model Folder Includes the following classes:

Sport Types
Countries
Markets
Bet Types
Tournaments
Odds
Events

Association Tables are 
Sport-Country
Tournament-Bettypes
Sport-Tournaments
Odds-Events
Bettype-Markets.

The Project also comes with an Admin Section to perform all crud related actions Eg The creation of sports , Bet types , Markets etc and the mapping of the association tables to the correct classes. This is built using Angular 9 and Boostrap 4. 
The link below is for the FrontEnd
https://github.com/chrisminoko/AdminSection
The link below is for the BackEnd
https://github.com/chrisminoko/HollywoodbetsAPI

The Main site is built using angular 9 as well, You can view various sport, bettypes , odds and even strick
![image](https://user-images.githubusercontent.com/42572223/88549812-0e432100-d021-11ea-8c91-72183db6924a.png)
![image](https://user-images.githubusercontent.com/42572223/88543691-a12b8d80-d018-11ea-87da-127849e2605c.png)
![image](https://user-images.githubusercontent.com/42572223/88543763-baccd500-d018-11ea-95c9-e71aa44e5cf2.png)
![image](https://user-images.githubusercontent.com/42572223/88543810-ce783b80-d018-11ea-99be-ecc854c04e2e.png)
![image](https://user-images.githubusercontent.com/42572223/88543863-df28b180-d018-11ea-81f0-ee7201bbc8ed.png)
![image](https://user-images.githubusercontent.com/42572223/88543923-f5367200-d018-11ea-86f7-982fe5bed2b7.png)
![image](https://user-images.githubusercontent.com/42572223/88543955-ff587080-d018-11ea-96a1-58ffb9647bf3.png)
![image](https://user-images.githubusercontent.com/42572223/88543996-0e3f2300-d019-11ea-900a-e243932e69ab.png)
![image](https://user-images.githubusercontent.com/42572223/88544046-1eef9900-d019-11ea-9b15-a4125142b893.png)
