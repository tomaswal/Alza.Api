# Alza.Api
1) There is connectionstring n appsettings.json file please change it
2) When you start the application then database will be automaticly updated with migration and initial data will be added from the seed.
This behavior you can change just remove Migration command in Startup.cs in Configure method
3) If you dont want to use database then you can change ProductRepository for FakeProductRepository in Startup.cs file
  there are some basic data for testing
