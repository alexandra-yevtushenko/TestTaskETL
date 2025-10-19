namespace TestTaskETL.EF
{
    public class SampleDataEntity
    {
        public int Id {  get; set; }
 
        public DateTime TpepPickupDatetime { get; set; }

        public DateTime TpepDropoffDatetime { get; set; }

        public int? PassengerCount { get; set; }

        public float TripDistance { get; set; }

        public string StoreAndFwdFlag { get; set; }

        public int PULocationId { get; set; }

        public int DOLocationId { get; set; }

        public float FareAmount { get; set; }

        public float TipAmount { get; set; }

    }
}

