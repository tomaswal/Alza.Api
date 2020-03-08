# Alza.Api
1) In appsettings.json file is connectionstring please change it
2) When you start the application then automaticly will be database updated with migration and will be added initial data from the seed.
This behavior you can change just remove Migration command in Startup.cs in Configure method
3) If you dont want to use database then you can change ProductRepository for FakeProductRepository in Startup.cs file
  there is some basic data for testing
