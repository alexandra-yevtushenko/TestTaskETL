# TestTaskETL
#### Additional tools used: 
  - **Entity Framework** for data manipulation   
  - **CSVHelper** for file reading/writing

### 1. SQL-scripts for creating database and tables   

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
Indexes chosen for 2 colums, which will be frequently used for users' requests `FareAmount` and `PULocationId`.  

### 2. Final number of rows in table = 29889
Why?   
PassengerCount field contain NULLs, so when we find duplicates using it, more rows will be affected. I didn't replace or delete rows with NULLs.  

### 3. Data Preprocessing
- Removed duplicates using LINQ
- Changed timezone to UTC for `TpepPickupDatetime` and `TpepDropoffDatetime` using TimezoneConverter
- Replaced "Y" to "Yes" and "N" to "No" in `StoreAndFwdFlag`
- Trimmed string column `StoreAndFwdFlag`

### 4. For large datasets we can use alternative insertion methods:
   - For example, manually divide our list to chunks and write to DB each chuck separately:  

    const int batchSize = 1000;
    foreach (var batch in tableRecords.Chunk(batchSize))
    {
        context.AddRange(batch);
        await context.SaveChangesAsync();
        context.ChangeTracker.Clear();
    }

   - Or use Bulk Insert Library from NuGet.  

    await dbContext.BulkInsertAsync(tableRecords);  


### 5. For reading large datasets:
- CSVHelper provides a very efficient and optimized reading tool, tso using it may be appropriate in the most cases
- But we can also use chunk reading via CSVHelper too:  

        List<SampleDataDTO> batch = new List<SampleDataDTO>(1000);

        foreach (var record in csv.GetRecords<SampleDataDTO>())
        {
            batch.Add(record);

            if (batch.Count == 1000)
            {
                ProcessBatch(batch); // Process data function
                batch.Clear();
            }
        }

        if (batch.Any())
        {
            ProcessBatch(batch);
        }






