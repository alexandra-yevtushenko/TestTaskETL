using CsvHelper.Configuration.Attributes;
using TestTaskETL.EF;

namespace TestTaskETL
{
    public class SampleDataDTO
    {
        [Name("tpep_pickup_datetime")]
        public DateTime TpepPickupDatetime { get; set; }

        [Name("tpep_dropoff_datetime")]
        public DateTime TpepDropoffDatetime { get; set; }

        [Name("passenger_count")]
        public int? PassengerCount { get; set; }

        [Name("trip_distance")]
        public float TripDistance { get; set; }

        [Name("store_and_fwd_flag")]
        public string StoreAndFwdFlag { get; set; }

        [Name("PULocationID")]
        public int PULocationId { get; set; }

        [Name("DOLocationID")]
        public int DOLocationId { get; set; }

        [Name("fare_amount")]
        public float FareAmount { get; set; }

        [Name("tip_amount")]
        public float TipAmount { get; set; }



        public SampleDataEntity ToEntity()
        {
            return new SampleDataEntity
            {
                TpepPickupDatetime = this.TpepPickupDatetime,
                TpepDropoffDatetime = this.TpepDropoffDatetime,
                PassengerCount = this.PassengerCount,
                TripDistance = this.TripDistance,
                StoreAndFwdFlag = this.StoreAndFwdFlag,
                PULocationId = this.PULocationId,
                DOLocationId = this.DOLocationId,
                FareAmount = this.FareAmount,
                TipAmount = this.TipAmount
            };
        }

    }
}
