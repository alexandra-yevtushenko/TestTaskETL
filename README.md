# TestTaskETL
Additional tools used: 
  Entity Framework for data manipulation 
  CSV helper for file reading/writing

1. SQL-scripts for creating database and tables
   CREATE DATABASE TestTaskDB;
   CREATE TABLE [SampleData] (
        [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        [TpepPickupDatetime] DATETIME2 NOT NULL,
        [TpepDropoffDatetime] DATETIME2 NOT NULL,
        [PassengerCount] INT NULL,
        [TripDistance] REAL NOT NULL,
        [StoreAndFwdFlag] NVARCHAR(MAX) NOT NULL,
        [PULocationId] INT NOT NULL,
        [DOLocationId] INT NOT NULL,
        [FareAmount] REAL NOT NULL,
        [TipAmount] REAL NOT NULL
    );

    CREATE INDEX [IX_SampleData_FareAmount]
    ON [SampleData] ([FareAmount]);
    
    CREATE INDEX [IX_SampleData_PULocationId]
    ON [SampleData] ([PULocationId]);
   
Also attached Initial Migration code.
Naming was chosen just for a test project, not a real production DB.

2. Final number of rows in table = 29889
3. For large datasets we can use alternative insertion methods:
   For example, manually divide our list to chunks and write to DB
    const int batchSize = 1000;
    foreach (var batch in tableRecords.Chunk(batchSize))
    {
        context.AddRange(batch);
        await context.SaveChangesAsync();
        context.ChangeTracker.Clear();
    }

   Or use Bulk Insert Library from NuGet.






