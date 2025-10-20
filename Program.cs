using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TestTaskETL;
using TestTaskETL.EF;
using TimeZoneConverter;


// Task 1
StreamReader reader = new StreamReader("sample-cab-data.csv");
CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture);

List<SampleDataDTO> csvRecords = csv.GetRecords<SampleDataDTO>().ToList();


// Task 10
TimeZoneInfo easternTimeZone = TZConvert.GetTimeZoneInfo("Eastern Standard Time");


// Task 6,7,8,10
List<SampleDataDTO> uniqueRecords = csvRecords
        .GroupBy(r => new { r.TpepPickupDatetime, r.TpepDropoffDatetime, r.PassengerCount })
        .Select(g => g.First())
        .Select(r => new SampleDataDTO{
            TpepPickupDatetime = TimeZoneInfo.ConvertTimeToUtc(r.TpepPickupDatetime, easternTimeZone),
            TpepDropoffDatetime = TimeZoneInfo.ConvertTimeToUtc(r.TpepDropoffDatetime, easternTimeZone),
            PassengerCount = r.PassengerCount,
            TripDistance = r.TripDistance,
            StoreAndFwdFlag = r.StoreAndFwdFlag.Replace("Y", "Yes").Replace("N", "No").Trim(),
            PULocationId = r.PULocationId,
            DOLocationId = r.DOLocationId,
            FareAmount = r.FareAmount,
            TipAmount = r.TipAmount})
        .ToList();


// Task 6
var duplicatesList = csvRecords
    .AsEnumerable()
    .GroupBy(r => new { r.TpepPickupDatetime, r.TpepDropoffDatetime, r.PassengerCount })
    .Where(g => g.Count() > 1)
    .SelectMany(g => g)
    .ToList();

var writer = new StreamWriter("duplicates.csv");
var duplicatesFile = new CsvWriter(writer, CultureInfo.InvariantCulture);
duplicatesFile.WriteRecords(duplicatesList);


List<SampleDataEntity> tableRecords = uniqueRecords.Select(r => r.ToEntity()).ToList();


// Task 5
ApplicationContext context = new ApplicationContext();
await context.SampleData.AddRangeAsync(tableRecords);
await context.SaveChangesAsync();





