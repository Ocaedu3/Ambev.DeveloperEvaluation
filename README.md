The project need a localhost Postgree SQL database with same parameteres of the DefaultConnection of the application
All the migrations are alredy created, just execute a update-database, to create all necessaries tables
The api does not have an endpoint to register entities other than sales, this entities must have de alredy be created in the databse before use
For the put method if you want to modify the only the sale (and not the sale items) you dont need to inform the SaleProduct array, and if you want 
modify the items, only inform the itens you want to update with his respectve correct id
The logs for events: * SaleCreated * SaleModified * SaleCancelled * ItemCancelled where created

For any doubts, im at your disposal.
