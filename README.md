# WaterTrackerApp

Setup 
Open Sql server management studio and copy the server name, a local machine server would be best. In visual studio open the solution and open the appsettings.json file in the WaterTrackerAPI project. In the default connection string replace DESKTOP-HAOAOPE with the server name you copied. \n
Change the startup project in visual studio to WaterTrackerAPI. Run the program and copy the 4 numbers in the URL After https://localhost: \n

Open the program.cs file in the WaterTrackerBlazorApp project and replace the 4 numbers in this line with the one you just copied -  builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7190/") }); \n
Select multiple startup files, select WaterTrackerAPI and WaterTrackerAppBlazor, with the blazor project loading second(It is below the API). \n
You can now run the project.
