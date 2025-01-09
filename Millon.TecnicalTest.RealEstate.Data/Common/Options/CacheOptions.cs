namespace Millon.TecnicalTest.RealEstate.Data.Common.Options
{
    public class CacheOptions
    {
        public const string Key = "CacheOptions";
        public int AbsoluteExpirationInHours { get; set; }
        public int SlidingExpirationInMinutes { get; set; }
    }
}
