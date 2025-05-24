namespace Csms_api.Helpers
{
    public static class TimeHelper
    {
        public static DateTime GetPhilippineTime()
        {
            var phpTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time");

            DateTime utcNow = DateTime.UtcNow;

            DateTime phpTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, phpTimeZone);

            return phpTime;
        }
    }
}
